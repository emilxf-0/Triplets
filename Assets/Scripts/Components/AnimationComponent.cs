using System.Collections;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private JumpComponent jumpComponent;
    private SpriteRenderer spriteRenderer;


    void OnEnable()
    {
        EventManager.OnTakeDamage += OnTakeDamage;
        EventManager.OnPlayerGrounded += StopJumpAnimation;
    }

    void OnDisable()
    {
        EventManager.OnTakeDamage -= OnTakeDamage;
        EventManager.OnPlayerGrounded -= StopJumpAnimation;
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
        jumpComponent = GetComponent<JumpComponent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StopJumpAnimation(GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            animator.SetBool("isJumping", false);
        }
    }

    public void StartJumpAnimation()
    {
        animator.SetBool("isJumping", true);
    }

    void EndHurtAnimation()
    {
        animator.SetBool("isHurt", false);
    }
}
