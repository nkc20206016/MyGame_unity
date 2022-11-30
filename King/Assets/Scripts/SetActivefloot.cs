using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivefloot : MonoBehaviour
{
    bool stay;
    [SerializeField] GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (stay == false)
        {
            floor.SetActive(true);
        }
        else
        {
            floor.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            stay = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            stay = false;
        }
    }
}
