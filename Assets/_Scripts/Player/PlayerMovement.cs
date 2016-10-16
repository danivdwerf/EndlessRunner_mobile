using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
	private int speed;
	private int gravity;
	private int jump;

	private bool isFalling;

    void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        speed = 20;
		jump = 1500;
		gravity = -5000;
		isFalling = false;

    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
		rigidBody.AddForce (0,gravity,0);
    }

    public void Jump()
    {
		if (!isFalling)
		{
			rigidBody.AddForce (new Vector3 (0, jump, 0), ForceMode.Impulse);
			isFalling = true;
		}
    }

	public void SideWays(int num)
	{
		float xPos = transform.position.x;
		switch (num)
		{
		case 1:
		xPos += 1.5f;
		break;

		case 2:
		xPos -= 1.5f;
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

    private void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.CompareTag (Tags.ground))
		{
			isFalling = false;
		}
    }
}