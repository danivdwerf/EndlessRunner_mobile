using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartscreenInput : MonoBehaviour 
{
	//Fetch aal buttons
	[SerializeField] private Button play;
	[SerializeField] private Button instruction;
	[SerializeField] private Button quit;
	[SerializeField] private Button back;

	//script references
	private QuitGame quitGame;
	private SwitchInstructionsScreen instructionScreen;
	private LoadGame loadGame;

	private void Start()
	{
		//Set References
		quitGame = GetComponent<QuitGame> ();
		instructionScreen = GetComponent<SwitchInstructionsScreen> ();
		loadGame = GetComponent<LoadGame> ();

		//Button onclick listeners
		play.onClick.AddListener (delegate(){loadGame.LoadScene();});
		instruction.onClick.AddListener (delegate(){instructionScreen.OpenScreen();});
		quit.onClick.AddListener (delegate(){quitGame.Quit();});
		back.onClick.AddListener (delegate(){instructionScreen.CloseScreen();});
	}
}
