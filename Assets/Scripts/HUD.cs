using TMPro;
using UnityEngine;
using System.IO;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text hiScoreText = null;
    private int score = 0;
    void OnEnable()
    {
        EventManager.OnPickUpDestroyed += OnPickUpDestroyed;
        EventManager.OnAddScore += OnAddScore;
        EventManager.OnSetHiScore += OnSetHiScore;
    }

    void OnAddScore(int score)
    {
        this.score += score;
        scoreText.text = $"Score: {this.score:D6}";
    }

    void OnPickUpDestroyed()
    {
        score += 1;
    }

    void OnDisable()
    {
        EventManager.OnPickUpDestroyed -= OnPickUpDestroyed;
        EventManager.OnAddScore -= OnAddScore;
        EventManager.OnSetHiScore -= OnSetHiScore;
    }
    void Start()
    {
        scoreText.text = $"Score: {score:D6}";
        hiScoreText.text = $"Score: {score:D6}";
    }

    void OnSetHiScore(int hiScore)
    {
        hiScoreText.text = $"Score: {hiScore:D6}";
    }
}
