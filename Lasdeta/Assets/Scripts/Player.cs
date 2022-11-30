using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bkey;

    public float speed = 1f;
    float move = 0;
    float jumpPower = 300f;
    int jumpCount = 0;

    public bool Trigger = false;
    public bool BKeyTrigger = false;

    Rigidbody2D rb2;


    public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground"||collision.gameObject.tag=="bb"||collision.gameObject.tag=="cb")
        {
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "BKey")
        {
            Destroy(Bkey);
            BKeyTrigger = true;
            audioSource.PlayOneShot(sound);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bw")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Trigger = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        move = Input.GetAxisRaw("Horizontal");
        if (move > 0)
        {
            rb2.velocity = new Vector2(speed, rb2.velocity.y);
        }
        else if (move < 0)
        {
            rb2.velocity = new Vector2(-speed, rb2.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            rb2.velocity = new Vector2(0, 0);
        }

        if (jumpCount == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb2.AddForce(new Vector3(0, jumpPower, 0));
                jumpCount++;
            }
        }

    }
}
