using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour 
{
    [SerializeField]private AudioClip hurt;
    private PlayerAudio playerAudio;
    private GameOver gameOver;

    private void Start()
    {
        playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
        gameOver = GameObject.FindObjectOfType<GameOver>();
    }

    public void KillPlayer()
    {
        gameOver.StopGameScene();
        playerAudio.PlayAudio(hurt, false);
    }
}
