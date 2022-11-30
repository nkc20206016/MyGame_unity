using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyCount : MonoBehaviour
{
    
    private void Awake()
    {
        //BgmManagerのresorcesフォルダ内に音源を入れ、()内に名前を入れる
       BgmManager.Instance.Play("hometown_mixv2");
    }

    public void EasyCountScene()
    {
        FadeManager.Instance.LoadScene("EasyCount",1.0f);
    }
}
