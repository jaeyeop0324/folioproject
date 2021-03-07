using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    public Rigidbody2D rigidBody;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    //public float maxSpeed;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Screen.SetResolution(1280, 720, true);

    }
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("isDoubleJump", true);
                        rigidBody.velocity = new Vector2(rigidBody.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                    
                }
            }
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("isJump", true);
            animator.SetBool("isRun", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isDoubleJump", false);
            animator.SetBool("isFalling", false);
        }

        if (rigidBody.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }
        else if (rigidBody.velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isRun",true);
        }
        else if (Input.GetKey("left"))
        {
            rigidBody.velocity = new Vector2(-runSpeed, rigidBody.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isRun", true);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animator.SetBool("isRun", false);
        }
        if (betterJump)
        {
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rigidBody.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
