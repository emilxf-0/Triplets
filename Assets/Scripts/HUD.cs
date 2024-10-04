using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text hiScoreText = null;
    [SerializeField] private Image healthBar = null;
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
        scoreText.text = $"Score: {this.score:D6}";
    }

    void Awake()
    {
    }

    void Start()
    {
        scoreText.text = $"Score: {score:D6}";
        hiScoreText.text = $"Hiscore: {score:D6}";
    }

    void OnSetHiScore(int hiScore)
    {
        hiScoreText.text = $"Hiscore: {hiScore:D6}";
    }

    void OnUpdateHealth(float newHealth)
    {
        healthBar.fillAmount = newHealth;
    }
}
