using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EventManager
{
    public static event Action                          OnPickUpDestroyed;
    public static event Action<GameObject>              OnSpawn;
    public static event Action<int>                     OnAddScore;
    public static event Action                          OnAddAvatar;
    public static event Action<Scene>                   OnSceneChange;
    public static event Action                          OnStartGame;
    public static event Action                          OnRestartGame;
    public static event Action                          OnGameOver;
    public static event Action                          OnPlayerJump;
    public static event Action<int>                     OnSetHiScore;
    public static event Action<float>                   OnSetGameSpeed;
    public static event Action<float>                   OnUpdateHealth;
    public static event Action<GameObject, int>         OnTakeDamage;
    public static event Action<GameObject, int>         OnGainLife;
    public static event Action<int>                     OnMultiplierChange;
    public static event Action<GameObject, Vector3>     OnExplosionVFX;
    public static event Action<GameObject, Vector3>     OnFlyingNumberVFX;

    public static void PickupDestroyed()                                        => OnPickUpDestroyed?.Invoke();
    public static void Spawn(GameObject gameObject)                             => OnSpawn?.Invoke(gameObject);
    public static void AddScore(int score)                                      => OnAddScore?.Invoke(score);
    public static void AddAvatar()                                              => OnAddAvatar?.Invoke();
    public static void StartGame()                                              => OnStartGame?.Invoke();
    public static void RestartGame()                                            => OnRestartGame?.Invoke();
    public static void GameOver()                                               => OnGameOver?.Invoke();
    public static void SceneChange(Scene scene)                                 => OnSceneChange?.Invoke(scene);
    public static void PlayerJump()                                             => OnPlayerJump?.Invoke();
    public static void SetHiScore(int hiScore)                                  => OnSetHiScore?.Invoke(hiScore);
    public static void SetGameSpeed(float speed)                                => OnSetGameSpeed?.Invoke(speed);
    public static void UpdateHealth(float newHealth)                            => OnUpdateHealth?.Invoke(newHealth);
    public static void TakeDamage(GameObject gameObject, int damage)            => OnTakeDamage?.Invoke(gameObject, damage);
    public static void GainLife(GameObject gameObject, int healAmount)          => OnGainLife?.Invoke(gameObject, healAmount);
    public static void MultiplierChange(int number)                             => OnMultiplierChange?.Invoke(number);
    public static void ExplosionVFX(GameObject gameObject, Vector3 position)    => OnExplosionVFX?.Invoke(gameObject, position);
    public static void FlyingNumberVFX(GameObject gameObject, Vector3 position) => OnFlyingNumberVFX?.Invoke(gameObject, position);
}
