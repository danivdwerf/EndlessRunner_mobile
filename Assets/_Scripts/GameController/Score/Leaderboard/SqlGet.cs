using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SqlGet : MonoBehaviour 
{
	private string highscoreURL = "http://freetimedev.com/Highscores/getScore.php";
	[SerializeField] private Text loadingText;

	public void GetScore()
	{
		StartCoroutine("GetScores");
	}

	IEnumerator GetScores()
	{
		loadingText.text = "Loading Scores...";
		yield return new WaitForSeconds(0.5f);
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;

		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			loadingText.text = hs_get.text;
		}
	}
}
