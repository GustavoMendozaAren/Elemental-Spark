using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    private Rigidbody2D rb;

    // Player Jump Variables
    private bool isGrounded;
    private bool jumped;

    public float jumpForce = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerWalk();
        PlayerJump();
    }

    void PlayerWalk()
    {
        // Get input from horizontal axis (A/D keys or left/right arrow keys)
        float moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void PlayerJump()
    {
            if (Input.GetKey(KeyCode.Space))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
                if (hit.collider != null)
                {
                    // Apply jump force vertically using Rigidbody2D
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
    }
}
