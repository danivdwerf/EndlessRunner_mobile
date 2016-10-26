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
	private SceneSwitcher switcher;
	private QuitGame quitGame;
	private SwitchInstructionsScreen instructionScreen;

	private void Start()
	{
		//Set References
		quitGame = GetComponent<QuitGame> ();
		switcher = GetComponent<SceneSwitcher> ();
		instructionScreen = GetComponent<SwitchInstructionsScreen> ();

		//Button onclick listeners
		play.onClick.AddListener (delegate(){switcher.GameScene();});
		instruction.onClick.AddListener (delegate(){instructionScreen.OpenScreen();});
		quit.onClick.AddListener (delegate(){quitGame.Quit();});
		back.onClick.AddListener (delegate(){instructionScreen.CloseScreen();});
	}
}
