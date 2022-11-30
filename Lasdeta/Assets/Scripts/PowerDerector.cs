using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDerector : MonoBehaviour
{
    //最大ポイントと現在のポイント
    public int maxP=10000;
    public float currentP;
    float wpowerdown = 1.0f;
    float bpowerdown = 2.5f;

    //Sliderを入れる
    public Slider slider;
    public GameObject lp;
    public GameObject bbc;

    LPlayer lPlayer;
    BBcreate bbcreate;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タン
        slider.value = 1;
        //現在のPと最大Pと同じに
        currentP = maxP;

        lPlayer = lp.GetComponent<LPlayer>();
        bbcreate =bbc.GetComponent<BBcreate>();
    }

    void Bpower()
    {
            currentP = currentP - wpowerdown;
            slider.value = (float)currentP / (float)maxP;
    }

    void Wpower()
    {
            currentP = currentP - bpowerdown;
            slider.value = (float)currentP / (float)maxP;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentP <= 0)
        {
            currentP = 0;
        }

        if (lPlayer.Wpower == true)
        {
            Bpower();
        }

        if (bbcreate.Bpower == true)
        {
            Wpower();
        }
    }
}
