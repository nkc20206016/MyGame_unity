using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSystemManager : MonoBehaviour
{
    /*
     * やるｋと
     * 音をつける
     * 
    */ 

    //キャラクターの種類を決めるランダム用の最大値と最小値
    int RandomMin = 1;
    int RandomMax = 5;

    //キャラクターの種類を決めるランダムで決定した数値を保存
    int RandomSelect = 0;

    //キャラクターの種類の答えを決定するランダム用の最大値と最小値
    int RandomAnswerMin = 1;
    int RandomAnswerMax = 9;

    //答えの数を決めるランダムで決定した数値の答えを保持
    int RandomAnswer = 0;

    //生成更新用の数値
    float intervalf = 2.0f;
    float intervals = 3.0f;
    float intervalt = 4.0f;

    //生成カウント
    int count = 0;

    //生成終了までかかる時間
    float time = 0.0f;

    //生産終了までの最大時間
    float maxtime = 0.0f;

    //text拡大のカウント
    float text_time = 0;

    //タイマースタートflag
    bool StartTime = false;

    //Starttext拡大用フラグ
    bool textbuff = false;

    //生成するPlayerを取得用の値
    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;

    //表示するUI
    [SerializeField] GameObject CImage;
    [SerializeField] GameObject CImage2;

    //UI取得用
    Image image;
    Image image2;

    //inputFieldの親オブジェクト
    [SerializeField] GameObject answer;
    //答えを入力するinputField
    [SerializeField] InputField answerField;
    [SerializeField] Text Ntext;

    //ResultPanel
    //Buttonの親オブジェクト
    [SerializeField] GameObject select;

    //タイマー表示Text取得
    [SerializeField] Text Timertext;

    //startの掛け声用
    [SerializeField] Text Starttext;

    //Panelを取得用
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject ResultPanel;
    [SerializeField] GameObject CollationPanel;

    //答えるプレイヤーの画像を表示
    [SerializeField] Sprite Player1image;
    [SerializeField] Sprite Player2image;
    [SerializeField] Sprite Player3image;
    [SerializeField] Sprite Player4image;

    //Audiosorceを取得して音源を再生
    AudioSource audioSource;
    public AudioClip raedy;
    public AudioClip go;
    public AudioClip click;
    public AudioClip hue;
    public AudioClip Out;
    public AudioClip hakusyu;


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ランダム生成
        RandomSelect = Random.Range(RandomMin, RandomMax);
        RandomAnswer = Random.Range(RandomAnswerMin, RandomAnswerMax);
        
        //prefabであるPlayer達を取得
        Player1 = (GameObject)Resources.Load("Play1");
        Player2 = (GameObject)Resources.Load("Play2");
        Player3 = (GameObject)Resources.Load("Play3");
        Player4 = (GameObject)Resources.Load("Play4");

        //AudioSource
        audioSource = GetComponent<AudioSource>();

        //Imageを取得
        image = CImage.GetComponent<Image>();
        image2 = CImage2.GetComponent<Image>();

        //答えるキャラを表示するためのメソッド呼び出し
        CharactorIndication();

        //ResultPanelを非表示に
        ResultPanel.SetActive(false);
        CollationPanel.SetActive(false);
        //ResultPanelのButtonを非表示
        select.SetActive(false);

        Debug.Log(RandomAnswer);
    }

    private void FixedUpdate()
    {
        //終了までのタイマー開始
        if (StartTime == true)
        {
            time += Time.deltaTime;
            Timertext.text = time.ToString("f1"); //小数第1位まで表示
        }

        //タイマーが30秒を超えたらInvokeを全停止し、画面内の残ったPlayerを削除、タイマー停止
        if (time > maxtime)
        {
            CancelInvoke();
            StartTime = false;
            time = 0;
            //タグで見つけたobjをDobjectに入れ、それをPDestroyの中に入れforeachで繰り返す
            GameObject[] Dobject = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject PDestroy in Dobject)
            {
                Destroy(PDestroy);
            }
            //コルーチンを使う
            StartCoroutine("Resultct");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //textを時間経過で拡大する
        if (textbuff == true)
        {
            text_time += Time.deltaTime;
            //2秒以下なら拡大
            if (text_time < 2) Starttext.fontSize += 1;
            //4秒超えたら文字を変える
            if (text_time > 4)
            { 
                Starttext.text = "GO";
            }
            //5秒超えたらリセット
            if (text_time > 5)
            {
                text_time = 0;
                textbuff = false;
            }
        }
    }


    //Button
    //StartButtonが押された時
    public void StartButton()
    {
        //SE
        audioSource.PlayOneShot(click);

        //Panelを非表示に
        StartPanel.SetActive(false);

        //コルーチン呼び出し
        StartCoroutine("GameStart");

        //ReadyのSE用のInvock
        Invoke("Ready", 0.5f);
    }

    void Ready(){
        audioSource.PlayOneShot(raedy);
        Invoke("Go", 3.5f);
    }
    void Go()
    {
        audioSource.PlayOneShot(go);
    }

    //titleに戻るボタン
    public void Title()
    {
        //SE
        audioSource.PlayOneShot(click);

        //titleに戻る処理
        FadeManager.Instance.LoadScene("TitleScene",1.0f);
    }

    //シーンをロードしてやり直し
    public void Reset()
    {
        //SE
        audioSource.PlayOneShot(click);

        //シーンをロードする処理
        //現在のシーンを取得
        Scene loadScene = SceneManager.GetActiveScene();
        FadeManager.Instance.LoadScene(loadScene.name,1.0f);
    }

    //生成すべきエネミーの選択と生成指示
    public void SelectFactory()
    {
        //エネミーの生成はできそう
        //InvokeRepeatingは動き続ける　固定生成には使える
        switch (RandomSelect)
        {
            case 1:
                //エネミーを生成
                InvokeRepeating("Player2Factory", 1.0f, intervalf);
                InvokeRepeating("Player3Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 2:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player3Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 3:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player2Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 4:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player2Factory", 2.0f, intervals);
                InvokeRepeating("Player3Factory", 3.0f, intervalt);
                break;
            default:
                break;
        }
    }

    //答えるキャラクターを表示するメソッド
    void CharactorIndication()
    {
        switch (RandomSelect)
        {
            //キャラクターイメージを表示
            case 1:
                image.sprite = Player1image;
                image2.sprite = Player1image;
                Debug.Log(RandomSelect);
                break;
            case 2:
                image.sprite = Player2image;
                image2.sprite = Player2image;
                Debug.Log(RandomSelect);
                break;
            case 3:
                image.sprite = Player3image;
                image2.sprite = Player3image;
                Debug.Log(RandomSelect);
                break;
            case 4:
                image.sprite = Player4image;
                image2.sprite = Player4image;
                Debug.Log(RandomSelect);
                break;
            default:
                break;

        }
    }

    void PlayerAnswerSelectF()
    {
        switch (RandomSelect)
        {
            case 1://一定時間間隔で処理を実行　これで時間を空けてプレハブを生成できる
                   //第一引数に実行したいメソッド名、第二に最初に起動する時間、第三に更新する時間
                InvokeRepeating("PASF1", 1.0f, intervalf);
                break;
            case 2:
                InvokeRepeating("PASF2", 1.0f, intervalf);
                break;
            case 3:
                InvokeRepeating("PASF3", 1.0f, intervalf);
                break;
            case 4:
                InvokeRepeating("PASF4", 1.0f, intervalf);
                break;
            default:
                break;
        }
    }

    //お邪魔エネミー作成する
    void Player1Factory()
    {
        Instantiate(Player1, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player2Factory()
    {
        Instantiate(Player2, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player3Factory()
    {
        Instantiate(Player3, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player4Factory()
    {
        Instantiate(Player4, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    //答えるべきPlayerを生成する
    void PASF1()
    {
        count += 1;
        //キャラクターを生成
        Instantiate(Player1, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        //countがanswerと同じになったらinvokeを停止
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF1");
        }
    }

    void PASF2()
    {
        count += 1;
        Instantiate(Player2, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF2");
        }
    }

    void PASF3()
    {
        count += 1;
        Instantiate(Player3, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF3");
        }
    }

    void PASF4()
    {
        count += 1;
        Instantiate(Player4, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF4");
        }
    }

    //Startが押されたら、文字を表示して始めるためのコルーチン
    IEnumerator GameStart()
    {
        //txetのスケールを徐々に大きくしてそれっぽく見せる
        textbuff = true;

        //スタートの告知　できればtextをアニメーションぽくしたい
        yield return new WaitForSeconds(5f);

        //Starttextを非表示に
        Starttext.enabled = false;

        //スタート告知の呼び出し
        PlayerAnswerSelectF();
        SelectFactory();

        //タイマースタート
        StartTime = true;
    }

    //Result用のコルーチン
    IEnumerator Resultct()
    {
        //textを書き換えて終わりを知らせる
        Starttext.text = "終了";
        Starttext.enabled = true;

        //終了ホイッスル
        audioSource.PlayOneShot(hue);

        //二秒後にResultPanelを表示する
        yield return new WaitForSeconds(2f);

        ResultPanel.SetActive(true);
    }

    //入力された数値があっているかどうか
    public void Answer()
    {
        //入力された文字列を数値に変えて答えと照合
        int answern = int.Parse(answerField.text);
        if (answern == RandomAnswer)
        {
            CollationPanel.SetActive(true);
            audioSource.PlayOneShot(hakusyu);
            Debug.Log("a");
        }
        else
        {
            Ntext.text = "残念…もう一度か、タイトルに戻ってね。";
            audioSource.PlayOneShot(Out);

            //Button出現
            select.SetActive(true);
            answer.SetActive(false);

            Debug.Log("no");
        }
    }

    //シーンが呼ばれたときに呼ばれる
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //scene名で難易度変更
        if (SceneManager.GetActiveScene().name == "EasyCount")
        { maxtime = 30.0f; }
        if (SceneManager.GetActiveScene().name == "NormalCount")
        {
            //時間の最大値
            maxtime = 15.0f;

            //answerの最小値を変更
            RandomAnswerMin = 7;
            RandomAnswerMax = 11;

            //Enemyのインターバルを変更
            intervalf = 1.0f;
            intervals = 1.5f;
            intervalt = 2.0f;

        }
    }
}