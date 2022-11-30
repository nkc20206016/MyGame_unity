using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    GameObject player;

    GameObject goblin;
    
    private Rigidbody2D rb2d;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        goblin = GameObject.FindGameObjectWithTag("Goblin");

        
    
    }

    void Update()
    {
        Vector3 posA = goblin.transform.position;
        Vector3 posB = player.transform.position;
        float dis = Vector3.Distance(posA, posB);

        if (dis < 15)
        {
            EnemyMove();
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (dis < 3)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    
    void EnemyMove()
    {
        
        Vector2 targetPos = player.transform.position;

        Vector2 GobPos = goblin.transform.position;
      
        float x = targetPos.x;

        float gobpos = GobPos.x;
       
        float y = 0;

        if (x > gobpos)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }

        if (x < gobpos)
        {
            transform.localScale = new Vector3(5, 5, 1);
        }

        // 移動を計算させるための２次元のベクトルを作る
        Vector2 direction = new Vector2(
            x - transform.position.x, y).normalized;

        // ENEMYのRigidbody2Dに移動速度を指定する
        rb2d.velocity = direction * 3;
    }

}