using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class MenuGaze : MonoBehaviour
{
	[SerializeField]
	private Image gazeImage = null;
	[SerializeField]
	private UnityEvent onGaze = null;

	public float time { get; set; }

	private void Update()
	{
		time += Time.deltaTime;

		if (time > 3f)
		{
			time = 3f;
			onGaze.Invoke();
		}

		gazeImage.fillAmount = time / 3f;
	}
}