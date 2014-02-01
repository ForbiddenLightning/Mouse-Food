using UnityEngine;
using System.Collections;

[System.Serializable]
public class Phase
{
	public bool willPhase;
	public float flashTime, flashNo;
}

public class GameOver : MonoBehaviour 
{
	public Phase phaseClass;
	GameController gameController;

	bool phase = false;

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

		if (phaseClass.willPhase == true)
		{
			StartCoroutine (Phase ());
		}
	}
	
	 public IEnumerator Phase ()
	{
		phase = true;

		for (int i = 1; i <= phaseClass.flashNo; i++)
		{
			if (i % 2 == 0)	// Is even
			{
				GetComponent <SpriteRenderer>().enabled = true;
			}
			else
			{
				GetComponent <SpriteRenderer>().enabled = false;
			}
			yield return new WaitForSeconds (phaseClass.flashTime);
		}

		GetComponent <SpriteRenderer>().enabled = true;
		phase = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && phase == false)
		{
			gameController.GameOver ();
		}
	}
}
