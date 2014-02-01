using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour 
{
	public GUIText replayText;

	float saveTime;

	void Update () 
	{
		if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor)
		{
			replayText.text = "press space to replay";

			if (Input.GetButton("Replay"))
			{
				Application.LoadLevel("Play");
			}
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			replayText.text = "touch the screen to replay";
		}


		if (Input.GetKey("r"))
		{
			for (int i = 1; i <= 10; i++)
			{
				PlayerPrefs.SetInt("HScore" + i, 0);
				PlayerPrefs.SetString("HName" + i, "");
			}
			GetComponent<HighScore>().RetreiveScores ();
			GetComponent<HighScore>().DrawScores ();
		}
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (0, Screen.height - 100, 150, 100), "Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}

		if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor)
		{
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 100, 150, 100), "Quit"))
			{
				Application.Quit();
			}
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			if (GUI.Button (new Rect (0, 0, 150, Screen.height - 100), "", GUIStyle.none))
			{
				Application.LoadLevel("Play");
			}
			if (GUI.Button (new Rect (150, 0, Screen.width - 150, Screen.height), "", GUIStyle.none))
			{
				Application.LoadLevel("Play");
			}
		}
	}
}