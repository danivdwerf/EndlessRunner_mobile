using UnityEngine;
using System.Collections;

public class CheckPlayerHeight : MonoBehaviour 
{
    private Die die;

    private void Start()
    {
        die = GetComponent<Die>();
    }

    private void Update()
    {
        if (transform.position.y <= -1)
        {
			die.KillPlayer();
        }
    }
}
