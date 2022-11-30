using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Charactor : MonoBehaviour
{
    /*
     * 生成されたらRamdomで移動する方向を決める
     * 決め方はRamdomで決められた数値を
     * switchに割り当てる
     * 
     * 画面外に出たら破棄する
     */

    //Randomの最大値と最小値
    int RandomMax = 9;
    int RandomMin = 1;

    //Ramdomで決まった数値を保存
    int RandomSelect = 0;

    //プレイヤーが動くスピードを変えるランダム
    int RandomSMin = 1;
    int RandomSMax = 4;

    //スピードランダムの数値を保存
    int RandomSpeed = 0;

    //Playerが動くための力
    float Speed = 0.0f;     //横に動く力
    float UPSpeed = 1.0f;   //上に上がる力
    float DWSpeed = -1.0f;  //下に下がる力

    //位置情報取得用
    Vector3 Ptrans = Vector3.zero;

    //オブジェクトが消えるまでのカウント
    float time = 0;
    float Dtime = 20;

    //このオブジェクトの名前を取得する
    string this_name;

    //移動配置用の座標
    private Vector3 p1 = new Vector3(-12.0f, -0.25f, 0.0f);
    private Vector3 p2 = new Vector3(-10.0f, 6.5f, 0.0f);
    private Vector3 p3 = new Vector3(-0.06f, 6.5f, 0.0f);
    private Vector3 p4 = new Vector3(11.0f, 5.7f, 0.0f);
    private Vector3 p5 = new Vector3(11.7f, 0.5f, 0.0f);
    private Vector3 p6 = new Vector3(11.9f, -5.8f, 0.0f);
    private Vector3 p7 = new Vector3(0.03f, -7.1f, 0.0f);
    private Vector3 p8 = new Vector3(-9.84f, -6.0f, 0.0f);

    Animator anime;
    Rigidbody2D rb2d;

    private void Awake()
    {
        //1から9の値をランダムでだす
        RandomSelect = Random.Range(RandomMin, RandomMax);

        //1から4の値をランダムでだす
        RandomSpeed = Random.Range(RandomSMin, RandomSMax);
        //Debug.Log(RandomSelect);
    }

    // Start is called before the first frame update
    void Start()
    {
        //コライダー取得
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        //現在地を所得
        Ptrans = this.gameObject.transform.position;

        //このスクリプトがアタッチされたオブジェクトの名前を取得
        this_name = this.gameObject.name;

        //初期位置へ移動するメソッド
        PlayerStartPosition();

        //名前を参照しanimationする
        PlayerName();
    }

    void PlayerName()
    {
        if (this_name == "Play1(Clone)") anime.SetBool("play1", true);
        if (this_name == "Play2(Clone)") anime.SetBool("play2", true);
        if (this_name == "Play3(Clone)") anime.SetBool("play3", true);
        if (this_name == "Play4(Clone)") anime.SetBool("play4", true);
    }

    private void PlayerStartPosition()
    {
        switch (RandomSelect)
        {
            //最初の座標へ
            case 1:
                //真ん中の左へ移動
                Ptrans = p1;
                this.gameObject.transform.position = Ptrans;
                break;
            case 2:
                //斜め左上
                Ptrans = p2;
                this.gameObject.transform.position = Ptrans;
                break;
            case 3:
                //中央の上
                Ptrans = p3;
                this.gameObject.transform.position = Ptrans;
                break;
            case 4:
                //斜め右上
                Ptrans = p4;
                this.gameObject.transform.position = Ptrans;
                //向きを逆にする
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 5:
                //真ん中の右
                Ptrans = p5;
                this.gameObject.transform.position = Ptrans;
                //向きを逆にする
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 6:
                //斜め右下
                Ptrans = p6;
                this.gameObject.transform.position = Ptrans;
                //向きを逆にする
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 7:
                //中央の下
                Ptrans = p7;
                this.gameObject.transform.position = Ptrans;
                //向きを逆にする
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 8:
                //斜め左下
                Ptrans = p8;
                this.gameObject.transform.position = Ptrans;
                break;

            default:
                Destroy(this.gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //プレイヤーのスピードを変化
        switch (RandomSpeed)
        {
            case 1: Speed = 1.0f;
                break;
            case 2: Speed = 2.0f;
                break;
            case 3: Speed = 3.0f;
                break;
            default: Speed = 1.0f;
                break;
        }

        //対象となる座標へ移動
        switch (RandomSelect)
        {
            case 1:
                //真ん中右へ移動
                rb2d.velocity = new Vector3(Speed, 0.0f, 0.0f);
                time +=Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 2:
                //斜め右下へ移動
                rb2d.velocity = new Vector3(Speed, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 3:
                //中央下へ移動
                rb2d.velocity = new Vector3(0.0f, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 4:
                //斜め左下へ移動
                rb2d.velocity = new Vector3(-Speed, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 5:
                //真ん中左へ移動
                rb2d.velocity = new Vector3(-Speed, rb2d.velocity.y, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 6:
                //斜め左上へ移動
                rb2d.velocity = new Vector3(-Speed, UPSpeed , 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 7:
                rb2d.velocity = new Vector3(0.0f, UPSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                //中央上へ移動
                break;
            case 8:
                //斜め右上へ移動
                rb2d.velocity = new Vector3(Speed, UPSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;

            default : Destroy(this.gameObject);
                break;
        }
    }

}
