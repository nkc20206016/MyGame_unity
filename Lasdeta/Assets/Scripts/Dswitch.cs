using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dswitch : MonoBehaviour
{
    public GameObject dl;
    public GameObject ns;
        Animator anim;
    public bool DBtrigger=false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ns.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DBtrigger == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                
                anim.SetTrigger("Dswitch");
                Destroy(dl);
                this.gameObject.SetActive(false);
                ns.SetActive(true);
                DBtrigger = true;
                Debug.Log(DBtrigger);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
