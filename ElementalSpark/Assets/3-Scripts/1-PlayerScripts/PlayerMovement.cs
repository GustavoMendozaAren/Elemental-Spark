using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player speed variable
    public float moveSpeed = 5f; // Speed of player movement

    // Player rigidi body variable
    private Rigidbody2D rb;

    // Player jump variables
    private bool isGrounded;
    private bool jumped;

    public float jumpForce = 10f;

    // GroundCheck transform variable
    public Transform groundCheck;

    void Awake()
    {
        // Initializing rigid body variable
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

        // Change direction of sprite
        if (moveInput > 0)
            ChangeDirection(5);
        else if (moveInput < 0)
            ChangeDirection(-5);

        // Apply movement horizontally using Rigidbody2D
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void PlayerJump()
    {
        // Check for jump input
        if (Input.GetKey(KeyCode.Space))
        {

            // Check if the player is grounded before jumping
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.4f, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                // Apply jump force vertically using Rigidbody2D
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
}
