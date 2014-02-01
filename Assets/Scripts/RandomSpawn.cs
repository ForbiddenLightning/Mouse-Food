using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {

	int i = 0;

	public float spawnTime;

	GameController gameController;

	void RandomPosition ()
	{
		transform.position = new Vector3
		(
			Mathf.Round (Random.Range (-gameController.xBorder, gameController.xBorder) * 2) / 2,
			Mathf.Round (Random.Range (-gameController.yBorder, gameController.yBorder) * 2) / 2,
			1
		);
		spawnTime = Time.time;
	}

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

		RandomPosition();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Point" || other.tag == "X")
		{
			i++;

			if (other.GetComponent<RandomSpawn>().spawnTime <= spawnTime)
			{
				RandomPosition();
			}
		}
	}
}