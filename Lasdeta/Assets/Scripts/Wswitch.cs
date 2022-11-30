using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wswitch : MonoBehaviour
{
    Animator anim;
    public GameObject wb;
    public bool WBtrigger=false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Wswitch");
            Destroy(wb);
            WBtrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
