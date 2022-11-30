using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    string select;
    Button yes;
    Button no;
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    SceneJudge sceneJuge;

    [SerializeField]
    AudioClip SE_select;
    [SerializeField]
    AudioClip SE_Kettei;
    AudioSource audioSource;

    void Start()
    {
        sceneJuge = GameObject.Find("SceneJudge").GetComponent<SceneJudge>();
        yes = GameObject.Find("Yes").GetComponent<Button>();
        no= GameObject.Find("No").GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.clip = SE_select;
            audioSource.Play();
            select = "No";
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.clip = SE_select;
            audioSource.Play();
            select = "Yes";
        }

        switch (select)
        {
            case "Yes":
                yes.Select();
                up.SetActive(true);
                down.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    audioSource.clip = SE_Kettei;
                    audioSource.Play();
                    if (sceneJuge.tutorial==true)
                    {
                        FadeManager.Instance.LoadScene("Tutorial", 0.5f);
                    }
                    else if (sceneJuge.Game == true)
                    {
                        FadeManager.Instance.LoadScene("GameScene", 0.5f);
                    }
                    
                }

                break;
            case "No":
                no.Select();
                down.SetActive(true);
                up.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    audioSource.clip = SE_Kettei;
                    audioSource.Play();
                    FadeManager.Instance.LoadScene("Title", 0.5f);
                }
                break;
            default:
                yes.Select();
                up.SetActive(true);
                down.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    audioSource.clip = SE_Kettei;
                    audioSource.Play();
                    if (sceneJuge.tutorial == true)
                    {
                        FadeManager.Instance.LoadScene("Tutorial", 0.5f);
                    }
                    else if (sceneJuge.Game == true)
                    {
                        FadeManager.Instance.LoadScene("GameScene", 0.5f);
                    }

                }
                break;
        }

    }
}
