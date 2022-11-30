using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalCount : MonoBehaviour
{
    public void NormalCountScene()
    {
        FadeManager.Instance.LoadScene("NormalCount",1.0f);
    }
}
