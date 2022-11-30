using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSet : MonoBehaviour
{
    //属性の設定
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(1920, 1080, false);
    }
}
