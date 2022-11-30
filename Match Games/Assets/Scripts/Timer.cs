using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameObject Fade;
    Fade script;
    public GameObject Text;

    AudioSource audioSource;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Fade = GameObject.Find("FadePanel");
        script = Fade.GetComponent<Fade>();

        Invoke("Call", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Call()
    {
        audioSource.PlayOneShot(sound);
        script.isFadeout = true;
        Text.SetActive(true);
    }
}
