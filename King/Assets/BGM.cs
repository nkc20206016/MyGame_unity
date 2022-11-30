using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    //シングルトン設定ここから
    static public BGM instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    //シングルトン設定ここまで




    public AudioSource A_BGM;//AudioSource型の変数A_BGMを宣言　対応するAudioSourceコンポーネントをアタッチ
    public AudioSource B_BGM;//AudioSource型の変数B_BGMを宣言　対応するAudioSourceコンポーネントをアタッチ
    public AudioSource C_BGM;//AudioSource型の変数C_BGMを宣言　対応するAudioSourceコンポーネントをアタッチ

    private string beforeScene;//string型の変数beforeSceneを宣言 

    void Start()
    {
        beforeScene = "Title";//起動時のシーン名 を代入しておく
        
        A_BGM.Play();//A_BGMのAudioSourceコンポーネントに割り当てたAudioClipを再生

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }




    //シーンが切り替わった時に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {      
            //シーンがどう変わったかで判定

            if (beforeScene == "MovieScene" && nextScene.name == "Tutorial")
            {
              A_BGM.Stop();
              B_BGM.Play();
            }

            if (beforeScene == "Tutorial" && nextScene.name == "GameOverScene")
            {
                B_BGM.Stop();
                C_BGM.Play();
            }
            if (beforeScene == "GameScene" && nextScene.name == "GameOverScene")
             {
                B_BGM.Stop();
                C_BGM.Play();
             }

             if(beforeScene=="ContiueScene"&& nextScene.name=="Tutorial")
             {
                C_BGM.Stop();
                B_BGM.Play();
             }

             if(beforeScene=="ContiueScene"&& nextScene.name=="GameScene")
             {
                C_BGM.Stop();
                B_BGM.Play();
             }
            if(beforeScene=="ContiueScene"&& nextScene.name=="Title")
             {
                C_BGM.Stop();
                A_BGM.Play();
             }
            if(beforeScene=="GameScene"&& nextScene.name=="EndScene")
            {
                B_BGM.Stop();
            }

        if (beforeScene == "EndScene" && nextScene.name == "Title")
        {
            A_BGM.Play();
        }
             


        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;

        
    }
}
