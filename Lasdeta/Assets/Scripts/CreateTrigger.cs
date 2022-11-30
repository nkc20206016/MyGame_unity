using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrigger : MonoBehaviour
{
    //trrigerの判定を修正
    public bool ctTrriger;
    GameObject GD;

    GameObject CB;
    GameDerector gd;

    private void Awake()
    {
        GD = GameObject.Find("GameDerector");
        gd = GD.GetComponent<GameDerector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetChildren(this.gameObject);
    }

    public void GetChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();

        //子がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            if (ctTrriger == true)
            {
                ob.gameObject.SetActive(true);
            }
            if (ctTrriger == false)
            {
                ob.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "light")
        {
            ctTrriger = true;
            GetChildren(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "light")
        {
            ctTrriger = false;
            GetChildren(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
