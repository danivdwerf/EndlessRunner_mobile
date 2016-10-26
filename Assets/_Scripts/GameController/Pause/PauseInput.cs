using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseInput : MonoBehaviour 
{
    private PauseLogic pauseLogic;
	private SceneSwitcher sceneSwitcher;

	[SerializeField] private Button pause;
	[SerializeField] private Button main;
	[SerializeField] private Button backButton;
    private void Start()
    {
        pauseLogic = GetComponent<PauseLogic>(); 
		sceneSwitcher = GetComponent<SceneSwitcher> ();

		pause.onClick.AddListener (delegate(){pauseLogic.GetInput();}); 
		main.onClick.AddListener (delegate(){pauseLogic.GetInput();sceneSwitcher.StartScene();});
		backButton.onClick.AddListener (delegate(){pauseLogic.GetInput();});
    }
}
