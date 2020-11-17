using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemsEmission : MonoBehaviour
{
	public Color color;
	public Material[] itemMaterials = null;

	private void Update()
	{
		foreach (Material item in itemMaterials)
		{
			item.SetColor("_EmissionColor", color);
		}
	}
}