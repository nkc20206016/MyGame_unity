using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Message : MonoBehaviour
{
    [SerializeField] List<string> dialogueList = new List<string>();//会話文リスト
    [SerializeField] Text telopText; //表示させたいテキストを用意
    [SerializeField] float telopSpeed; //テロップの速さ

    int dialogueListIndex = 0; //表示中の会話文がどこか把握するためのもの

    void Start()
    {
       
        StartCoroutine(StartTelop());



    }

    private void Update()
    {

        if (dialogueListIndex >= 7)
        {
            
            StartCoroutine(Finish());
        }
    }


    IEnumerator StartTelop()
    {
        int characterCount = 0; //現在表示中の文字数
        telopText.text += "\n"; //テキストのリセット

        while (dialogueList[dialogueListIndex].Length > characterCount)//文字をすべて表示していない場合ループ
        {
            telopText.text += dialogueList[dialogueListIndex][characterCount];//リセットしたtelopTextの内容に一文字追加
            characterCount++; //現在の文字数
            yield return new WaitForSeconds(telopSpeed); //telopSpeedの時間分待つ
        }

        dialogueListIndex++; //次の会話文を用意

        if (dialogueListIndex < dialogueList.Count)//全ての会話を表示したか
        {

            StartCoroutine(StartTelop());
        }
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(3);

        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

   
}
