using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyCount : MonoBehaviour
{
    
    private void Awake()
    {
        //BgmManager��resorces�t�H���_���ɉ��������A()���ɖ��O������
       BgmManager.Instance.Play("hometown_mixv2");
    }

    public void EasyCountScene()
    {
        FadeManager.Instance.LoadScene("EasyCount",1.0f);
    }
}
