using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour 
{
	[SerializeField] private Text score;
	[SerializeField] private Text highscore;
	void Update () 
	{
		score.text = "Score: " + PlayerPrefs.GetInt ("curScore");
		highscore.text = "Highscore: " + PlayerPrefs.GetInt ("High Score");
	}
}
