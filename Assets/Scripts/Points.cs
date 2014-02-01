using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public int pointValue;

	GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		} 
		else	
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			gameController.AddScore (pointValue);
			gameController.SpawnHazard ();
			Destroy(gameObject); 
		}
	}
}
