using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBTrigger : MonoBehaviour
{
    GameObject CT;
    GameObject GD;
    GameObject[] CB;

    CreateTrigger ct;
    GameDerector gd;

    void Awake()
    {
        CT = GameObject.FindGameObjectWithTag("CTrigger");
    }
    // Start is called before the first frame update
    void Start()
    {
        GD = GameObject.Find("GameDerector");

        ct = CT.GetComponent<CreateTrigger>();
        gd = GD.GetComponent<GameDerector>();
        CB = GameObject.FindGameObjectsWithTag("cb");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag=="light"&&ct.ctTrriger == false)
        //{
        //    ct.ctTrriger = true;
        //    ct.GetChildren(CT);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "light"&&ct.ctTrriger == true)
        //{
        //    ct.ctTrriger = false;
        //    ct.GetChildren(CT);

        //}
    }
    // Update is called once per frame


    public void TCB()
    {
        Debug.Log(CB);
        foreach(GameObject cb in CB)
        {
            if (cb.activeSelf == false&&gd.SetTrigger==true)
            {
                cb.SetActive(true);
            }
        }
    }
    void Update()
    {
        
    }
}
