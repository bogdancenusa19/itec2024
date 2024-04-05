using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [Header("Attributes")]
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private float jumpPower = 30.0f;
    [SerializeField] private float jumpVelocityShift = 0.5f;

    [Header("Objects & Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;

    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;

    #region Private Variables
    private float horizontal;
    private bool isFacingRight = true;
    #endregion

    void Update()
    {
        Jump();
        Flip();
        if(rb.velocity.x != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void FixedUpdate()
    {
        // Move
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); // Jump
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpVelocityShift);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
