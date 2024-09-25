using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHp = 3;
    [SerializeField] private float hp;
    [SerializeField] PickupType pickupType;
    private SpriteRenderer spriteRenderer = null;
    private int spriteNumber = 0;
    private void Start()
    {
        hp = maxHp;
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        spriteRenderer.sprite = pickupType.sprites[spriteNumber];
    }

    private void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        var bounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        if (transform.position.x < bounds.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hp -= 1;
        pickupType.ApplyEffects(this.gameObject);
        NextSprite();
        CheckIfDestroyed();
    }

    private void CheckIfDestroyed()
    {
        if (hp > 0)
        {
            return;
        }

        EventManager.PickupDestroyed();
        Destroy(gameObject);
    }

    void NextSprite()
    {
        if (spriteNumber == pickupType.sprites.Count - 1)
        {
            return;
        }
        spriteNumber++;
        spriteRenderer.sprite = pickupType.sprites[spriteNumber];
    }
}
