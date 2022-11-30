using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mugic : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start()
	{
		Invoke("Main", 3f);
	}
	void LoadScene()
	{
		SceneManager.LoadScene("Main");
	}
    private void Update()
    {
        
    }
}
