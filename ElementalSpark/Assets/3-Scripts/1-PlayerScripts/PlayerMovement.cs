using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player speed variable
    public float moveSpeed = 5f; // Speed of player movement

    // Player rigidi body variable
    private Rigidbody2D rb;

    // Player Animator variable
    private Animator anim;

    // Player jump variables
    private bool jumped;

    public float jumpForce = 10f;

    // GroundCheck transform variable
    public Transform groundCheck;
    private bool isGrounded;

    // Attack
    public Transform attackCheck;
    private bool right = true;
    RaycastHit2D rayAttack;

    [HideInInspector]
    public bool effectiveAttack = false;


    void Awake()
    {
        // Initializing rigid body variable
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckOnGround();
        PlayerJump();

        Debug.DrawRay(attackCheck.position, Vector2.right * 1.1f, Color.red);
    }

    void FixedUpdate()
    {
        PlayerWalk();
        
    }

    void PlayerWalk()
    {
        // Get input from horizontal axis (A/D keys or left/right arrow keys)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Change direction of sprite
        if (moveInput > 0)
        {
            right = true;
            ChangeDirection(5);
            anim.SetBool("Running", true);
        }
        else if (moveInput < 0)
        {
            right = false;
            ChangeDirection(-5);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
            

        // Apply movement horizontally using Rigidbody2D
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void CheckOnGround() 
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.4f, LayerMask.GetMask("Ground"));

        if (isGrounded) 
        {
            anim.SetBool("Jumping", false);
        }
    }

    void PlayerJump()
    {
        // Check for jump input
        if (jumped || Input.GetKeyDown(KeyCode.Space))
        {
            jumped = false;
            // Check if the player is grounded before jumping
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.4f, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                // Apply jump force vertically using Rigidbody2D
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("Jumping", true);
            }

        }
    }

    // Player atack ability
    public void PlayerAtackButton()
    {
        anim.SetTrigger("Atack");
        if (right)
        {
            rayAttack = Physics2D.Raycast(attackCheck.position, Vector2.right, 1.1f, LayerMask.GetMask("Enemy"));
        }
        else
        {
            rayAttack = Physics2D.Raycast(attackCheck.position, Vector2.left, 1.1f, LayerMask.GetMask("Enemy"));
        }

        if (rayAttack)
        {
            effectiveAttack = true;
            Debug.Log("Attacked");
        }

    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    public void PlayerJumpButton()
    {
        jumped = true;
    }

    
}
