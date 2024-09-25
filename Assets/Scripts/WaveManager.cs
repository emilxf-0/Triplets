using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    [Serializable]
    private class PrefabEntry
    {
        public string key;
        public GameObject gameObject;
    }

    [SerializeField] private List<PrefabEntry> prefabEntries;
    private Dictionary<string, GameObject> prefabDictionary = new();
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform pickupSpawnPoint = null;
    [SerializeField] private Transform obstacleSpawnPoint = null;
    [SerializeField] private float offsetInterval = 0;
    private float startTime = 0;
    private float currentTime = 0;
    private float offset = 0;

    void Start()
    {
        foreach (var prefab in prefabEntries)
        {
            prefabDictionary.Add(prefab.key, prefab.gameObject);
        }
        startTime = Time.time;

    }

    void Update()
    {
        currentTime = Time.time;
        if (currentTime - startTime > spawnInterval - offset)
        {
            SpawnObject("Extralife", pickupSpawnPoint);
            SpawnObject("Obstacle", obstacleSpawnPoint);
            startTime = currentTime;
            offset = UnityEngine.Random.Range(-offsetInterval, offsetInterval);
        }
    }

    void SpawnObject(string key, Transform spawnPoint)
    {

        if (prefabDictionary.TryGetValue(key, out GameObject prefab))
        {
            Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"No prefab entry for {key} exists!");
        }
    }
}
