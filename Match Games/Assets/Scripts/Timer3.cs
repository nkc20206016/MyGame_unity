using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer3 : MonoBehaviour
{
    GameObject Fade;
    Fade3 script;
    public GameObject Text;

    AudioSource audioSource;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Fade = GameObject.Find("FadePanel");
        script = Fade.GetComponent<Fade3>();

        Invoke("Call", 11f);
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
