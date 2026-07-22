using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb; // must include an underscore when adding a private variable in C#

    public float playerSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocityX, 5f);
        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        _rb.linearVelocityX = playerSpeed * moveInput;
    }
}
