using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderboardUIHandler : MonoBehaviour
{
    [SerializeField]private GameObject inputPanel;
    [SerializeField]private GameObject leaderboardPanel;
	[SerializeField]private Button mainMenu;
	[SerializeField]private Button retryButton;
    [SerializeField]private Text yourScore;
	private SceneSwitcher switcher;
    private void Start()
    {
		switcher = GetComponent<SceneSwitcher> ();
		mainMenu.onClick.AddListener (delegate(){switcher.StartScene();});
		retryButton.onClick.AddListener (delegate(){switcher.GameScene ();});
        inputPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        yourScore.text = "Your score was: " + PlayerPrefs.GetInt("curScore");
    }
    public void deleteInputUI()
    {
        inputPanel.gameObject.SetActive(false);
        leaderboardPanel.SetActive(true);
    }
}
