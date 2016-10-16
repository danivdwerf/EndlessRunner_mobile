using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	private float minSwipeDistY;
	private float minSwipeDistX;
	private Vector3 startPos; 
	private PlayerMovement playerMovement;

	private void Start()
	{
		playerMovement = GetComponent<PlayerMovement> ();
		minSwipeDistX = 20f;
		minSwipeDistY = 10f;
	}
	void Update()
	{
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];
			switch (touch.phase) 
			{
				case TouchPhase.Began: startPos = touch.position;
				break;
				case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY)
				{
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					if (swipeValue > 0)
					{
						playerMovement.Jump ();
					}
					else if (swipeValue < 0)
					{
						playerMovement.Slide ();
					}
				}

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX) 
				{
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					if (swipeValue > 0)//right swipe
					{
					playerMovement.SideWays (2);
					}
					else if (swipeValue < 0)
					{
					playerMovement.SideWays (1);
					}
				}
			break;
			}
		}
	}
}