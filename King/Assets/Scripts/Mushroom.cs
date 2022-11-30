using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mushroom : MonoBehaviour
{
    public bool Attack;
    public int Hp=100;//マッシュルームのHP
    GameObject player;
    GameObject slime;

    Vector2 targetPos;
    public bool damagestate;
    float damage=5f;
    private Rigidbody2D rb2d;

    float moveForce = 1; //速度
    float runThreshold = 3.0f;   // 速度切り替え判定のための閾値
    float runForce = 6f;     //走り初めに加える力

    Animator anim;

    float dis;

    float reverce=0.1f;

    Slider PlayerHP;
    Slider SlimeHP;
    PlayerController playerScripts;

    
    BoxCollider2D boxcol2d;

 
    string state;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
       
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
       
        player = GameObject.Find("Player");
        slime = GameObject.Find("Slime");
        playerScripts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
        SlimeHP = GameObject.Find("SlimeHP").GetComponent<Slider>();

        boxcol2d = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Anime();
       

        Vector3 posA = this.transform.position;
        Vector3 posB = slime.transform.position;
        Vector3 posC = player.transform.position;
        float dis = Vector3.Distance(posA, posB);
        float disB = Vector3.Distance(posA, posC);

        if(dis<15 || disB < 15)
        {
            this.state = "Run";
            EnemyMove();
        }

        if (dis < 3||disB<3)
        {
            this.state = "Attack";
        }

        HP();

       

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
        state = "Death";
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        boxcol2d.enabled = false;
        //3秒停止
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }

    void Anime()
    {
        switch (state) 
        {
            case"Run":
                anim.SetBool("run", true);
                anim.SetBool("attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                break;
            case "Attack":
                anim.SetBool("attack", true);
                anim.SetBool("Idle", false);
                anim.SetBool("run", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                break;
            case "Hit":
                anim.SetBool("Hit", true);
                anim.SetBool("attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("run", false);
                anim.SetBool("Death", false);
                break;
            case "Death":
                anim.SetBool("Death", true);
                anim.SetBool("Hit", false);
                anim.SetBool("attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("run", false);
                break;
            default:
                anim.SetBool("Idle", true);
                anim.SetBool("attack", false);
                anim.SetBool("run", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                break;
        }

    }

    void EnemyMove()
    {
       
       
        Vector3 MushPos = this.transform.position;
        Vector3 slimePos = slime.transform.position;
        Vector3 playerPos = player.transform.position;
        float disA = Vector3.Distance(MushPos, slimePos);
        float disB = Vector3.Distance(MushPos, playerPos);

        if (disA < disB)
        {
            targetPos = slimePos;
        }
        else if(disA>disB)
        {
            targetPos = playerPos;
        }

        if (targetPos.x + 1 < MushPos.x)
        {
            dis = -1;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (targetPos.x - 1 > MushPos.x)
        {
            dis = 1;
            this.transform.localScale = new Vector3(1, 1, 1);
        }




        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb2d.velocity.x);
        if (speedX < this.runThreshold)
        {
            this.rb2d.AddForce(transform.right * runForce * dis); //未入力の場合は key の値が0になるため移動しない
        }
        else
        {
            this.transform.position += new Vector3(moveForce * Time.deltaTime * dis* 1, 0, 0);
        }

    }

  

    void OnTriggerEnter2D(Collider2D col)
    {
        if (Attack == true)
        {
            if (col.gameObject.tag == "Player")
            {
                PlayerHP.value -= playerScripts.Mushdamage;
            }

            if (col.gameObject.tag == "Slime")
            {
                SlimeHP.value -= damage;
            }
        }
        
    }
}