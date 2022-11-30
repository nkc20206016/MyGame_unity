using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeText : MonoBehaviour
{
    float alfa = 0;
    public float speed = 0.04f;
    float red, green, blue;

    bool onetime = false;
    bool orikaesi = false;

    void Start()
    {
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
    }

    void Update()
    {
        if (orikaesi == false)
        {
            GetComponent<Text>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }

        if (alfa > 1)
        {
            if (onetime == false)
            {
                StartCoroutine("orikaesiwait");
            }
        }
        
    }

    IEnumerator orikaesiwait()
    {
        yield return new WaitForSeconds(1);
        orikaesi = true;
    }
}
