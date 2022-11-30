using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSclipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slime")
        {
            //リスタート位置をここに書く 
            //トーチに触れているかの分岐で変更
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
