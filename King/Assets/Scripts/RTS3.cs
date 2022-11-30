using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTS3 : MonoBehaviour
{
    public bool potisionTrigger = false;

    public static Vector3 Ppos;
    public static Vector3 Spos;

    RespawnDerector rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GameObject.Find("RespawnDerector").GetComponent<RespawnDerector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //位置情報を保存
        if (potisionTrigger == false)
        {
            potisionTrigger = true;

            RespawnDerector.point = 4;

        }

    }

    public void ReapawnPoint()
    {
        Transform Ptransform = this.transform;
        Transform Stransform = this.transform;

        //位置情報を保存
        Ppos = Ptransform.position;
        Spos = Stransform.position;

        Ppos.x -= 2f; Spos.x -= 1f;
        Ppos.y -= 1f; Spos.y -= 0.5f;


    }
}
