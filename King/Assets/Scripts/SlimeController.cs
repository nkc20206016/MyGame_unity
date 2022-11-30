using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    Rigidbody2D rb;//rigidbody2D
    float moveForce=1; //速度
    float runThreshold = 3.0f;   // 速度切り替え判定のための閾値
    float runForce = 6f;　　　　　//走り初めに加える力
    string state;
    int reverce=-1;//向き切り替え
    int x=1;//localScalのｘ座標
    int count;//壁に当たった回数
    float jumpForce = 420.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -8.393365)
        {
            transform.position = new Vector3(-8.393365f, transform.position.y, transform.position.z);
        }

        Move();
        Swich();
        
    }

    void Move()
    {
        transform.localScale = new Vector2(reverce, 1);
       
        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb.velocity.x);
        if (speedX < this.runThreshold)
        {
            this.rb.AddForce(-transform.right * runForce*reverce); //未入力の場合は key の値が0になるため移動しない
        }
        else
        {
            this.transform.position += new Vector3(moveForce * Time.deltaTime * -reverce, 0, 0);
        }



        if (count == 0)
        {
            state = "Idle";
        }
        if(count==1)
        {
            state = "Reverce";
        }
        if (count >= 2)
        {
            count = 0;
        }

    }

    void Swich()
    {
        switch (state)
        {
            case"Reverce":
                reverce = 1;
                break;
            case "Idle":
                reverce = -1;
                break;
            default:
                reverce = 1;
                break;
        }
            
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground"|| col.gameObject.tag == "Player" )
        { 
            count++;
            
        }

        
 
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Jump")
        {
            this.rb.AddForce(transform.up * this.jumpForce);
        }

        if (col.gameObject.tag == "Damage")
        {
            FadeManager.Instance.LoadScene("GameOverScene", 0.5f);
        }
    }
}
