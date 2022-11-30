using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDerector : MonoBehaviour
{
    public GameObject bplayer;
    public GameObject lplayer;
    public GameObject lworld;
    public GameObject dworld;
    public GameObject lLoad;
    public GameObject dLoad;
    public GameObject Fade;
    public GameObject LFade;
    public GameObject doar;
    public GameObject doar1;
    public GameObject doar2;

    public GameObject[] BW;
    public GameObject[] RW;

    public AudioClip sound;

    MainDPlayer bscript;
    MainLPlayer lscript;
    Fade dFscript;
    LFade lFscript;
    AudioSource audioSource;

    bool dfadeTrigger = false;
    bool lfadeTrigger = false;

    Vector3 bpos = Vector3.zero;
    Vector3 rpos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject型の配列BBに"bb"タグのついたオブジェクトを全て格納
        //Startで非アクティブでもオブジェクトを取得
        BW = GameObject.FindGameObjectsWithTag("bw");

        RW = GameObject.FindGameObjectsWithTag("rw");

        bplayer = GameObject.Find("Dplayer");
        lplayer = GameObject.Find("Lplayer");

        lworld = GameObject.Find("Lworld");
        dworld = GameObject.Find("Dworld");

        lLoad = GameObject.Find("LLoad");
        dLoad = GameObject.Find("DLoad");

        bscript = bplayer.GetComponent<MainDPlayer>();
        lscript = lplayer.GetComponent<MainLPlayer>();

        dFscript = Fade.GetComponent<Fade>();
        lFscript = LFade.GetComponent<LFade>();

        audioSource = GetComponent<AudioSource>();

        foreach (GameObject rw in RW)
        {
            rw.SetActive(false);
        }

        lplayer.SetActive(false);
        dworld.SetActive(false);
        dLoad.SetActive(false);

        doar1.SetActive(false);
        doar2.SetActive(false);

    }

    void Dworld()
    {
        dFscript.isFadeOut = true;

        dfadeTrigger = true;
        bscript.Trigger = false;

        foreach (GameObject bw in BW)
        {
            bw.SetActive(false);
        }

        //activeSelfでsetsctiveの状態をboolで判定
        bplayer.SetActive(false);
        if (bplayer.activeSelf == false)
        {
            lplayer.SetActive(true);
            lplayer.transform.position = bpos;


            foreach (GameObject rw in RW)
            {
                rw.SetActive(true);
            }

            doar.SetActive(false);
            doar1.SetActive(true);
            doar2.SetActive(true);
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

            foreach (GameObject bw in BW)
            {
                bw.SetActive(true);
            }

        }

        doar.SetActive(true);
        doar1.SetActive(false);
        doar2.SetActive(false);
        audioSource.PlayOneShot(sound);

        //背景切り替え
        dworld.SetActive(false);
        lworld.SetActive(true);

        //足場切り替え
        dLoad.SetActive(false);
        lLoad.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

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
