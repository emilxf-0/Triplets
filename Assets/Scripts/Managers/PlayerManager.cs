using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int numberOfPlayerAvatars;
    [SerializeField] private List<GameObject> playerTrail = new();
    [SerializeField] private float spacing                = 4f;
    [SerializeField] private int maxAvatars               = 6;
    private HealthComponent healthComponent;
    
    private void OnEnable()
    {
        EventManager.OnAddAvatar  += OnAddAvatar;
        EventManager.OnTakeDamage += OnTakeDamage;
        EventManager.OnGainLife   += OnGainLife;
    }
    
    void Start()
    {   
        healthComponent = GetComponent<HealthComponent>();        

        for (int i = 0; i < numberOfPlayerAvatars; i++)
        {
            var offset = new Vector3(spacing * i, 0, 0);
            playerTrail.Add(Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity));
        }

        EventManager.MultiplierChange(numberOfPlayerAvatars);
    }

    private void OnDisable()
    {
        EventManager.OnAddAvatar  -= OnAddAvatar;
        EventManager.OnTakeDamage -= OnTakeDamage;
        EventManager.OnGainLife   -= OnGainLife;
    }

    void OnGainLife(GameObject gameObject, int healAmount)
    {
        healthComponent.GainLife(healAmount);
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        healthComponent.TakeDamage(damage);
    }

    void OnAddAvatar()
    {
        if (playerTrail.Count >= maxAvatars)
        {
            EventManager.AddScore(100);
            return;
        } 
        
        var offset = new Vector3(spacing * numberOfPlayerAvatars, 0, 0);
        var newPlayerAvatar = Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity); 
        playerTrail.Add(newPlayerAvatar);
        numberOfPlayerAvatars++;

        EventManager.MultiplierChange(numberOfPlayerAvatars);
    }
}
