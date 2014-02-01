using UnityEngine;
using System.Collections;
using System;

public class HighScore : MonoBehaviour 
{
	public int[] highScores;
	public string[] highNames;

	string[] highScoreString;

	public GUIText highScoresList;
	public GUIText scoresText;
	public GUIText highScoresPunct;
	public GUIText highScoresNames;

	void Start () 
	{
		int lastScore = PlayerPrefs.GetInt("Last Score");
		scoresText.text = "Score: " + lastScore;

		string playerName = PlayerPrefs.GetString("Name");

		highScores = new int[11];
		highNames = new string[11];

		RetreiveScores ();

		for (int i = 0; i <= 9; i++)
		{
			if (lastScore > highScores[i])
			{
				int j;
				for (j = 8; j >= i; j--)
				{
					highScores[j+1] = highScores[j];
					highNames[j+1] = highNames[j];
				}
				j++;
				highScores[j] = lastScore;
				highNames[j] = playerName;
				i = 10;
			}
		}

		DrawScores ();
	}

	public void RetreiveScores ()
	{
		for (int i = 1;  i <= 10; i++)
		{
			if (PlayerPrefs.HasKey("HScore" + i) == false)
			{
				PlayerPrefs.SetInt("HScore" + i, 0);
				PlayerPrefs.SetString("HName" + i, "");
			}
			highScores[i-1] = PlayerPrefs.GetInt("HScore" + i);
			highNames[i-1] = PlayerPrefs.GetString("HName" + i);
		}
	}

	public void DrawScores ()
	{
		highScoreString = new string[3];
		highScoreString[1] = "High Scores";
		for (int i = 1; i <= 10; i++)
		{
			PlayerPrefs.SetInt ("HScore" + i, highScores[i-1]);
			PlayerPrefs.SetString ("HName" + i, highNames[i-1]);
			
			highScoreString[0] = highScoreString[0] + Environment.NewLine + highNames[i-1];
			highScoreString[1] = highScoreString[1] + Environment.NewLine + "-";
			highScoreString[2] = highScoreString[2] + Environment.NewLine + highScores[i-1];
		}
		highScoresNames.text = highScoreString[0];
		highScoresPunct.text = highScoreString[1];
		highScoresList.text = highScoreString[2];
	}
}