using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Networking;
public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText      = null;
    [SerializeField] private TMP_Text hiScoreText    = null;
    [SerializeField] private TMP_Text multiplierText = null;
    [SerializeField] private Image healthBar         = null;
    private StringBuilder sb;
    private int score    = 0;
    private int newScore = 0;
    private RectTransform multiplierTransform = null;
    
    void OnEnable()
    {
        EventManager.OnAddScore         += OnAddScore;
        EventManager.OnSetHiScore       += OnSetHiScore;
        EventManager.OnUpdateHealth     += OnUpdateHealth;
        EventManager.OnMultiplierChange += OnUpdateMultiplier;
    }

    void OnDisable()
    {
        EventManager.OnAddScore         -= OnAddScore;
        EventManager.OnSetHiScore       -= OnSetHiScore;
        EventManager.OnUpdateHealth     -= OnUpdateHealth;
        EventManager.OnMultiplierChange -= OnUpdateMultiplier;
    }

    void OnAddScore(int score)
    {
        newScore = this.score + score;
        UpdateScore();
        
        DOTween.To(() => this.score, x => this.score = x, newScore, 1.5f).SetId(this)
        .OnUpdate(() => UpdateScore())
        .OnComplete(() => UpdateScore());
    }

    void OnUpdateMultiplier(int multiplier)
    {
        multiplierText.text = $"X{multiplier.ToString()}";

        multiplierTransform.DOPunchScale(new Vector3(1, 1, 1), 1f).SetId(this);
    }

    void UpdateScore()
    {
        sb.Clear();
        sb.Append("Score: ").AppendFormat("{0:D6}", score);
        scoreText.text = sb.ToString();
    }

    void Awake()
    {
        sb = new StringBuilder();
        multiplierTransform = multiplierText.GetComponent<RectTransform>();
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

    void UpdateHiScore(int hiScore)
    {
        sb.Clear();
        sb.Append("Hiscore: ").AppendFormat("{0:D6}", hiScore);
        hiScoreText.text = sb.ToString();
    }

    void OnDestroy()
    {
        DOTween.Kill(this);
    }
}
