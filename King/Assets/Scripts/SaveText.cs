using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveText : MonoBehaviour
{
    [SerializeField] List<string> dialogueList = new List<string>();//会話文リスト
    [SerializeField] Text telopText; //表示させたいテキストを用意
    [SerializeField] float telopSpeed; //テロップの速さ
    RTS0 rts0;
    int dialogueListIndex = 0; //表示中の会話文がどこか把握するためのもの

    void Start()
    {

        rts0 = GameObject.Find("Save1").GetComponent<RTS0>();

    }

    private void Update()
    {
        if (rts0.potisionTrigger==true)
        {
            StartTelop();
        }
    }


    void StartTelop()
    {
        int characterCount = 0; //現在表示中の文字数
        telopText.text += "";

        while (dialogueList[dialogueListIndex].Length > characterCount)//文字をすべて表示していない場合ループ
        {
           
            telopText.text += dialogueList[dialogueListIndex][characterCount];//リセットしたtelopTextの内容に一文字追加
            characterCount++; //現在の文字数
            
            

            
        }
        
        
        
    }


}
