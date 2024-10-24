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
        EventManager.OnMultiplierChange += UpdateMultiplier;
    }

    void OnDisable()
    {
        EventManager.OnAddScore         -= OnAddScore;
        EventManager.OnSetHiScore       -= OnSetHiScore;
        EventManager.OnUpdateHealth     -= OnUpdateHealth;
        EventManager.OnMultiplierChange -= UpdateMultiplier;
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
        UpdateMultiplier(3);
    }

    void OnAddScore(int score)
    {
        newScore = this.score + score;
        UpdateScore();
        
        DOTween.Kill("ScoreTween");
        DOTween.To(() => this.score, x => this.score = x, newScore, 1.5f).SetId("ScoreTween")
        .OnUpdate(() => UpdateScore())
        .OnComplete(() => UpdateScore());
    }

    void UpdateMultiplier(int multiplier)
    {
        sb.Clear();
        sb.Append("X" + multiplier);
        multiplierText.text = sb.ToString();

        DOTween.Kill("MultiplierTween");

        multiplierTransform.DOPunchScale(new Vector3(1f, 1f, 0), 1f).SetId("MultiplierTween");
    }

    void UpdateScore()
    {
        sb.Clear();
        sb.Append("Score: ").AppendFormat("{0:D6}", score);
        scoreText.text = sb.ToString();
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
        DOTween.Kill("ScoreTween");
        DOTween.Kill("MultiplierTween");
    }
}
