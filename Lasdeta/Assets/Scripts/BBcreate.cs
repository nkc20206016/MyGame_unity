using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBcreate : MonoBehaviour
{
    public GameObject GD;
    public GameObject trigger;
    public GameObject vertex;
    public GameObject parent;
    GameObject obj;
    GameObject point;

    public GameObject slider;
    public GameObject DPlayer; 
    GameObject nowParent = null;
 

    public bool Bpower=false;
    public bool power=true;
    public bool bbcTrigger;


    Vector3 lastpos;
    GameDerector gd;
    PowerDerector pd;
    CBTrigger cbt;

    // Start is called before the first frame update
    void Start()
    {
        lastpos = transform.position;

        gd = GD.GetComponent<GameDerector>();
        pd = slider.GetComponent<PowerDerector>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pd.currentP <= 0)
        {
            power = false;
        }

        if (DPlayer.activeSelf == true && power == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateEmpty();     

                Bpower = true;
            }

            if (Input.GetMouseButton(0))
            {
                DrawLine();
            }

            if (Input.GetMouseButtonUp(0))
            {
                LastCreate();
                Bpower = false;
            }
        }
    }
    void CreateEmpty()
    {
        Vector3 pos = Input.mousePosition;
        Vector3 Clickpos = Camera.main.ScreenToWorldPoint(pos);
        //Ray ray = Camera.main.ScreenPointToRay(pos);
        //RaycastHit2D hit;

        //hit = Physics2D.Raycast((Vector3)ray.origin, (Vector3)ray.direction, 10);
        //Vector3 target = hit.point;
        //target.z = 2;
        nowParent = Instantiate(parent,Clickpos, transform.rotation);
        //親オブジェとしてinstantiate
        nowParent.transform.parent = gameObject.transform;

    }

    void DrawLine()
    {
        Vector3 pos = Input.mousePosition;
        if (pos == lastpos)
        {
            return;
        }

        Vector3 Clickpos = Camera.main.ScreenToWorldPoint(pos);

        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit2D hit;

        hit = Physics2D.Raycast((Vector3)ray.origin, (Vector3)ray.direction, 10);
        Vector3 target = hit.point;
        target.z = 2;
        obj = Instantiate(vertex, target, transform.rotation);
        //子オブジェとしてinstantiate
        obj.transform.parent = nowParent.transform;
        lastpos = pos;
    }

    void LastCreate()
    {
        Vector3 pos = Input.mousePosition;
        Vector3 LastClick = Camera.main.ScreenToWorldPoint(pos);

        point = Instantiate(trigger,LastClick, transform.rotation);

        point.transform.parent = gameObject.transform;

        cbt = point.GetComponent<CBTrigger>();
        Debug.Log(cbt);


    }

    public void Setcatch()
    {
        Debug.Log(cbt);

        if (gd.SetTrigger == true&&cbt!=null)
        {
            cbt.TCB();
        }
    }

}

