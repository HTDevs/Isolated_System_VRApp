using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMenu : MonoBehaviour
{
	private Animator animator = null;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void SetBool(bool state)
	{
		animator.SetBool("Active", state);
	}
}