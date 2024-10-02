using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HiScoreManager : MonoBehaviour
{
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
    }

    public void OnAddScore(int score)
    {
        currentScore += score;

        if (currentScore > currentHiScore)
        {
            currentHiScore = currentScore;
            File.WriteAllText(filePath, currentHiScore.ToString());
        }
    }
}
