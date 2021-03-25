using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;          //스피드
    public float jumpSpeed = 3;         //쩜프 속도
    public float doubleJumpSpeed = 2.5f;    //더블점프
    private bool canDoubleJump;             //점프 확인

    public Rigidbody2D rigidBody;

    public bool betterJump = false;         //낮은점프 확인
    public float fallMultiplier = 0.5f;     //낮은점프 속도
    public float lowJumpMultiplier = 1f;    //높은점프 속도

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    //public float maxSpeed;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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


    //이동관련된 부분은 전부 FixedUpdate에
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
