using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private bool isInGame = false;

	public static GameController Instance { get; set; }
	public bool Load { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (!isInGame)
		{
			StartCoroutine(LoadYourAsyncScene(1));
		}
	}

	public void LoadScene(int index)
	{
		SceneManager.LoadScene(0);
	}

    private IEnumerator LoadYourAsyncScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
		asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
			if (Load)
			{
				asyncLoad.allowSceneActivation = true;
			}

            yield return null;
        }
    }

	public void GameQuit()
	{
		Application.Quit();
	}
}