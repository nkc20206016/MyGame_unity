using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KindsRule : MonoBehaviour
{
    GameObject player;
    public GameObject Text;
    public GameObject Button;
    public GameObject Text2;
    public GameObject Button2;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("GameCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        Text.SetActive(false);
        Button.SetActive(false);

        Text2.SetActive(true);
        Button2.SetActive(true);
        this.player.transform.position = new Vector3(17f,0f,-10f);
    }
}
