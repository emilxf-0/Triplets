using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    public bool isGrounded = true;
    private Rigidbody2D rb = null;
    private Collider2D playerCollider = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
                        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider == playerCollider && isGrounded)
            {
                Debug.Log("I hit the object yo!");
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
