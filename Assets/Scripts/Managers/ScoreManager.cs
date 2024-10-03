using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Serializable]
    public class HiScore
    {
        public int hiScore;
    }

    private int currentHiScore = 0;
    private int currentScore = 0;
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
        
        Invoke(nameof(SetHiscore), 0.1f);
    }

    public void OnAddScore(int score)
    {
        currentScore += score;

        if (currentScore > currentHiScore)
        {
            currentHiScore = currentScore;
            SaveHiScoreData(currentHiScore);
        }

        if (currentScore % 10 == 0)
        {
            EventManager.SetGameSpeed(5);
        }
    }
    void SaveHiScoreData(int score)
    {
        HiScore hiScoreData = new HiScore {hiScore = score};
        var json = JsonUtility.ToJson(hiScoreData);
        File.WriteAllText(filePath, json);
    }

    void SetHiscore()
    {
        var json = File.ReadAllText(filePath);
        HiScore hiScoreData = JsonUtility.FromJson<HiScore>(json);
        EventManager.SetHiScore(hiScoreData.hiScore);   
    }
}
