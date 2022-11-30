using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerController : MonoBehaviour
{
    public Text timerText;

    public GameObject TimerText;

    public float totalTime;
    int seconds;

    AudioSource audioSource;
    public AudioClip sound;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "KindsScene2" || SceneManager.GetActiveScene().name == "KindsScene3")
        {
            audioSource.PlayOneShot(sound);
        }
        else audioSource.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();

        if(seconds==-1.0f)
        {
            TimerText.SetActive(false);
            audioSource.Stop();
        }

    }
}