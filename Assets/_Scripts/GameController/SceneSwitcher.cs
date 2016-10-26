using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour 
{
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(2);
    }
}