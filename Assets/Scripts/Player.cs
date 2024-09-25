using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    void OnEnable()
    {
        EventManager.OnSpawn += OnSpawn;
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>(); 
    }

    void OnDisable()
    {
        EventManager.OnSpawn -= OnSpawn;
    }

    void OnSpawn(GameObject gameObject)
    {
        if (gameObject != this.gameObject)
        {
            return;
        }
        playerCollider.enabled = false;
        Invoke("ToggleInvincibility", 3f);
    }    

    void Update()
    {
                        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider == playerCollider && isGrounded)
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

    private void ToggleInvincibility()
    {
        playerCollider.enabled = true;
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
