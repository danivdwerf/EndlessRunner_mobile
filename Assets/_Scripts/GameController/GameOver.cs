using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	private SetScore score;
	private PlayerMovement playerMovement;
	private PlayerInput playerInput;
	private SceneSwitcher switcher;
    public void StopGameScene()
    {
		score = GetComponent<SetScore> ();
		playerMovement = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerMovement> ();
		playerInput = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerInput> ();
		switcher = GetComponent<SceneSwitcher> ();
        StartCoroutine(StopGame());
    }

    IEnumerator StopGame()
    {
		score.enabled = false;
        playerMovement.enabled = false;
        playerInput.enabled = false;
        TrackBuilder.trackBuilder.enabled = false;
        yield return new WaitForSeconds(3f);
        switcher.RetryScene();
    }
}
