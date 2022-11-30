using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayer : MonoBehaviour
{
    public GameObject Wkey;
    public GameObject slider;

    public float speed = 1f;
    float move = 0;
    float jumpPower = 300f;
    int jumpCount = 0;
    GameObject Light;

    public bool trigger = false;
    public bool WKeyTrigger = false;
    public bool Wpower = false;
    public bool power=true;

    bool LightTrriger = false;
    float TriggerCount = 0f;

    public AudioClip sound;
    AudioSource audioSource;
    PowerDerector pd;
    Rigidbody2D rb2;
    // Start is called before the first frame update

    private void Awake()
    {
        Light = GameObject.Find("Light");
        Light.SetActive(false);
    }
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        pd = slider.GetComponent<PowerDerector>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "rb"||collision.gameObject.tag=="bb"||collision.gameObject.tag=="cb")
        {
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "WKey")
        {
            Destroy(Wkey);
            WKeyTrigger = true;
            audioSource.PlayOneShot(sound);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rw")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                trigger = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (move > 0)
        {
            rb2.velocity = new Vector2(speed, rb2.velocity.y);
        }
        else if (move < 0)
        {
            rb2.velocity = new Vector2(-speed, rb2.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rb2.velocity = new Vector2(0, 0);
        }

        if (jumpCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2.AddForce(new Vector3(0, jumpPower, 0));
                jumpCount++;
            }
        }

        if (pd.currentP <= 0)
        {
            power = false;
            Light.SetActive(false);
        }

        //能力
        if (power==true)
        {
            if (Input.GetKeyDown(KeyCode.Z) && LightTrriger == false)
            {
                Light.SetActive(true);
                TriggerCount++;
                if (TriggerCount > 1)
                {
                    LightTrriger = true;
                    TriggerCount = 0f;
                }
                Wpower = true;

            }
            if (Input.GetKeyDown(KeyCode.Z) && LightTrriger == true)
            {
                Light.SetActive(false);
                TriggerCount++;
                if (TriggerCount > 1)
                {
                    LightTrriger = false;
                    TriggerCount = 0;
                }
                Wpower = false;
            }
        }
    }
}

