using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTS0 : MonoBehaviour  
{
    public bool potisionTrigger = false;
    [SerializeField] GameObject savetext;

    public static Vector3 Ppos;
    public static Vector3 Spos;
    Slider playerHP;
    Slider slimeHP;
    RespawnDerector rd;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rd = GameObject.Find("RespawnDerector").GetComponent<RespawnDerector>();
        playerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
        slimeHP = GameObject.Find("SlimeHP").GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" )
        {
            //位置情報を保存
            if (potisionTrigger == false)
            {
                audioSource.Play();
                slimeHP.value = 200;
                playerHP.value = 200;
                savetext.SetActive(true);
                RespawnDerector.point = 1;
                potisionTrigger = true;



            }
        }



    }

    public void ReapawnPoint()
    {
        Transform Ptransform = this.transform;
        Transform Stransform =this.transform;

        //位置情報を保存
        Ppos = Ptransform.position;
        Spos = Stransform.position;

        Ppos.x -= 2f; Spos.x -= 1f;
        Ppos.y -= 1f;Spos.y -= 0.5f;


    }

}
