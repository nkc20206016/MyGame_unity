using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLPlayer : MonoBehaviour
{
    public float speed = 1f;
    float move = 0;
    float jumpPower = 300f;
    int jumpCount = 0;
    GameObject Light;

    public bool trigger = false;

    Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rw")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("C");
                trigger = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (move > 0)
        {
            rb2.velocity = new Vector2(speed, rb2.velocity.y);
        }
        else if (move < 0)
        {
            rb2.velocity = new Vector2(-speed, rb2.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rb2.velocity = new Vector2(0, 0);
        }

        if (jumpCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2.AddForce(new Vector3(0, jumpPower, 0));
                jumpCount++;
            }
        }
    }
}
