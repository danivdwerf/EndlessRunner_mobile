using UnityEngine;
using System.Collections;

public class GetScore : MonoBehaviour 
{
	private int highScore;
	void Awake () 
	{
		if (PlayerPrefs.HasKey ("High Score"))
		{
			highScore = PlayerPrefs.GetInt ("High Score");
		} 
		else
		{
			PlayerPrefs.SetInt ("High Score",0);
			highScore = PlayerPrefs.GetInt ("High Score");
		}
	}

	public int GetHighscore
	{
		get
		{
			return highScore;
		}
	}
}
