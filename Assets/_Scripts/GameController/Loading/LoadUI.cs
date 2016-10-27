using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadUI : MonoBehaviour 
{
	private LoadGame loadGame; 
	[SerializeField] private Text loadPercentage;
	[SerializeField] private GameObject loadingScreen;
	[SerializeField] private Slider progressBar;

	private void Start()
	{
		loadingScreen.SetActive (false);
		loadGame = GetComponent<LoadGame>();
	}

	public void UpdateUI()
	{
		float percentage = loadGame.GetPercentage;
		loadingScreen.SetActive (true);
		loadPercentage.text = percentage + "%";
		progressBar.value= (percentage/100);
	}
}
