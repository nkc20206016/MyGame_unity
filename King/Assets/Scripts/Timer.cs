using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    GameObject Player;
    Text text;
    JumpSetActive secondTrialScripts;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        text = this.gameObject.GetComponent<Text>();
        secondTrialScripts = GameObject.Find("SecondTrial").GetComponent<JumpSetActive>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+2.2f, this.transform.position.z);
        text.text = secondTrialScripts.time.ToString("F0");
    }
}
