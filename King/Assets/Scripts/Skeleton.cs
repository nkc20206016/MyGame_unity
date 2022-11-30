using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    public bool attack;
    public int Hp=300;
    public bool damagestate;
    GameObject slime;
    GameObject player;
    PlayerController playerScripts;
    private Rigidbody2D rb2d;

    private Animator anim;

    int reverce;
    Vector2 targetPos;
    Slider PlayerHP;
    Slider SlimeHP;
    BoxCollider2D boxcol2d;
    public int damage = 20;
    float dis;
    float moveForce = 1; //速度
    float runThreshold = 3.0f;   // 速度切り替え判定のための閾値
    float runForce = 6f;     //走り初めに加える力

    //PlayerController playerScripts;

    public string state;
    void Start()
    {

        anim = this.gameObject.GetComponent<Animator>();

        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        boxcol2d = this.gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        slime = GameObject.FindGameObjectWithTag("Slime");
        playerScripts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
        SlimeHP = GameObject.Find("SlimeHP").GetComponent<Slider>();
        
    }

    void Update()
    {


        
        Vector3 posA = this.transform.position;
        Vector3 posB = slime.transform.position;
        Vector3 posC = player.transform.position;
        float dis = Vector3.Distance(posA, posB);
        float disB = Vector3.Distance(posA, posC);

        if (dis < 15 || disB < 15)
        {
            this.state = "walk";
            EnemyMove();
        }

        if (dis < 3 )
        {
            this.state = "Attack";

           

        }
        
        if(disB < 3)
        {
            if (player.transform.position.y > this.transform.position.y)
            {
                this.state = "Attack2";
            }
            else
            {
                this.state = "Attack";
            }
        }
        HP();

        Anime();
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
        this.state = "Death";
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
            case "Idle":
                anim.SetBool("Idle", true);
                anim.SetBool("Attack", false);
                anim.SetBool("walk", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                anim.SetBool("Attack2", false);
                break;
            case "walk":
                anim.SetBool("walk", true);
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                anim.SetBool("Attack2", false);
                break;
            case "Attack":
                anim.SetBool("Attack", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("Death", false);
                anim.SetBool("Attack2", false);
                break;
            case "Attack2":
                anim.SetBool("Attack2", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("Death", false);
                break;
            case "Hit":
                anim.SetBool("Hit", true);
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("Death", false);
                anim.SetBool("Attack2", false);
                break;
            case "Death":
                anim.SetBool("Death", true);
                anim.SetBool("Hit", false);
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("Attack2", false);
                break;
            default:
                anim.SetBool("Idle", true);
                anim.SetBool("Attack", false);
                anim.SetBool("walk", false);
                anim.SetBool("Hit", false);
                anim.SetBool("Death", false);
                anim.SetBool("Attack2", false);
                break;
        }
    }

    void EnemyMove()
    {
        Vector3 SkePos = this.transform.position;
        Vector3 slimePos = slime.transform.position;
        Vector3 playerPos = player.transform.position;
        float disA = Vector3.Distance(SkePos, slimePos);
        float disB = Vector3.Distance(SkePos, playerPos);

        if (disA < disB)
        {
            targetPos = slimePos;
        }
        else if (disA > disB)
        {
            targetPos = playerPos;
        }

        if (targetPos.x + 1 < SkePos.x)
        {
            dis = 1;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (targetPos.x - 1 > SkePos.x)
        {
            dis = -1;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }




        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb2d.velocity.x);
        if (speedX < this.runThreshold)
        {
            this.rb2d.AddForce(transform.right * runForce * dis); //未入力の場合は key の値が0になるため移動しない
        }
        else
        {
            this.transform.position += new Vector3(moveForce * Time.deltaTime * dis * 1, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (attack == true)
        {
            if (col.gameObject.tag == "Slime")
            {
                SlimeHP.value -= damage;
            }

            if (col.gameObject.tag == "Player")
            {
                PlayerHP.value -= playerScripts.Skedamage;
            }
        }
        

       
    }
}