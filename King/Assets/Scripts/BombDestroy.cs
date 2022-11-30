using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private Animator anim;
    public string state;
    private Rigidbody2D rb2d;
    float speed = 0f;
    float timer = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Anime();
    }

    void Anime()
    {
        switch (state)
        {
            case "Attack2":         
                anim.SetBool("Attack2", true);
                anim.SetBool("Idle", false);
                break;
            default:
                anim.SetBool("Idle", true);
                anim.SetBool("Attack2", false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            state = "Attack2";
            Destroy(this.gameObject, timer);
            rb2d.velocity = Vector2.zero; 
        }

        if (collision.gameObject.tag == "Player")
        {
            state = "Attack2";
            Destroy(this.gameObject, timer);
            rb2d.velocity = Vector2.zero;
        }
    }


}
