using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDerector : MonoBehaviour
{
    Player player;
    LPlayer lplayer;

    public GameObject dp;
    public GameObject lp;

    public GameObject text;
    public GameObject Etext;

    public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player =dp.GetComponent <Player>();
        lplayer = lp.GetComponent<LPlayer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.BKeyTrigger == true && lplayer.WKeyTrigger == true)
            {
                Etext.SetActive(true);
                if (Input.GetKey(KeyCode.Return))
                {
                    audioSource.PlayOneShot(sound);
                    FadeManager.Instance.LoadScene("Main", 2.0f);
                }
            }
            else
            {
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        Etext.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
