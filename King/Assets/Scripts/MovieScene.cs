using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MovieScene : MonoBehaviour
{
    VideoPlayer videoPlayer;
    float time;

    void Awake()
    {
        videoPlayer = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
    }
    void Start()
    {
        videoPlayer.started += OnStarted;
        videoPlayer.loopPointReached += OnLoopPointReached;
    }



    void OnStarted(VideoPlayer video)
    {
        Debug.Log("start");
    }

    void OnLoopPointReached(VideoPlayer video)
    {
        FadeManager.Instance.LoadScene("Tutorial", 1f);
    }
}
