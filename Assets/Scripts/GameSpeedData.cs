using UnityEngine;


[CreateAssetMenu(fileName = "GameSpeedData")]
public class GameSpeedData : ScriptableObject
{
    public float defaultGameSpeed;
    public float speed;

    void OnEnable()
    {
        speed = defaultGameSpeed;
        EventManager.OnSetGameSpeed += OnSetGameSpeed;
        EventManager.OnRestartGame += OnRestartGame;
    }

    void OnDisable()
    {
        EventManager.OnSetGameSpeed -= OnSetGameSpeed;
        EventManager.OnRestartGame -= OnRestartGame;
    }

    void OnRestartGame()
    {
        speed = defaultGameSpeed;
    }

    void OnSetGameSpeed(float gameSpeed)
    {
        speed += gameSpeed;
    }
}
