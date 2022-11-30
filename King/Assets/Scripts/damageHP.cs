using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageHP : MonoBehaviour
{
    Slider PlayerHP;
    float damage=5f;
    float time;
    bool damageGround;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageGround)
        {
            time += Time.deltaTime;
            if (time > 2)
            {
                PlayerHP.value -= damage;
                time = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Damage")
        {
            PlayerHP.value -= damage;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Damage")
        {
            damageGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Damage")
        {
            damageGround = false;
        }
    }
}
