using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Animator animator;
    Text text;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        text = GameObject.Find("GameOverText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(damage());

        time += Time.deltaTime;

        if (time > 3)
        {
            FadeManager.Instance.LoadScene("ContiueScene", 0.5f);
        }
    }


    IEnumerator damage()
    {
        animator.SetBool("Idle", true);
        text.color += new Color(0, 0, 0, 0.005f);
       
        yield return new WaitForSeconds(1f);

        animator.SetBool("Death", true);
       
    }
}
