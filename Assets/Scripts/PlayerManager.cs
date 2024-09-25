using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int life;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> playerLife = new();
    private float spacing = 3f;
    
    private void OnEnable()
    {
        EventManager.OnTakeDamage += OnTakeDamage;
        EventManager.OnPickUpDestroyed += OnPickUpDestroyed;
    }
    void Start()
    {   
        for (int i = 0; i < life; i++)
        {
            var offset = new Vector3(spacing * i, 0, 0);
            playerLife.Add(Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity));
        }
    }

    private void OnDisable()
    {
        EventManager.OnTakeDamage -= OnTakeDamage;
        EventManager.OnPickUpDestroyed -= OnPickUpDestroyed;
    }

    void OnPickUpDestroyed()
    {
        AddLife();
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        life--;
        Destroy(playerLife[life]);
        playerLife.RemoveAt(life);

        if (life <= 0)
        {
            SceneManager.LoadScene("Start");
        }
    }    

    void AddLife()
    {
        var offset = new Vector3(spacing * life, 0, 0);
        var newPlayerAvatar = Instantiate(playerPrefab, spawnPoint.transform.position - offset, Quaternion.identity); 
        playerLife.Add(newPlayerAvatar);
        life++;
    }
}
