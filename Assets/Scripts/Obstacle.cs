using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private SpriteRenderer spriteRenderer = null;
    
    private Vector3 bounds;

    void OnEnable()
    {
        EventManager.OnRestartGame += DestroyObstacle;
    }


    void OnDisable()
    {
        EventManager.OnRestartGame -= DestroyObstacle;
    }

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.TakeDamage(other.gameObject, damage);   
        }
    }

    void DestroyObstacle()
    {
        Destroy(gameObject);
    }

}
