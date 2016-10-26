using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour
{
    private int score;
	private int highscore;
	private GetScore getScore;

    private void Start()
	{
        score = 0;
		getScore = GetComponent<GetScore> ();
		highscore = getScore.GetHighscore;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("curScore", score);
		if(score > highscore)
        {
			PlayerPrefs.SetInt("High Score", score);
        }
    }

	private void FixedUpdate()
	{
		score++;
	}
}