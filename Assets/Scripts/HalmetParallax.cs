using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalmetParallax : MonoBehaviour
{
	[SerializeField]
	private Transform target = null;

	private void Update()
	{
		transform.position = target.position;
		transform.rotation = target.rotation;
	}
}