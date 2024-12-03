using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10;
    public float jumpHeight = 3;
    public float dashSpeed = 20;
    public float doubleJumpHeight = 6;

    [Header("Jump")]
    public Transform groundCheck; // player legs
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    [Header("Jump Machanics")]
    public float coyoteTime = 0.3f;
    public float jumpBufferTime = 0.3f;


    private float jumpBufferCounter;
    private float coyoteTimeCounter;


    private bool isGrounded;
    private Rigidbody2D rb;
    private float inputX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if(coyoteTimeCounter > 0 && jumpBufferCounter > 0)
        {
            jumpBufferCounter = 0; //prevent infinite jump
            var jumpVelocity = Mathf.Sqrt(jumpHeight * -2f *
                Physics.gravity.y * rb.gravityScale);
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
    }
}
