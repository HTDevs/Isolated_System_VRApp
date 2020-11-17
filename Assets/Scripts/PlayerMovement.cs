using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    private float time = 0f;
    private float push = 0.5f;
    private const float MAX_DELTA = 1.5f;
    private Vector3 speed = Vector3.zero;
    private Vector3 momentum = Vector3.zero;

	private void FixedUpdate ()
	{
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        time = Time.deltaTime;

        Vector3 right = Camera.main.transform.right;
        right = new Vector3(right.x, 0, right.z);
        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
        push = Mathf.MoveTowards(push, 0.5f, time * MAX_DELTA);

        if (push == 0.5f)
        {
            if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.Space))
            {
                push = 5.0f;
                momentum = camForward_Dir;
            }

            speed = vertical * camForward_Dir + horizontal * right;
        }
        else
        {
            speed = push * momentum;
        }

        speed = transform.InverseTransformDirection(speed);
        transform.Translate(speed * time);
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rigid")
        {
            AudioController.Instance.PlayAudio(4);
            push = 0.5f;
        }
    }
}