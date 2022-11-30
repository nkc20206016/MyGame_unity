using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpSetActive : MonoBehaviour
{
    bool start;
    public float time;
    Vector3 SlimePos;
    Vector3 PlayerPos;
    [SerializeField] GameObject Jump;
    [SerializeField] GameObject floor;
    [SerializeField] GameObject timer;
    GameObject Player;
    GameObject Slime;
    Slider SlimeHP;
    float nowHP;
    // Start is called before the first frame update
    void Start()
    {
        SlimeHP = GameObject.Find("SlimeHP").GetComponent<Slider>();
        Player = GameObject.FindWithTag("Player");
        Slime = GameObject.FindWithTag("Slime");
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer.SetActive(true);
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            timer.SetActive(false);
        }

        if (time >= 5)
        {
            if (nowHP*0.8<SlimeHP.value)
            {
                
                timer.SetActive(false);
                Jump.SetActive(false);
                floor.SetActive(true);
                start = false;
            }
            else
            {
                
                Player.transform.position = PlayerPos;
                Slime.transform.position = SlimePos;
                time = 0;
                start = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slime")
        {
            nowHP=SlimeHP.value;
            PlayerPos = Player.transform.position;
            SlimePos = Slime.transform.position;
            start = true;
        }
    }
}
