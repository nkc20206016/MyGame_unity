using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    bool block_touch;
    float fallcount;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fallcount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "slime")
        {
            fallcount = 0;
            block_touch = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //触れたら
        if (block_touch == true)
        {
            fallcount += Time.deltaTime;

            Invoke("Fall", 1);
        }
    }
    void Fall()
    {
        
        //5秒後に消滅
        if (fallcount >= 4.0f) Destroy(this.gameObject);

        rb2d.gravityScale = 1;
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
