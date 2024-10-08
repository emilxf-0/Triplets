using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float touchAreaStartOffset = 0;
    [SerializeField] private float touchAreaStart;
    private JumpComponent jumpComponent;
    private Collider2D playerCollider = null;
    private Camera cam = null;

    void Start()
    {
        jumpComponent = GetComponent<JumpComponent>();
        playerCollider = gameObject.GetComponent<Collider2D>();
     
        touchAreaStart = gameObject.transform.position.y + touchAreaStartOffset;

        cam = Camera.main;
    }

    void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(gameObject.transform.position + new Vector3(0, touchAreaStartOffset, 0), 1);
        }
        #endif
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);
            
            //TODO: Clean this check up
            if (touchPosition.y < touchAreaStart && touchPosition.x > (transform.position.x - 1) && touchPosition.x < (transform.position.x + 1) && jumpComponent.IsGrounded())
            {
                jumpComponent.Jump();
            }
        }

        jumpComponent.ApplyFriction();
        jumpComponent.Falling();


    }
}
