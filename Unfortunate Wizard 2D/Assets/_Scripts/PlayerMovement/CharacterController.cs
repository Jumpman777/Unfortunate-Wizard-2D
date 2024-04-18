using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer player;
    public float jumpForce;
    public float moveSpeed;
    public float attackCooldown = 2f;
    [SerializeField] private float timer;

    private bool isJumping;
    private bool canJump = true;
    [SerializeField] private bool canAttack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0f)
        {
            Move(moveHorizontal);
        }
        else
        {
            StopMoving();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && canJump)
        {
            Jump();
            StopMoving();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
        }

         timer += Time.deltaTime;
        
         if (Input.GetMouseButtonDown(0))
         {
             if (timer > attackCooldown)
             {
                 Attack();
                 timer = 0;
             }
             
         }
       

    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        animator.SetBool("run", true);
        if (direction < 0)
        {
            player.flipX = true;
        }
        else if (direction > 0)
        {
            player.flipX = false;
        }
    }

    private void Attack()
    {
        animator.SetBool("CanAttack", true);
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        animator.SetBool("run", false);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        animator.SetBool("jump", true);
        isJumping = true;
        canJump = false; // Disable jumping until the player lands
    }

    private void StopJump()
    {
        if (isJumping)
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Object"))
        {
            canJump = true; // Enable jumping when the player lands on the ground or the object with the desired tag
        }
    }
}
