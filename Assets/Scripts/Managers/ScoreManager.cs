using System;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Serializable]
    public class HiScore
    {
        public int hiScore;
    }

    [SerializeField] ScoreData scoreData;

    private int currentHiScore = 0;
    private int applesPicked = 0;
    private string filePath;

    void OnEnable()
    {
        EventManager.OnAddScore += OnAddScore;
    }

    void OnDisable()
    {
        EventManager.OnAddScore -= OnAddScore;
    }

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "hiScore.json");

        //Fix race condition
        Invoke(nameof(SetHiscore), 0.1f);
    }

    public void OnAddScore(int score)
    {
        scoreData.currentScore += score;

        applesPicked++;

        if (scoreData.currentScore > currentHiScore)
        {
            currentHiScore = scoreData.currentScore;
            SaveHiScoreData(currentHiScore);
        }

        if (applesPicked % 5 == 0)
        {
            EventManager.SetGameSpeed(1);
        }
    }

    void SaveHiScoreData(int score)
    {
        var hiScoreData = new HiScore { hiScore = score };
        var json = JsonUtility.ToJson(hiScoreData);
        File.WriteAllText(filePath, json);
    }

    void SetHiscore()
    {
        try
        {
            var json = File.ReadAllText(filePath);
            var hiScoreData = JsonUtility.FromJson<HiScore>(json);

            currentHiScore = hiScoreData.hiScore;
            EventManager.SetHiScore(hiScoreData.hiScore);
        }
        catch (Exception)
        {
            SaveHiScoreData(0);
            var json = File.ReadAllText(filePath);
            var hiScoreData = JsonUtility.FromJson<HiScore>(json);
            currentHiScore = hiScoreData.hiScore;
            EventManager.SetHiScore(hiScoreData.hiScore);
        }
    }
}
