using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using Sirenix.OdinInspector;

public class OxygenSystemItem : MonoBehaviour
{
	[SerializeField]
	private int index = 0;
	[SerializeField]
	private string name = "";
	[SerializeField]
	private string description = "";
	[SerializeField]
	private bool isLost = false;
	[SerializeField]
	private TaskController taskController;
	[SerializeField]
	private Animator hands;
	[HideIf("isLost")]
	[SerializeField]
	private Material completeMaterial = null;
	[Title("User Interfece")]
	[SerializeField]
	private GameObject hoverMenu = null;
	[SerializeField]
	private GameObject uiIcon = null;
	
	public bool PointerEnter { get; set; }

	private void Update()
	{
		if (PointerEnter)
		{
			hoverMenu.transform.GetChild(2).GetComponent<Text>().text = description;
			if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				TaskController tasks = TaskController.Instance;

				if (isLost)
				{
					AudioController.Instance.PlayAudio(1);
					uiIcon.SetActive(true);
					hands.GetComponent<Hands>().Selected = index;
					hands.SetTrigger("Take" + name);
					hands.SetBool("PointerEnter", false);
					hoverMenu.GetComponent<Animator>().SetBool("Active", false);
					tasks.ItemsCollected[index] = true;
					Destroy(gameObject);
				}
				else
                {
                    if (tasks.TaskStatements[index] || !tasks.ItemsCollected[index]) 
                    {
                        return; // Si la tarea ya se completó o aun no ha recolectado el objeto.
                    }

                    foreach (MeshRenderer item in GetComponentsInChildren<MeshRenderer>())
                    {
                        item.material = completeMaterial;
                    }

					AudioController.Instance.PlayAudio(1);
					hands.GetComponent<Hands>().Selected = index;
					hands.SetTrigger("Untake" + name);
					hands.SetBool("PointerEnter", false);
					hoverMenu.GetComponent<Animator>().SetBool("Active", false);
                    tasks.TaskComplete(index);
					Destroy(GetComponent<EventTrigger>());
					Destroy(this);
                }
            }
		}
	}
}