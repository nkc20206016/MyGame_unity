using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    SlimeGorler sc;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.FindGameObjectWithTag("SlimeGorl").GetComponent<SlimeGorler>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sc.gorl == true)
        {
            transform.Rotate(0, 0, 0.5f);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (sc.gorl == true)
                {
                    audioSource.Play();
                    if (SceneManager.GetActiveScene().name == "Tutorial")
                    {
                        FadeManager.Instance.LoadScene("GameScene", 0.5f);
                    }
                    if (SceneManager.GetActiveScene().name == "GameScene")
                    {
                        FadeManager.Instance.LoadScene("EndScene", 0.5f);
                    }
                }
                
            }

            
        }
    }
}
