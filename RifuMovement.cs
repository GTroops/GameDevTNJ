// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RifuMovement : MonoBehaviour
// {
//     float horizontalInput;
//     float moveSpeed = 5f;
//     bool isFacingRight = true;
//     float jumpPower = 4f;
//     bool isJumping = false;

//     Rigidbody2D rb;
//     Animator animator; 

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         horizontalInput = Input.GetAxis("Horizontal");

//         FlipSprite();

//         if(Input.GetButtonDown("Jump") && !isJumping)
//         {
//             rb.velocity = new Vector2(rb.velocity.x, jumpPower);
//             isJumping = true;
//         }
//     }

//     private void FixedUpdate()
//     {
//         rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
//         animator.SetFloat("xVelocity", (rb.velocity.x));
//     }

//     void FlipSprite()
//     {
//         if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
//         {
//             isFacingRight = !isFacingRight;
//             Vector3 ls = transform.localScale;
//             ls.x *= -1f;
//             transform.localScale = ls;
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision2D)
//     {
//         isJumping = false;
//     }
// }


using UnityEngine;
using System;

public class RifuMovement : MonoBehaviour
{

    float horizontalInput;
    float moveSpeed = 8f;
    bool isFacingRight = true;
    float jumpPower = 8f;
    bool isJumping = false;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}