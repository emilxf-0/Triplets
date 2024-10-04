using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text hiScoreText = null;
    [SerializeField] private Image healthBar = null;
    private StringBuilder sb;
    private int score = 0;
    void OnEnable()
    {
        EventManager.OnAddScore += OnAddScore;
        EventManager.OnSetHiScore += OnSetHiScore;
        EventManager.OnUpdateHealth += OnUpdateHealth;
    }

    void OnDisable()
    {
        EventManager.OnAddScore -= OnAddScore;
        EventManager.OnSetHiScore -= OnSetHiScore;
        EventManager.OnUpdateHealth -= OnUpdateHealth;
    }

    void OnAddScore(int score)
    {
        this.score += score;
        UpdateScore();
    }

    void Awake()
    {
        sb = new StringBuilder();
    }

    void Start()
    {
        UpdateScore();
        UpdateHiScore(score);
    }

    void OnSetHiScore(int hiScore)
    {
        UpdateHiScore(hiScore);
    }

    void OnUpdateHealth(float newHealth)
    {
        healthBar.fillAmount = newHealth;
    }

    void UpdateScore()
    {
        sb.Clear();
        sb.Append("Score: ").AppendFormat("{0:D6}", score);
        scoreText.text = sb.ToString();
    }

    void UpdateHiScore(int hiScore)
    {
        sb.Clear();
        sb.Append("Hiscore: ").AppendFormat("{0:D6}", hiScore);
        hiScoreText.text = sb.ToString();
    }
}
