using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameController gameController;

	public float speed;
	public float mobileSpeed;
	public float rotation;
	public float mobileRotation;

	int direction = 0;

	void FixedUpdate () 
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			float realRotation = mobileRotation * Time.deltaTime;
			
			if (Input.GetTouch(0).position.x >= Screen.width / 2)
			{
				transform.Rotate (0, 0, -realRotation);
			} 
			else if (Input.GetTouch(0).position.x < Screen.width / 2)
			{
				transform.Rotate (0, 0, realRotation);
			} 
			
			float realSpeed = mobileSpeed * Time.deltaTime;
			rigidbody2D.velocity = transform.up * realSpeed;
		}

		else
		{
			if (PlayerPrefs.GetInt("Control") == 1)
			{
				if (Input.GetButton("Up") && direction != 2)
				{
					direction = 0;
				} 
				else if (Input.GetButton("Right") && direction != 3)
				{
					direction = 1;
				}
				else if (Input.GetButton("Down") && direction != 0)
				{
					direction = 2;
				}
				else if (Input.GetButton("Left") && direction != 1)
				{
					direction = 3;
				}
				
				float realSpeed = speed * Time.deltaTime;
				
				switch (direction)
				{
				case 0:
					transform.localEulerAngles = new Vector3 (0, 0, 0);
					rigidbody2D.velocity = new Vector2(0, realSpeed);
					break;
				case 1:
					transform.localEulerAngles = new Vector3 (0, 0, 270);
					rigidbody2D.velocity = new Vector2(realSpeed, 0);
					break;
				case 2:
					transform.localEulerAngles = new Vector3 (0, 0, 180);
					rigidbody2D.velocity = new Vector2(0, -realSpeed);
					break;
				case 3:
					transform.localEulerAngles = new Vector3 (0, 0, 90);
					rigidbody2D.velocity = new Vector2(-realSpeed, 0);
					break;
				}
			}

			if (PlayerPrefs.GetInt("Control") == 2)
			{
				float realRotation = rotation * Time.deltaTime;
				
				if (Input.GetButton("Right"))
				{
					transform.Rotate (0, 0, -realRotation);
				} 
				else if (Input.GetButton("Left"))
				{
					transform.Rotate (0, 0, realRotation);
				} 
				
				float realSpeed = speed * Time.deltaTime;
				rigidbody2D.velocity = transform.up * realSpeed;
			}
		}
	}

	void Update ()
	{
		if (transform.position.x > gameController.xBorder || transform.position.x < -gameController.xBorder || transform.position.y > gameController.yBorder || transform.position.y < -gameController.yBorder)
		{
			gameController.GameOver();
		}
	}
}
