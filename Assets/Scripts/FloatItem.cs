using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatItem : MonoBehaviour
{
	private Rigidbody physics = null;

	private void Start()
	{
		physics = GetComponent<Rigidbody>();
		
		float x = Random.Range(20f, 50f) * (Random.Range(0, 10) > 5 ? 1 : -1);
		float y = Random.Range(20f, 50f) * (Random.Range(0, 10) > 5 ? 1 : -1);
		float z = Random.Range(20f, 50f) * (Random.Range(0, 10) > 5 ? 1 : -1);
		physics.AddForce(x, y, z, ForceMode.Acceleration);
	}

	private void OnCollisionEnter(Collision other)
	{
		physics.velocity *= 1.5f;
		if (other.gameObject.tag == "Player") 
		{
			physics.velocity *= 5f;
		}
	}
}