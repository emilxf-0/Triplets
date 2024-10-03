using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameSpeedData gameSpeed;
    private SpriteRenderer spriteRenderer = null;
    private Vector3 bounds;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.TakeDamage(other.gameObject, 1);
        }
    }
    
    void Update()
    {
        transform.position += new Vector3(-gameSpeed.speed * Time.deltaTime, 0, 0);

        if (transform.position.x < bounds.x)
        {
            Destroy(gameObject);
        }
    }
}
