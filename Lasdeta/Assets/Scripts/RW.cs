using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW : MonoBehaviour
{
    public GameObject rEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rEnter.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rEnter.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
