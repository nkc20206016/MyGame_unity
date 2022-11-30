using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject player;
    public GameObject bomb;
    private float targetTime = 5.5f;
    private float currentTime = 0;
    float speed = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posA = this.transform.position;
        Vector3 posB = player.transform.position;
        float dis = Vector2.Distance(posA, posB);


        if (dis < 15)
        {
            Attack();
        }
    }

    void Attack()
    {
       
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;

            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;

            //弾のプレハブを作成
            var t = Instantiate(bomb) as GameObject;

            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;

            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vec = player.transform.position - pos;

            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody2D>().velocity = vec * speed;
        }
    } 
}
