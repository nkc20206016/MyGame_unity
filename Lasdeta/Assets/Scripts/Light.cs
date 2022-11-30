using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    GameObject gd;
    GameDerector GD;

    // Start is called before the first frame update
    void Start()
    {
        gd = GameObject.Find("GameDerector");
        GD = gd.GetComponent<GameDerector>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
