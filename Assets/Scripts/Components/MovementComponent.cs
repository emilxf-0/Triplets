using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private GameSpeedData gameSpeedData;
    private Vector2 bounds;
    
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
    }

    void Update()
    {
        transform.position += new Vector3(-gameSpeedData.speed * Time.deltaTime, 0, 0);

        if (transform.position.x < bounds.x)
        {
            if (gameObject.CompareTag("Apple"))
            {
                EventManager.GotDestroyedOffScreen(gameObject, "Apple");
            }
            
            if (gameObject.CompareTag("Obstacle"))
            {
                EventManager.GotDestroyedOffScreen(gameObject, "Obstacle");
            }

            Destroy(gameObject);
        }
    }

    
}
