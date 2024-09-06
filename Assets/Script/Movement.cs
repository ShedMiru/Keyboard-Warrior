using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private WindowLoad WL;
    private Interact interact;
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Animator animasi;
    public bool isLeft;
    public bool onGround;
    public bool WindowActive;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WL = FindAnyObjectByType<WindowLoad>();
        speed = 5f;
        jumpForce = 12f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MoveRoom2")
        {
            SceneManager.LoadScene("Room2");
        }
        if (col.tag == "MoveRoom1")
        {
            SceneManager.LoadScene("Room1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WindowActive != true)
        {
            if (rb.gravityScale == 0)
            {
                rb.gravityScale = 3;
            }
            Walk();
            Jump();
        }
        else
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                rb.velocity = new Vector2(0, 0);
                animasi.SetBool("isWalking", false);
            }
            if (!onGround)
            {
                rb.gravityScale = 0;
            }
        }
    }

    void Walk()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (moveInput != 0)
        {
            animasi.SetBool("isWalking", true);
        }
        else
        {
            animasi.SetBool("isWalking", false);
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            isLeft = false;
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            isLeft = true;
        }
    }

    void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
