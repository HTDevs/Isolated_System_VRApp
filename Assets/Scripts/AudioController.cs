using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField]
	private AudioSource[] audios = null;

	public static AudioController Instance { get; set;}

	private void Awake()
	{
		Instance = this;
	}

	public void PlayAudio(int index)
	{
		audios[index].Play();
	}

	public void StopAudio(int index)
	{
		audios[index].Stop();
	}
}