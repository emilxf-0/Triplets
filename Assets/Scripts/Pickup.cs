using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHp = 3;
    [SerializeField] private float hp;
    private SpriteRenderer spriteRenderer = null;
    private void Start()
    {

        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1);     
    }

    void TakeDamage(int damage)
    {    
        hp -= damage;
        var healthPercent = hp/maxHp;
        
        //TODO: Add a spritearray to cycle through as the pickup "takes damage"
        if (hp <= 0)
        {
            KillObject();
        }
        if (healthPercent < 0.75f)
        {
            SetColor(Color.yellow);
        }
        if (healthPercent < 0.5f)
        {
            SetColor(Color.red);
        } 

    }
    private void KillObject()
    {
        EventManager.PickupDestroyed();
        Destroy(gameObject);
    }

    private void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

} 
