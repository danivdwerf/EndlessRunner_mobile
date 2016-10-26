using UnityEngine;
using System.Collections;

public class SwitchInstructionsScreen : MonoBehaviour 
{
	[SerializeField]private GameObject screen;
	[SerializeField]private ParticleSystem ps;
	[SerializeField]private AnimationClip animation;
	private Animation anim;

	private void Start()
	{
		screen.SetActive (false);
		anim = screen.GetComponent<Animation> ();
		ps.Stop ();
		anim.Stop ();
	}
	public void OpenScreen()
	{
		screen.SetActive (true);
		anim.clip = animation;
		anim.Play ();
	}

	public void CloseScreen ()
	{
		screen.SetActive (false);
		ps.Play();
	}
}
