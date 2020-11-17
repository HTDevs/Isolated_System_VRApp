using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsParallax : MonoBehaviour
{
	private void Update()
	{
		Vector3 rotation = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y + 90f, 0);
		transform.rotation = Quaternion.Euler(rotation);
		transform.position = Camera.main.transform.position;
	}
}