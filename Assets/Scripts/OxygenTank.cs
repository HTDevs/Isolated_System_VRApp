using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
	[SerializeField]
	private GameObject hoverMenu = null;
	[SerializeField]
	private Animator hands;
	public bool PointerEnter { get; set; }

	private void Update()
	{
		if (PointerEnter)
		{
			hoverMenu.transform.GetChild(2).GetComponent<Text>().text = "Tanque de Oxigeno.";
			if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				AudioController.Instance.PlayAudio(2);
				hands.GetComponent<Hands>().Selected = 5;
				hands.SetTrigger("TakeOil");
				hands.SetBool("PointerEnter", false);
				hoverMenu.GetComponent<Animator>().SetBool("Active", false);
				TaskController tasks = TaskController.Instance;
				tasks.OxigenTanks++;
				Destroy(gameObject);
			}
		}
	}
}