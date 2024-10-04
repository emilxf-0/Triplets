using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] PickupType pickupType;
    private SpriteRenderer spriteRenderer = null;
    private int spriteNumber = 0;
    private Vector3 bounds;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        bounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        spriteRenderer.sprite = pickupType.sprites[spriteNumber];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        pickupType.ApplyEffects(this.gameObject);
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
