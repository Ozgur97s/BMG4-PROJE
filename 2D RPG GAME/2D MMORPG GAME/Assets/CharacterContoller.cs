using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContoller : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;


    Animator animator;
    Rigidbody2D rb;

    bool canJump = true;
    bool faceRight = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)   
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();    
        }

     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        if (canJump == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            canJump = false;

        }
    } 

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }

}
