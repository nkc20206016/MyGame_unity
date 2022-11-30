using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJudge : MonoBehaviour
{
    public bool tutorial;
    public bool Game;

    // Start is called before the first frame update

    static public SceneJudge instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            tutorial = true;
            Game = false;
          
        }
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            tutorial = false;
            Game = true;
        }
    }
}
