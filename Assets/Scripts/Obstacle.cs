using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 0;
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
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < bounds.x)
        {
            Destroy(gameObject);
        }
    }
}
