using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour 
{
	private float percentage;
	private LoadUI loadUI;
	private void Start()
	{
		loadUI = GetComponent<LoadUI> ();
	}
	public void LoadScene()
	{
		percentage = 0;
		StartCoroutine ("Load");
	}

	IEnumerator Load()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(1);
		while (!async.isDone)
		{
			percentage = Mathf.Floor ((async.progress * 100) / 0.9f);
			loadUI.UpdateUI ();
			yield return null;
		}
	}

	public float GetPercentage
	{
		get
		{ 
			return percentage;
		}
	}
}
