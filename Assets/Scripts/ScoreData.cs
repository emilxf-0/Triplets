using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData")]

public class ScoreData : ScriptableObject
{

    public int defaultMultiplier = 1;
    public int defaultScore      = 0;    
    public int currentMultiplier = 1;
    public int currentScore      = 0;


    void OnEnable()
    {
        ResetAllScores();
        EventManager.OnMultiplierChange += UpdateMultiplier;
        EventManager.OnRestartGame += OnRestartGame;
    }

    void OnDisable()
    {
        EventManager.OnMultiplierChange -= UpdateMultiplier;
        EventManager.OnRestartGame -= OnRestartGame;
    }

    void OnRestartGame()
    {
        ResetAllScores();
    }

    void UpdateMultiplier(int multiplier)
    {
        currentMultiplier = multiplier;
    }

    void ResetAllScores()
    {
        currentMultiplier = defaultMultiplier;
        currentScore      = defaultScore;
    }

}
