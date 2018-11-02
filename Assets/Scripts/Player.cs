﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
	[Tooltip("In meters per second")][SerializeField] float xSpeed = 20f;
	[Tooltip("In meters per second")][SerializeField] float ySpeed = 20f;
	[Tooltip("In meters")][SerializeField] float xRange = 5f;	
	[Tooltip("In meters")][SerializeField] float yMinRange = -3f;
	[Tooltip("In meters")][SerializeField] float yMaxRange = 3f;
	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float controlPitchFactor = -20f;
	[SerializeField] float positionYawFactor = 5f;
	[SerializeField] float controlRollFactor = -20f;	

	float yThrow;
	float xThrow;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		ProcessTranslation();
		ProcessRotation();
	}
	private void ProcessTranslation ()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float YOffset = yThrow * ySpeed * Time.deltaTime;

		float rawXPos = transform.localPosition.x + xOffset;		
		float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

		float rawYPos = transform.localPosition.y + YOffset;
		float clampedYPos = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);		

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);	
	}

	private void ProcessRotation ()
	{		
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
}
