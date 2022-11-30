using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade3 : MonoBehaviour
{
    public bool isFadeout = false;
    public bool isFadeIn = false;
    float speed = 0.01f;
    Image fadepanel;
    float red, green, blue, alpha;
    GameObject player;
    public GameObject Text;
    public GameObject Text2;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("GameCamera");
        fadepanel = GetComponent<Image>();
        red = fadepanel.color.r;
        green = fadepanel.color.g;
        blue = fadepanel.color.b;
        alpha = fadepanel.color.a;
        isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeout)
        {
            Fadeout();
        }
        if (isFadeIn)
        {
            StartFadeIn();
        }
    }

    void Fadeout()
    {
        alpha += speed;
        fadepanel.color = new Color(red, green, blue, alpha);
        if (alpha >= 1)
        {
            isFadeout = false;
            this.player.transform.position = new Vector3(23.5f, 0f, -84);
            isFadeIn = true;
            Text.SetActive(false);
            Text2.SetActive(true);
        }
    }

    void StartFadeIn()
    {
        alpha -= speed;
        fadepanel.color = new Color(red, green, blue, alpha);
        if (alpha <= 0)
        {
            isFadeIn = false;

        }
    }
}