using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour {

	

	[Tooltip("in Seconds")][SerializeField] float levelLoadDelay = 1f;
	[Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

	void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
		deathFX.SetActive(true);
		Invoke("ReloadScene", levelLoadDelay); //string
		
	}	
	private void StartDeathSequence()
	{		
		SendMessage("OnPlayerDeath");
		deathFX.SetActive(true);
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(1);
	}

}
