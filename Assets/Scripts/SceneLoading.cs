using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoading : MonoBehaviour {

	// Use this for initialization
	
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