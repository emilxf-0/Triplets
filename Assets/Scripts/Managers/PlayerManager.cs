using System.Collections.Generic;
using Unity.VisualScripting;
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
    private int startAvatars = 3;
    
    private void OnEnable()
    {
        EventManager.OnAddAvatar   += OnAddAvatar;
        EventManager.OnTakeDamage  += OnTakeDamage;
        EventManager.OnGainLife    += OnGainLife;
        EventManager.OnRestartGame += Init;
        EventManager.OnGameOver    += DestroyAvatars;
    }

    void Init()
    {
        for (int i = 0; i < startAvatars; i++)
        {
            var offset = new Vector3(spacing * i, 0, 0);
            playerTrail.Add(Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity));
        }
        
        EventManager.MultiplierChange(numberOfPlayerAvatars);
    }
    
    void Start()
    {   
        healthComponent = GetComponent<HealthComponent>();        
        Init();
    }

    private void OnDisable()
    {
        EventManager.OnAddAvatar   -= OnAddAvatar;
        EventManager.OnTakeDamage  -= OnTakeDamage;
        EventManager.OnGainLife    -= OnGainLife;
        EventManager.OnRestartGame -= Init;
        EventManager.OnGameOver    -= DestroyAvatars;
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

    void DestroyAvatars()
    {
        foreach (var avatar in playerTrail)
        {
            Destroy(avatar);
        }
        
        playerTrail.Clear();
    }
}
