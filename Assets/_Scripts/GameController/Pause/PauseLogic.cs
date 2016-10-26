using UnityEngine;
using System.Collections;

public class PauseLogic : MonoBehaviour 
{
    [SerializeField] private GameObject pausePanel;
	private PlayerMovement playerMovement;
	private PlayerInput playerInput;
	private AudioSource playerAudio;
    private bool paused;

    void Start()
    {
        pausePanel.SetActive(false);
		playerMovement = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerMovement> ();
		playerInput = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerInput> ();
        paused = false;
		playerAudio = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void GetInput()
    {
		switch (paused)
		{
		case true:
		ContinueGame ();
		break;
		case false:
		PauseGame ();
		break;
		}
    }

    private void PauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
			playerInput.enabled = false;
			playerMovement.enabled = false;
			playerAudio.clip = null;
            pausePanel.SetActive(true);
        }
    }

    private void ContinueGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
			playerInput.enabled = true;
			playerMovement.enabled = true;
            pausePanel.SetActive(false);
        }
    }
}
