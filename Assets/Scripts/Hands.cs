using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
	[SerializeField]
	private GameObject[] selections = null;
	private Animator animator = null;

	public int Selected { get; set; }

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void ToggleSelected()
	{
		selections[Selected].SetActive(!selections[Selected].activeSelf);
	}

	public void SetBool(bool state)
	{
		animator.SetBool("PointerEnter", state);
	}
}
