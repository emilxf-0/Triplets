using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    private Animator animator;
    private JumpComponent movementComponent;

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
    }

    // Update is called once per frame
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
