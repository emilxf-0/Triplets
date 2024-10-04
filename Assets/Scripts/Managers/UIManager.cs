using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen = null;
    void OnEnable()
    {
        EventManager.OnGameOver += OnGameOver;
    }

    void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOver;
    }

    void Start()
    {
        gameOverScreen.SetActive(false);
    }
    

    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
