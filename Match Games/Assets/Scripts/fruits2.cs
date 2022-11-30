using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fruits2 : MonoBehaviour
{
    public GameObject[] Fruits = new GameObject[8];
    List<GameObject> myList = new List<GameObject>();
    int i = 1;

    public BoxCollider2D applecol;
    public BoxCollider2D bananascol;
    public BoxCollider2D cherriescol;
    public BoxCollider2D kiwicol;
    public BoxCollider2D meloncol;
    public BoxCollider2D orangecol;
    public BoxCollider2D pineapplecol;
    public BoxCollider2D strawberrycol;

    public BoxCollider2D applewcol;
    public BoxCollider2D bananaswcol;
    public BoxCollider2D cherrieswcol;
    public BoxCollider2D kiwiwcol;
    public BoxCollider2D melonwcol;
    public BoxCollider2D orangewcol;
    public BoxCollider2D pineapplwecol;
    public BoxCollider2D strawberrywcol;
    void Start()
    {
        foreach (GameObject item in Fruits)
        {
            myList.Add(item);
        }

        while (myList.Count > 0)
        {
            int count = Random.Range(0, myList.Count);
            if (i == 1)
            {
                Instantiate(myList[count], new Vector3(6.6f, 2.92f, 0), Quaternion.identity);
            }

            if (i == 2)
            {
                Instantiate(myList[count], new Vector3(0.1f, 0.9f, 0), Quaternion.identity);
            }

            if (i == 3)
            {
                Instantiate(myList[count], new Vector3(-7.1f, 1.4f, 0), Quaternion.identity);
            }

            if (i == 4)
            {
                Instantiate(myList[count], new Vector3(-6.76f, -2.56f, 0), Quaternion.identity);
            }


            myList.RemoveAt(count);

            i++;
        }

        Check("Apple");
        Check1("Cherries");
        Check2("Bananas");
        Check3("Kiwi");
        Check4("Melon");
        Check5("Orange");
        Check6("Pineapple");
        Check7("Strawberry");

    }

    void Update()
    {

    }

    void Check(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);

        if (Fruits.Length >= 2)
        {
            applecol.enabled = true;
            Debug.Log(tagname + "apple");
        }

        if (Fruits.Length < 2)
        {
            applewcol.enabled = true;
            Debug.Log(tagname + "not");
        }

    }

    void Check1(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);

        if (Fruits.Length >= 2)
        {
            cherriescol.enabled = true;
            Debug.Log(tagname + "cherries");
        }

        if (Fruits.Length < 2)
        {
            cherrieswcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check2(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            bananascol.enabled = true;
            Debug.Log(tagname + "bananas");
        }

        if (Fruits.Length < 2)
        {
            bananaswcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check3(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            kiwicol.enabled = true;
            Debug.Log(tagname + "kiwi");
        }

        if (Fruits.Length < 2)
        {
            kiwiwcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check4(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            meloncol.enabled = true;
            Debug.Log(tagname + "melon");
        }

        if (Fruits.Length < 2)
        {
            melonwcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check5(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            orangecol.enabled = true;
            Debug.Log(tagname + "orange");
        }

        if (Fruits.Length < 2)
        {
            orangewcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check6(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            pineapplecol.enabled = true;
            Debug.Log(tagname + "pineapple");
        }

        if (Fruits.Length < 2)
        {
            pineapplwecol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

    void Check7(string tagname)
    {
        Fruits = GameObject.FindGameObjectsWithTag(tagname);
        if (Fruits.Length >= 2)
        {
            strawberrycol.enabled = true;
            Debug.Log(tagname + "strawberry");
        }

        if (Fruits.Length < 2)
        {
            strawberrywcol.enabled = true;
            Debug.Log(tagname + "not");
        }
    }

}
