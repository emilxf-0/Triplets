using System.Collections;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    private Animator animator;
    private JumpComponent movementComponent;
    private SpriteRenderer spriteRenderer;


    void OnEnable()
    {
        EventManager.OnTakeDamage += OnTakeDamage;
    }

    void OnDisable()
    {
        EventManager.OnTakeDamage -= OnTakeDamage;
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        if (gameObject == this.gameObject)
        {
            animator.SetBool("isHurt", true);
        }
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        movementComponent = GetComponent<JumpComponent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movementComponent.IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    void EndHurtAnimation()
    {
        animator.SetBool("isHurt", false);
    }
}
