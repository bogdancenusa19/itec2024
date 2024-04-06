using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [Header("Attributes")]
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private float airControlSpeed = 1.0f;
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
    private float currentSpeed;
    #endregion

    private void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        Jump();
        AirControl();
        FlipMouseDirection();
        IsGrounded();
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
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); // Jump
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpVelocityShift);
        }
    }

    private void AirControl()
    {
        if(rb.velocity.y != 0)
        {
            currentSpeed = airControlSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
    }

    private bool IsGrounded()
    {
        animator.SetBool("isGrounded", Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipMouseDirection()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

    
        // Verificăm dacă mouse-ul este la dreapta sau la stânga personajului
        bool mouseIsRightOfPlayer = mousePosition.x >= transform.position.x;

        // Dacă orientarea personajului nu este aliniată cu poziția mouse-ului, întoarcem personajul
        if((mouseIsRightOfPlayer && !isFacingRight) || (!mouseIsRightOfPlayer && isFacingRight))
        {
            Flip();
        }
    }

private void Flip()
{
    isFacingRight = !isFacingRight;
    Vector3 localScale = transform.localScale;
    localScale.x *= -1;
    transform.localScale = localScale;
}
}
