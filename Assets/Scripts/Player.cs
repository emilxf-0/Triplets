using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float strength;
    [SerializeField] private float fallSpeed = 0;
    public bool isGrounded = true;
    private Rigidbody2D rb = null;
    private Collider2D playerCollider = null;
    private bool isInvincible;
    private Camera cam = null;

    void OnEnable()
    {
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>(); 
        cam = Camera.main;
    }

    void OnDisable()
    {
    }


    void Update()
    {
                        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);
            
            if (playerCollider.OverlapPoint(touchPosition) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }

        }

        if (!isGrounded)
        {
            rb.gravityScale += fallSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            rb.gravityScale = 1;
        }
    }
}
