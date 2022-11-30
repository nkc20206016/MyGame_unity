using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectClickExample : MonoBehaviour
{
    public GameObject AppleC ;
    public GameObject BananasC ;
    public GameObject CherriesC ;
    public GameObject KiwiC ;
    public GameObject MelonC ;
    public GameObject OrangeC ;
    public GameObject PineappleC ;
    public GameObject StrawberryC ;

    public GameObject AppleW;
    public GameObject BananasW;
    public GameObject CherriesW;
    public GameObject KiwiW;
    public GameObject MelonW;
    public GameObject OrangeW;
    public GameObject PineappleW;
    public GameObject StrawberryW;

    public BoxCollider2D applecol;
    public BoxCollider2D bananascol;
    public BoxCollider2D cherriescol;
    public BoxCollider2D kiwicol;
    public BoxCollider2D meloncol;
    public BoxCollider2D orangecol;
    public BoxCollider2D pineapplecol;
    public BoxCollider2D strawberrycol;

    int count=0;

    AudioSource audioSource;
    public AudioClip sound;
    public AudioClip click;

    private GameObject getClickObject()
    {
        GameObject result = null;
        // 左クリックされた場所のオブジェクトを取得
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                result = collition2d.transform.gameObject;
            }
        }
        return result;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    void Update()
    {     

        GameObject apple = GameObject.FindWithTag("Apple");
        GameObject bananas = GameObject.FindWithTag("Bananas");
        GameObject cherries = GameObject.FindWithTag("Cherries");
        GameObject kiwi= GameObject.FindWithTag("Kiwi");
        GameObject melon= GameObject.FindWithTag("Melon");
        GameObject orange= GameObject.FindWithTag("Orange");
        GameObject pineapple= GameObject.FindWithTag("Pineapple");
        GameObject strawberry= GameObject.FindWithTag("Strawberry");

        GameObject applew = GameObject.FindWithTag("AppleW");
        GameObject bananasw = GameObject.FindWithTag("BananasW");
        GameObject cherriesw = GameObject.FindWithTag("CherriesW");
        GameObject kiwiw = GameObject.FindWithTag("KiwiW");
        GameObject melonw = GameObject.FindWithTag("MelonW");
        GameObject orangew = GameObject.FindWithTag("OrangeW");
        GameObject pineapplew = GameObject.FindWithTag("PineappleW");
        GameObject strawberryw = GameObject.FindWithTag("StrawberryW");

        GameObject obj = getClickObject();

        if (obj != null)
        {
            if(obj==apple)
            {
                AppleC.SetActive(true);
                applecol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == bananas)
            {
                BananasC.SetActive(true);
                bananascol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == cherries)
            {
                CherriesC.SetActive(true);
                cherriescol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == kiwi)
            {
                KiwiC.SetActive(true);
                kiwicol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == melon)
            {
                MelonC.SetActive(true);
                meloncol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == orange)
            {
                OrangeC.SetActive(true);
                orangecol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == pineapple)
            {
                PineappleC.SetActive(true);
                pineapplecol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == strawberry)
            {
                StrawberryC.SetActive(true);
                strawberrycol.enabled = false;
                Debug.Log(count++);
            }

            if (obj == applew)
            {
                AppleW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == bananasw)
            {
                BananasW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == cherriesw)
            {
                CherriesW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == kiwiw)
            {
                KiwiW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == melonw)
            {
                MelonW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == orangew)
            {
                OrangeW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == pineapplew)
            {
                PineappleW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (obj == strawberryw)
            {
                StrawberryW.SetActive(true);
                Invoke("GameOver", 1f);
                GetComponent<ObjectClickExample>().enabled = false;
            }

            if (count == 3)
            {
                GetComponent<ObjectClickExample>().enabled = false;
                Invoke("GameClear", 1f);
            }
        }
    }

    void GameOver()
    {
        FadeManager.Instance.LoadScene("GameOver", 0.7f);
    }

    void GameClear()
    {
        FadeManager.Instance.LoadScene("GameClear", 0.5f);
    }
}
