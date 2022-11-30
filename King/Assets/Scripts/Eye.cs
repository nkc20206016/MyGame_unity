using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eye : MonoBehaviour
{
    GameObject player;

    private Rigidbody2D rb2d;

    private Animator anim;

    int reverce;
    int reverceY=-1;

    int stop;

    Slider PlayerHP;

    int damage = 5;

    BoxCollider2D boxcol2d;
    public bool damagestate;
    public int Hp = 200;

    public string state;

    Bolt bolt;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        boxcol2d = this.gameObject.GetComponent<BoxCollider2D>();
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
        bolt = GameObject.FindWithTag("Bolt").GetComponent<Bolt>();
        
    }

    void Update()
    {
        HP();
        Anime();
        

        Vector3 posA = new Vector2(this.transform.position.x, 0);
        Vector3 posB = new Vector2(player.transform.position.x,0);
        float dis = (posA - posB).magnitude;


        
        //Debug.Log(dis);
        if (dis<4)
        {
           
            stop = 1;
           
        }
        else
        {
            stop = 0;
            transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        }


        EnemyMove();

    }

    void HP()
    {
        if (damagestate)
        {

            this.state = "Hit";

        }
        

        if (Hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        rb2d.gravityScale = 10;
        reverce = 0;
        reverceY = 1;
        transform.localScale = new Vector3(1, -1, 1);
        state = "Death";
        yield return new WaitForSeconds(1f);
        boxcol2d.enabled = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        
        //3秒停止
        yield return new WaitForSeconds(3f);


        Destroy(this.gameObject);
    }

    void Anime()
    {
        switch (state)
        {
            case "Idle":
                anim.SetBool("Flight", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                break;
            case "Hit":
                anim.SetBool("Hit", true);
                anim.SetBool("Flight", false);
                anim.SetBool("Death", false);
                break;
            case "Death":
                Destroy(bolt);
                anim.SetBool("Death", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Flight", false);
                break;
            default:
                anim.SetBool("Flight", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                break;
        }
    }

    void EnemyMove()
    {
        Vector2 targetPos = player.transform.position;

        Vector2 EyePos = this.transform.position;
        Vector3 dist = (targetPos - EyePos).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.right * reverce, dist);


        float x = targetPos.x;

        float eyepos = EyePos.x;

        float y = 0;

        if (x+1 > eyepos)
        {
            state = "Idle";
            reverce = -1;
            transform.localScale = new Vector3(-1, reverceY, 1);
        }

        if (x-1 < eyepos)
        {
            state = "Idle";
            reverce = 1;
            transform.localScale = new Vector3(1, reverceY, 1);
        }

        // 移動を計算させるための２次元のベクトルを作る
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;

        //ENEMYのRigidbody2Dに移動速度を指定する
        rb2d.velocity = direction *stop * 1.5f;
        
    }

}