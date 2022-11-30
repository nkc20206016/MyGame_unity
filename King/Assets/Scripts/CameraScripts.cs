using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScripts : MonoBehaviour
{
    
    public GameObject player;
    public GameObject slime;

    float start;//初期位置
    float end;//終了位置
    float tatehaba = -10f;//Y軸の0以下の位の限界値
    float tatehabaEnd = 10f;//Y軸の0以下の位の限界値
    string change;
    int count;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Getkey();
        CameraSwich();
        Move();

       
    }

    void Getkey()
    {
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.Play();
            count++;
        }


        if (count == 0)
        {
            change = "Player";
        }
        if (count == 1)
        {
            change = "Slime";
        }
        if (count >1)
        {
            change="Player";
            count = 0;
        }
    }

    void CameraSwich()
    {
        switch (change)
        {
            case "Player":
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, transform.position.z);
                break;
            case"Slime":
                transform.position = new Vector3(slime.transform.position.x, slime.transform.position.y + 3, transform.position.z);
                break;
            default:
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, transform.position.z);
                break;
        }
    }

    void Move()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            start = 0.0f;//初期位置
            end = 62f;//終了位置

            if (transform.position.x < start)
            {
                transform.position = new Vector3(start, transform.position.y, transform.position.z);
            }

            if (transform.position.x >= end)
            {
                transform.position = new Vector3(end, transform.position.y, transform.position.z);
            }
            if (transform.position.y < tatehaba)
            {
                transform.position = new Vector3(transform.position.x, tatehaba, transform.position.z);
            }

            if (transform.position.y >= tatehabaEnd)
            {
                transform.position = new Vector3(transform.position.x, tatehabaEnd, transform.position.z);
            }
        }

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            start = 0.0f;//初期位置
            end = 275f;//終了位置

            if (transform.position.x < start)
            {
                transform.position = new Vector3(start, transform.position.y, transform.position.z);
            }

            if (transform.position.x >= end)
            {
                transform.position = new Vector3(end, transform.position.y, transform.position.z);
            }
            if (transform.position.y < tatehaba)
            {
                transform.position = new Vector3(transform.position.x, tatehaba, transform.position.z);
            }

            if (transform.position.y >= tatehabaEnd)
            {
                transform.position = new Vector3(transform.position.x, tatehabaEnd, transform.position.z);
            }
        }

    }
}
