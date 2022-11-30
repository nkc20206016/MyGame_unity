using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDerector : MonoBehaviour
{
    public GameObject bplayer;
    public GameObject lplayer;
    public GameObject lworld;
    public GameObject dworld;
    public GameObject lLoad;
    public GameObject dLoad;
    public GameObject Fade;
    public GameObject LFade;
    public GameObject BBC;
    public GameObject doar;
    public AudioClip sound;

    public GameObject[] BB;
    public GameObject[] BW;
    public GameObject[] RB;
    public GameObject[] RW;
    public GameObject[] CB;
    public GameObject BK;
    public GameObject WK;
    public GameObject BL;
    public GameObject BS;

    Player bscript;
    LPlayer lscript;
    Fade dFscript;
    LFade lFscript;
    BBcreate bbc;
    Dswitch ds;
    AudioSource audioSource;

    bool dfadeTrigger = false;
    bool lfadeTrigger = false;
    public bool SetTrigger;

    Vector3 bpos = Vector3.zero;
    Vector3 rpos = Vector3.zero;

    private void Awake()
    {
        //GameObject型の配列BBに"bb"タグのついたオブジェクトを全て格納
        //Startで非アクティブでもオブジェクトを取得
        BB = GameObject.FindGameObjectsWithTag("bb");
        BW = GameObject.FindGameObjectsWithTag("bw");
        RB = GameObject.FindGameObjectsWithTag("rb");
        RW = GameObject.FindGameObjectsWithTag("rw");
    }
    // Start is called before the first frame update
    void Start()
    {

        bplayer = GameObject.Find("DPlayer");
        lplayer = GameObject.Find("LPlayer");

        lworld = GameObject.Find("Lworld");
        dworld = GameObject.Find("Dworld");

        lLoad = GameObject.Find("LLoad");
        dLoad = GameObject.Find("DLoad");


        bscript = bplayer.GetComponent<Player>();
        lscript = lplayer.GetComponent<LPlayer>();

        dFscript = Fade.GetComponent<Fade>();
        lFscript = LFade.GetComponent<LFade>();

        ds = BS.GetComponent<Dswitch>();

        audioSource = GetComponent<AudioSource>();

        bbc = BBC.GetComponent<BBcreate>();
        //Lの物質をfalseに
        foreach (GameObject rb in RB)
        {
            rb.SetActive(false);
        }
        foreach (GameObject rw in RW)
        {
            rw.SetActive(false);
        }

        lplayer.SetActive(false);
        dworld.SetActive(false);
        dLoad.SetActive(false);

        WK.SetActive(false);

        //Debug.Log(SetTrigger);
    }

    void Dworld()
    {
        dFscript.isFadeOut = true;

        dfadeTrigger = true; 
        bscript.Trigger = false;

        SetTrigger = false;

        foreach (GameObject bb in BB)
        {
            bb.SetActive(false);
        }
        foreach (GameObject bw in BW)
        {
            bw.SetActive(false);
        }
        foreach (GameObject cb in CB)
        {
            cb.SetActive(false);
        }

        if (ds.DBtrigger != true)
        {
            BL.SetActive(false);
            BS.SetActive(false);
        }


        //activeSelfでsetsctiveの状態をboolで判定
        bplayer.SetActive(false);
        if (bplayer.activeSelf == false)
        {
            lplayer.SetActive(true);
            lplayer.transform.position = bpos;

            foreach (GameObject rb in RB)
            {
                rb.SetActive(true);
            }
            foreach (GameObject rw in RW)
            {
                rw.SetActive(true);
            }

            if (bscript.BKeyTrigger != true)
            {
                BK.SetActive(false);
            }
            if (lscript.WKeyTrigger != true)
            {
                WK.SetActive(true);
            }

            doar.SetActive(false);
            audioSource.PlayOneShot(sound);

            //背景切り替え
            lworld.SetActive(false);
            dworld.SetActive(true);

            //足場切り替え
            lLoad.SetActive(false);
            dLoad.SetActive(true);

        }
    }

    void Lworld()
    {

        lFscript.isFadeOut = true;

        lfadeTrigger = true;
        lscript.trigger = false;
        SetTrigger = true;
        bbc.Setcatch();


        if (ds.DBtrigger != true)
        {
            BL.SetActive(true);
            BS.SetActive(true);
        }
        foreach (GameObject rb in RB)
        {
            rb.SetActive(false);
        }
        foreach (GameObject rw in RW)
        {
            rw.SetActive(false);
        }

        //変更点
        lplayer.SetActive(false);

        if (lplayer.activeSelf == false)
        {
            bplayer.SetActive(true);
            bplayer.transform.position = rpos;
            foreach (GameObject bb in BB)
            {
                bb.SetActive(true);
            }
            foreach (GameObject bw in BW)
            {
                bw.SetActive(true);
            }

        }
        if (bscript.BKeyTrigger != true)
        {
            BK.SetActive(true);
        }
        if (lscript.WKeyTrigger != true)
        {
            WK.SetActive(false);
        }
        doar.SetActive(true);
        audioSource.PlayOneShot(sound);

        //背景切り替え
        dworld.SetActive(false);
        lworld.SetActive(true);

        //足場切り替え
        dLoad.SetActive(false);
        lLoad.SetActive(true);
    }

    void LoadS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    // Update is called once per frame
    void Update()
    {
        CB = GameObject.FindGameObjectsWithTag("cb");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(sound);
            LoadS();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FadeManager.Instance.LoadScene("Main", 1.0f);
        }

        //bplayerの現在位置
        if (bplayer.activeSelf == true)
        {
            bpos = bplayer.transform.position;
        }
        //lplayerの現在位置
        if (lplayer.activeSelf == true)
        {
            rpos = lplayer.transform.position;
        }

        //世界間切り替え
        //影の世界
        if (bscript.Trigger == true)
        {
            Dworld();
        }
        //光の世界
        if (lscript.trigger == true)
        {
            Lworld();
        }
        //フェードin
        if (dfadeTrigger == true)
        {
            dFscript.isFadeIn = true;
        }
        if (lfadeTrigger == true)
        {
            lFscript.isFadeIn = true;
        }
    }
}
