using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float shortJumpMultiplier;
    [SerializeField] private float friction = 0;

    public bool isGrounded = true;
    private Rigidbody2D rb = null;
    private bool isJumping = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            isJumping = true;
            EventManager.PlayerJump();
        }
    }

    public void Falling()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (rb.velocity.y > 0 && !(Input.touchCount > 0))
        {
            rb.velocity += (shortJumpMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
    }

    public void ApplyFriction()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity += friction * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && isJumping)
        {
            EventManager.PlayerGrounded(this.gameObject);
            isJumping = false;
            //Dirty, dirty fix so the in air animation doesn't hang
            Invoke(nameof(DelayGroundCheck), 0.001f);
        }
    }

    void DelayGroundCheck()
    {
        isGrounded = true;        
    }


    public bool IsGrounded()
    {
        return isGrounded;
    }
}
