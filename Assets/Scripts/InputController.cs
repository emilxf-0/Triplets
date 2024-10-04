using UnityEngine;

public class InputController : MonoBehaviour
{
    private JumpComponent jumpComponent;
    private Collider2D playerCollider = null;
    private Camera cam = null;

    void Start()
    {
        jumpComponent = GetComponent<JumpComponent>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        cam = Camera.main;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);
            
            //TODO: Clean this check up
            if (touchPosition.y < transform.position.y && touchPosition.x > (transform.position.x - 1) && touchPosition.x < (transform.position.x + 1) && jumpComponent.IsGrounded())
            {
                jumpComponent.Jump();
            }
        }

        jumpComponent.Falling();

    }
}
