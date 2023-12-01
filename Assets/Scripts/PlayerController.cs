using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject currentBlock;
    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown("space") && isGrounded)
        {
            Jump();
        }
        BreakBlockBellow(transform.position);
        PlaceBlock(transform.position);
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (horizontalInput != 0)
        {
            // Flip the player sprite based on the direction
            spriteRenderer.flipX = horizontalInput > 0;
        }

        // Keep the rotation to 0
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void BreakBlockBellow(Vector3 currentPlayerPos) {
        if (Input.GetKeyDown("e"))
        {
            Vector3 playerPos = transform.position;
            Vector3 playerBelow = playerPos + Vector3.down * 0.3f;

            DestroyBlock(playerBelow);
        }
    }
    void DestroyBlock(Vector3 position)
    {
        Collider2D blockCollider = Physics2D.OverlapPoint(position);

        if (blockCollider != null)
        {
            Destroy(blockCollider.gameObject);
        }
    }

    void PlaceBlock(Vector3 currentPlayerPos) {
        if (Input.GetKeyDown("q")) {
            Vector3 playerPos = transform.position;
            // float yDiff = 0.096f;
            // float xDiff = 0.0152f;
            float gridSize = 0.16f;
            float XBN = (float)Math.Ceiling(currentPlayerPos.x / gridSize) * gridSize;
            float YPlayerGrid = (float)Math.Floor(currentPlayerPos.y / gridSize) - 1.0f;
            Debug.Log(YPlayerGrid);
            float YBN = (YPlayerGrid * gridSize) + 0.1f;
            Debug.Log(YBN);

            Instantiate(currentBlock, new Vector3(XBN, YBN, 0), Quaternion.identity);
        }
    }
}
