using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb; // must include an underscore when adding a private variable in C#
    private Collider2D _playerCollider;

    public float playerSpeed = 5f;
    public float jumpHeight = 10f;
    private float _groundCheckDistance = 0.1f;
    private bool _isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() // computer framerate
    {
        HandleMovement();
        HandleJump();
    }

    void FixedUpdate() // always updates at a constant rate
    {
        CheckGrounded(); // method call
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(_isGrounded == true)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocityX, jumpHeight);
            }

        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        _rb.linearVelocityX = playerSpeed * moveInput;
    }

    private void CheckGrounded()
    {
        Bounds bounds = _playerCollider.bounds; // method definition
        Vector2 leftRayOrigin = new Vector2(bounds.min.x, bounds.min.y); // left foot
        Vector2 rightRayOrigin = new Vector2(bounds.max.x, bounds.min.y); // right foot

        RaycastHit2D hitLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));

        _isGrounded = hitLeft.collider != null || hitRight.collider != null; // if both feet aren't touching the ground, i am off the ground
    }
}
