using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveRight;

    public Transform down_Collision;


    // Vision
    public Transform visitonTransform;
    private RaycastHit2D hit;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveRight = true;
    }

    private void Update()
    {

        CheckCollision();
        EnemyVision();
        EnemyAtackAnimations();
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }



    void EnemyMovement() 
    {
        if (moveRight)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }

        anim.SetBool("Move", true);
    }

    void CheckCollision() 
    {
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.2f)) 
        {
            ChangeDirection();
        }
    }

    void EnemyVision() 
    {
        if (moveRight)
        {
            hit = Physics2D.Raycast(visitonTransform.position, Vector2.right, 1.5f, LayerMask.GetMask("Player"));
            //Debug.DrawRay(visitonTransform.position, visitonTransform.right * 1.5f, Color.green);
        }
        else
        {
            hit = Physics2D.Raycast(visitonTransform.position, Vector2.left, 1.5f, LayerMask.GetMask("Player"));
            //Debug.DrawRay(visitonTransform.position, visitonTransform.right * -1.5f, Color.green);
        }
    }

    private void EnemyAtackAnimations() 
    {
        if (!hit) 
        {
            anim.SetBool("Atack", false);
        }
        else 
        {
            anim.SetBool("Atack", true);
        }
    }

    void ChangeDirection() 
    {
        moveRight = !moveRight;

        Vector3 tempScale = transform.localScale;

        if (moveRight)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;  
    }

    public void CambiardireccionPublico()
    {
        ChangeDirection();
    }

    // Damage to player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Atack") 
        {
            // DAMAGE TO PLAYER
            
            Debug.Log("Damage");
        }
    }




} // Class
