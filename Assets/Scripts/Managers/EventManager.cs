using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EventManager 
{
    public static event Action OnPickUpDestroyed;
    public static event Action<GameObject> OnSpawn;
    public static event Action<int> OnAddScore;
    public static event Action OnAddAvatar;
    public static event Action<GameObject, int> OnTakeDamage;
    public static event Action<Scene> OnSceneChange;
    public static event Action OnRestartGame;
    public static event Action OnGameOver;
    public static event Action OnUpdateHiScore;
    public static event Action<int> OnSetHiScore;
    public static event Action<float> OnSetGameSpeed;
    public static event Action<float> OnUpdateHealth;
    public static void PickupDestroyed()
    {
        OnPickUpDestroyed?.Invoke();   
    }
    public static void AddLife()
    {
        OnAddAvatar?.Invoke();
    }	
    public static void Spawn(GameObject gameObject)
    {
        OnSpawn?.Invoke(gameObject);
    }

    public static void AddScore(int score)
    {
        OnAddScore?.Invoke(score);
    }

    public static void RestartGame()
    {
        OnRestartGame?.Invoke();
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void TakeDamage(GameObject gameObject, int damage)
    {
        OnTakeDamage?.Invoke(gameObject, damage);
    }

    public static void SceneChange(Scene scene)
    {
        OnSceneChange?.Invoke(scene);
    }

    public static void SetHiScore(int hiScore)
    {
        OnSetHiScore?.Invoke(hiScore);
    }

    public static void SetGameSpeed(float speed)
    {
        OnSetGameSpeed?.Invoke(speed);
    }

    public static void UpdateHealth(float newHealth)
    {
        OnUpdateHealth?.Invoke(newHealth);
    }
}
