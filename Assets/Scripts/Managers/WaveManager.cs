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
    [SerializeField] private bool isTutorial;
    
    private Dictionary<string, PrefabEntry> prefabDictionary = new();
    private Dictionary<string, float> nextSpawnTimes = new();
    private float gameSpeed;
    private float spawnSpeed;
    private float maxSpawnSpeed = 1.5f;

    void OnEnable()
    {
        EventManager.OnStartTutorial += OnStartTutorial;
        EventManager.OnSpawnTutorialItem += SpawnTutorialObject;
        EventManager.OnStartGame += EndTutorial;
        EventManager.OnSetGameSpeed += UpdateSpawnSpeed;
    }

    void OnDisable()
    {
        EventManager.OnStartTutorial -= OnStartTutorial;
        EventManager.OnSpawnTutorialItem -= SpawnTutorialObject;
        EventManager.OnStartGame -= EndTutorial;
        EventManager.OnSetGameSpeed -= UpdateSpawnSpeed;
    }

    void OnStartTutorial()
    {
        isTutorial = true;
    }

    void EndTutorial()
    {
        isTutorial = false;
    }

    void SpawnTutorialObject(string key)
    {
        SpawnObject(key, prefabDictionary[key].spawnPoint, 0);
    }

    void UpdateSpawnSpeed(float gameSpeed)
    {
        spawnSpeed += gameSpeed / 10;

        if (spawnSpeed > maxSpawnSpeed)
        {
            spawnSpeed = maxSpawnSpeed;
        }
    }

    void Start()
    {
        for (int i = 0; i < prefabEntries.Count; i++)
        {
            prefabDictionary.Add(prefabEntries[i].key, prefabEntries[i]);
            SetNextSpawnInterval(prefabEntries[i].key, prefabEntries[i].minSpawnInterval, prefabEntries[i].maxSpawnInterval);
        }
    }

    void Update()
    {
        if (isTutorial)
        {
            return;
        }

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
        if (prefabDictionary.TryGetValue(key, out PrefabEntry prefab))
        {
            Instantiate(prefab.gameObject, spawnPoint.transform.position + new Vector3(0, UnityEngine.Random.Range(-spawnNoise, spawnNoise)), Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"No prefab entry for {key} exists!");
        }
    }

    void SetNextSpawnInterval(string key, float minSpawnInterval, float maxSpawnInterval)
    {
        nextSpawnTimes[key] = Time.time + (UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval) - spawnSpeed);
    }
}
