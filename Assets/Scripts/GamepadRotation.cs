using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadRotation : MonoBehaviour {

	private float h = 0f;
	private float v = 0f;
	private Vector3 rotation = Vector3.zero;

	private void FixedUpdate()
	{
		h = Mathf.MoveTowards(h, Input.GetAxis("TurnH"), Time.deltaTime * 4f);
		v = Mathf.MoveTowards(v, Input.GetAxis("TurnV"), Time.deltaTime * 4f);
		Vector3 amount = new Vector3(h, v, 0);
		rotation += amount * 1.5f;
		rotation = new Vector3(Mathf.Clamp(rotation.x, -90f, 90f), rotation.y, 0);
		transform.rotation = Quaternion.Euler(rotation);
	}
}