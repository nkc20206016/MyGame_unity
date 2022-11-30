using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoltDetroy : MonoBehaviour
{
    GameObject player;
    GameObject eye;
    PlayerController playerScripts;
    Slider PlayerHP;
    Slider SlimeHP;

    Bolt boltScripts;
    int reverce = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
        SlimeHP = GameObject.Find("SlimeHP").GetComponent<Slider>();
        boltScripts = GameObject.FindWithTag("Bolt").GetComponent<Bolt>();
        playerScripts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Reverce();

        Vector3 posA = transform.position;
        Vector3 posB = player.transform.position;
        Vector3 dist = (posA - posB).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.right*reverce, dist);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Reverce()
    {
        StartCoroutine(Breake());

        Vector2 targetPos = player.transform.position;

        Vector2 EyePos = this.transform.position;

        //敵からプレイヤーに向かうベクトルをつくる
        //プレイヤーの位置から敵の位置（弾の位置）を引く
        if (targetPos.x+1 > EyePos.x)
        {
            reverce = -1;
            this.transform.localScale = new Vector3(reverce, 1, 1);
        }
        else if (targetPos.x - 1 < EyePos.x)
        {
            reverce = 1;
            this.transform.localScale = new Vector3(reverce, 1, 1);
        }

       
    }

    IEnumerator Breake()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHP.value -= playerScripts.Eyedamage;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Slime")
        {
            SlimeHP.value -= boltScripts.damage;
            Destroy(this.gameObject);
        }
    }
}
