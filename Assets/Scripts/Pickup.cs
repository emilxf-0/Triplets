using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class Pickup : MonoBehaviour
{
    [SerializeField] PickupType pickupType;
    private HealthComponent healthComponent = null;
    private SpriteRenderer spriteRenderer = null;
    private int spriteNumber = 0;
    private Vector3 bounds;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        healthComponent = gameObject.GetComponent<HealthComponent>();

        bounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        spriteRenderer.sprite = pickupType.sprites[spriteNumber];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Has to be "1" because Takedamage() triggers after OnTriggerEnter
        if (healthComponent.CurrentHealth() <= 1)
        {
            pickupType.ApplyEffects(other.gameObject);
            pickupType.ApplyVFX(transform.position + new Vector3(0, 0, -5));
        }

        NextSprite();
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
