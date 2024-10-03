using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private Collider2D playerCollider = null;
    private Camera cam = null;

    void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        cam = Camera.main;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);

            if (playerCollider.OverlapPoint(touchPosition) && movementComponent.IsGrounded())
            {
                movementComponent.Jump();
            }
        }

        movementComponent.Falling();

    }
}
