using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHP : MonoBehaviour
{
    GameObject slime;
    Slider slimeHp;
    // Start is called before the first frame update
    void Start()
    {
        slime = GameObject.Find("Slime");
        slimeHp = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        HP();
        if (this.slimeHp.value <= 0)
        {
            FadeManager.Instance.LoadScene("GameOverScene", 0.5f);
        }

    }

    void HP()
    {
        transform.position = new Vector2(slime.transform.position.x,slime.transform.position.y+0.5f);
    }
}
