using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EventManager 
{
    public static event Action OnPickUpDestroyed;
    public static event Action<GameObject> OnSpawn;
    public static event Action<int> OnAddScore;
    public static event Action OnAddLife;
    public static event Action<GameObject, int> OnTakeDamage;
    public static event Action<Scene> OnSceneChange;
    public static void PickupDestroyed()
    {
        OnPickUpDestroyed?.Invoke();   
    }
    public static void AddLife()
    {
        OnAddLife?.Invoke();
    }	
    public static void Spawn(GameObject gameObject)
    {
        OnSpawn?.Invoke(gameObject);
    }

    public static void AddScore(int score)
    {
        OnAddScore?.Invoke(score);
    }

    public static void TakeDamage(GameObject gameObject, int damage)
    {
        OnTakeDamage?.Invoke(gameObject, damage);
    }

    public static void SceneChange(Scene scene)
    {
        OnSceneChange?.Invoke(scene);
    }
}
