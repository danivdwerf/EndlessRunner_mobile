using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
	private int speed;
	private int gravity;
	private int jump;
	private bool isFalling;
	private RaycastHit hit;
	private PlayerAudio playerAudio;

	[SerializeField]private AudioClip running;
	[SerializeField]private AudioClip sliding;
	[SerializeField]private AudioClip[] jumpSounds;

    void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        speed = 20;
		jump = 2000;
		gravity = -7000;
		isFalling = false;
		playerAudio = GameObject.FindObjectOfType<PlayerAudio> ();
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
		rigidBody.AddForce (0,gravity,0);
    }

	private void Run()
	{
		isFalling = false;
		playerAudio.PlayAudio (running,true);
	}

    public void Jump()
    {
		if (!isFalling)
		{
			isFalling = true;
			rigidBody.AddForce (new Vector3 (0, jump, 0), ForceMode.Impulse);
			playerAudio.PlayAudio(jumpSounds[Random.Range(0,jumpSounds.Length)],false);
		}
    }

	public void SideWays(int num)
	{
		float posX = transform.position.x;
		switch (num)
		{
			case 1:
			transform.position = new Vector3 (posX-=1.5f,transform.position.y,transform.position.z);
			break;

			case 2:
			transform.position = new Vector3 (posX+=1.5f,transform.position.y,transform.position.z);
			break;
		}
		
	}

    public void Slide()
    {
		StartCoroutine (Sliding ());
    }

	IEnumerator Sliding()
	{
		transform.localScale = new Vector3 (1f,0.2f,1f);
		yield return new WaitForSeconds (1f);
		transform.localScale = new Vector3 (1f,1f,1f);
	}

	void Update()
	{
		CheckState ();
	}

	private void CheckState()
	{
		if (Physics.Raycast (transform.position, Vector3.down, out hit))
		{
			if (hit.collider.CompareTag (Tags.ground))
			{
				if (hit.distance == 1)
				{
					Run ();
				}
			}
		}
	}
}