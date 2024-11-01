using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float touchAreaStartOffset = 0;
    [SerializeField] private float touchAreaStart;
    private float horizontalOffset = 1.5f;
    private JumpComponent jumpComponent;
    private Collider2D playerCollider = null;
    private Camera cam = null;
    private AnimationComponent animationComponent= null;

    void Start()
    {
        jumpComponent = GetComponent<JumpComponent>();
        animationComponent = GetComponent<AnimationComponent>();
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
            if (touchPosition.y < touchAreaStart && touchPosition.x > (transform.position.x - horizontalOffset) && touchPosition.x < (transform.position.x + horizontalOffset) && jumpComponent.IsGrounded())
            {
                animationComponent.StartJumpAnimation();
                //jumpComponent.Jump();
            }
        }

        jumpComponent.ApplyFriction();
        jumpComponent.Falling();


    }
}
