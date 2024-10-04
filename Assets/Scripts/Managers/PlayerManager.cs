using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int numberOfPlayerAvatars;
    [SerializeField] private List<GameObject> playerTrail = new();
    [SerializeField] private float spacing = 4f;
    private HealthComponent healthComponent;
    private void OnEnable()
    {
        EventManager.OnAddLife += OnAddLife;
        EventManager.OnTakeDamage += OnTakeDamage;
    }
    void Start()
    {   
        healthComponent = GetComponent<HealthComponent>();        

        for (int i = 0; i < numberOfPlayerAvatars; i++)
        {
            var offset = new Vector3(spacing * i, 0, 0);
            playerTrail.Add(Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity));
        }
    }

    private void OnDisable()
    {
        EventManager.OnAddLife -= OnAddLife;
        EventManager.OnTakeDamage -= OnTakeDamage;
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        healthComponent.TakeDamage(damage);
    }


    void OnAddLife()
    {
        var offset = new Vector3(spacing * numberOfPlayerAvatars, 0, 0);
        var newPlayerAvatar = Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity); 
        playerTrail.Add(newPlayerAvatar);
        numberOfPlayerAvatars++;
    }
}
