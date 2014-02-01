using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject hazard;
	public GameObject[] points;
	
	public bool mobileMode;

	public GUIText scoreText;

	int score;
	float rand;
	
	public float xBorder;
	public float yBorder;

	void Start () 
	{
		score = 0;
		UpdateScore ();
		Instantiate(points[0]);

		float dist = (GetComponent<Transform>().position - Camera.main.transform.position).z;
		xBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x - 0.25f;
		yBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y - 0.25f;
	}

	public void SpawnHazard ()
	{
		Instantiate(hazard);
		SpawnOrb();
	}

	void SpawnOrb ()
	{
		bool fin = false;
		while (fin == false)
		{
			rand = Random.Range (1f, 1000f);
			if (rand <= 250f) { Instantiate(points[0]); }					// 1/4
			if (rand > 250f && rand <= 450f) { Instantiate(points[1]); }	// 1/5
			if (rand > 450f && rand <= 550f) { Instantiate(points[2]); }	// 1/10
			if (rand > 550f && rand <= 625f) { Instantiate(points[3]); }	// 1/13.3
			if (rand > 625f && rand <= 675f) { Instantiate(points[4]); }	// 1/20
			if (rand > 675f && rand <= 695f) { Instantiate(points[5]); }	// 1/50
			if (rand > 695f && rand <= 705f) { Instantiate(points[6]); }	// 1/100
			if (rand > 705f && rand <= 706f) { Instantiate(points[7]); }	// 1/1000
			if (rand <= 706f) { fin = true; }
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		PlayerPrefs.SetInt("Last Score", score);
		Application.LoadLevel ("GameOver");
	}
}
