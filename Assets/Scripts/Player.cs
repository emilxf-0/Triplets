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
    private Camera cam = null;
    private Animator animator;

    void OnEnable()
    {
        EventManager.OnTakeDamage += OnTakeDamage;
    }
    
    void OnDisable()
    {
        EventManager.OnTakeDamage -= OnTakeDamage;
    }
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>(); 
        cam = Camera.main;
        animator = gameObject.GetComponent<Animator>();
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        if (gameObject == this.gameObject)
        {
            animator.SetBool("isHurt", true);
        } 
    }

    public void EndHurtAnimation()
    {
        animator.SetBool("isHurt", false);
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
                animator.SetBool("isJumping", true);
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
            animator.SetBool("isJumping", false);
            rb.gravityScale = 1;
        }
    }
}
