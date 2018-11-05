using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
	[Header("General")]
	[Tooltip("In meters per second")][SerializeField] float xSpeed = 20f;
	[Tooltip("In meters per second")][SerializeField] float ySpeed = 20f;
	[Tooltip("In meters")][SerializeField] float xRange = 5f;	
	[Tooltip("In meters")][SerializeField] float yMinRange = -3f;
	[Tooltip("In meters")][SerializeField] float yMaxRange = 3f;

	[Header("Screen position")]
	[SerializeField] float positionYawFactor = 5f;
	[SerializeField] float controlRollFactor = -20f;	

	[Header("Control throw based")]
	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float controlPitchFactor = -20f;
	

	float yThrow;
	float xThrow;

	bool isDead = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (isDead != true)
		{
		ProcessTranslation();
		ProcessRotation();
		}
	}

	void OnPlayerDeath() // TODO called by string reference
	{
		print("Message recieved");
		isDead = true;
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

