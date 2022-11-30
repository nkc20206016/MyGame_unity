using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDoar1 : MonoBehaviour
{
    public GameObject text;

    public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(sound);
                FadeManager.Instance.LoadScene("Stage1", 1.0f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
