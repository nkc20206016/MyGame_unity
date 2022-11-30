using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDerector : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(sound);
            FadeManager.Instance.LoadScene("Main", 1.0f);
        }
    }
}
