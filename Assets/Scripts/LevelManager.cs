using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	void Start () 
	{
		// ben's way: invoke("LoadFirstScene", 2f);
		
	}
	
	// Update is called once per frame
	void Update ()
	{		
		KeyInput();
	}

	private void KeyInput()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			LoadFirstLevel();
			print("E pressed");
		}
	}

	private void LoadFirstLevel()
	{
		SceneManager.LoadScene(1);
	}
}
