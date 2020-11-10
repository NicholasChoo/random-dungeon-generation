using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    private Vector2 moveVelocity;

    public float lookDirection;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.S)) //down
        {
            lookDirection = 0f;
        }
        else if (Input.GetKey(KeyCode.W)) //up
        {
            lookDirection = 0.33f;
        }
        else if (Input.GetKey(KeyCode.A)) //left
        {
            lookDirection = 0.66f;
        }
        else if (Input.GetKey(KeyCode.D)) //right
        {
            lookDirection = 1f;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Direction", lookDirection);

        moveVelocity = movement.normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
