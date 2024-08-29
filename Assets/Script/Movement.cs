using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    int speed;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
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
        rb.velocity = new Vector2(0,0);
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed,0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
