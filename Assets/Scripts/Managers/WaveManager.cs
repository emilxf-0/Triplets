using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Serializable]
    private class PrefabEntry
    {
        public string key;
        public GameObject gameObject;
        public float minSpawnInterval;
        public float maxSpawnInterval;
        public Transform spawnPoint;
        public float spawnNoise;
    }

    [SerializeField] private List<PrefabEntry> prefabEntries;
    private Dictionary<string, GameObject> prefabDictionary = new();
    private Dictionary<string, float> nextSpawnTimes = new();
    private float gameSpeed;

    void Start()
    {
        foreach (var prefab in prefabEntries)
        {
            prefabDictionary.Add(prefab.key, prefab.gameObject);
            SetNextSpawnInterval(prefab.key, prefab.minSpawnInterval, prefab.maxSpawnInterval);
        }
    }

    void Update()
    {

        foreach (var prefab in prefabEntries)
        {
            if (Time.time >= nextSpawnTimes[prefab.key])
            {
                SpawnObject(prefab.key, prefab.spawnPoint, prefab.spawnNoise); 
                SetNextSpawnInterval(prefab.key, prefab.minSpawnInterval, prefab.maxSpawnInterval);
            }
        
        }

    }
    void SpawnObject(string key, Transform spawnPoint, float spawnNoise)
    {
        if (prefabDictionary.TryGetValue(key, out GameObject prefab))
        {
            Instantiate(prefab, spawnPoint.transform.position + new Vector3(0, UnityEngine.Random.Range(-spawnNoise, spawnNoise)), Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"No prefab entry for {key} exists!");
        }
    }

    void SetNextSpawnInterval(string key, float minSpawnInterval, float maxSpawnInterval)
    {
        nextSpawnTimes[key] = Time.time + UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
