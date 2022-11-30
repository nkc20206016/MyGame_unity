using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kinds3Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene("KindsScene3",1.0f);
    }
}
