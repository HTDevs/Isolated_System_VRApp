using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
	[SerializeField]
	private Animator doorAnimator = null;
	[SerializeField]
	private AudioSource audioSource = null;
	public bool PointerEnter { get; set; }

	private void Update()
	{
		if (PointerEnter)
		{
			if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				audioSource.Play();
				doorAnimator.SetTrigger("Action");
			}
		}
	}
}