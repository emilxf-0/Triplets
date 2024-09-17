using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform spawnPoint = null;
    private float startTime = 0;
    private float currentTime = 0;
    private float offset = 0;
    void Start()
    {
       startTime = Time.time; 
    }

    void Update()
    {
        currentTime = Time.time;
        if (currentTime - startTime > spawnInterval - offset)
        {
            Instantiate(pickupPrefab, spawnPoint.transform.position, Quaternion.identity);
            startTime = currentTime;
            offset = Random.Range(-spawnInterval, spawnInterval);
        }
    }
}
