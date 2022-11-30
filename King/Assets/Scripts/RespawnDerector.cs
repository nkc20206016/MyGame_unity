using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDerector : MonoBehaviour
{

    public static int point;

    GameObject player;
    GameObject slime;

    RTS0 rts0;
    RTS1 rts1;
    RTS2 rts2;
    RTS3 rts3;

    private void Awake()
    {
        //アタッチするオブジェクト名記入
        rts0 = GameObject.Find("Save1").GetComponent<RTS0>();
        rts1 = GameObject.Find("Save2").GetComponent<RTS1>();
        rts2 = GameObject.Find("Save3").GetComponent<RTS2>();
        //rts3 = GameObject.Find("").GetComponent<RTS3>();

        player = GameObject.Find("Player");
        slime = GameObject.Find("Slime");

    }
    // Start is called before the first frame update
    void Start()
    {
        switch (point)
        {
            case 0: //ここに初期位置に移動するコード
                break;
            
            case 1:
                rts0.ReapawnPoint();

                player.transform.position = RTS0.Ppos;
                slime.transform.position = RTS0.Spos;

                break;
            
            case 2:
                rts1.ReapawnPoint();

                player.transform.position = RTS1.Ppos;
                slime.transform.position = RTS1.Spos;
                break;
            
            case 3:
                rts2.ReapawnPoint();

                player.transform.position = RTS2.Ppos;
                slime.transform.position = RTS2.Spos;
                break;

            case 4:
                rts3.ReapawnPoint();

                player.transform.position = RTS3.Ppos;
                slime.transform.position = RTS3.Spos;
                break;

            default:
                break;
        }

    }

}
