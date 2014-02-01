using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour 
{
	string playerName;
	bool dControl;
	bool rControl;

	void Start ()
	{
		if (PlayerPrefs.HasKey ("Name") == false)
		{
			PlayerPrefs.SetString ("Name", "Name");
		}
		playerName = PlayerPrefs.GetString ("Name");

		if (PlayerPrefs.HasKey ("Control") == false)
		{
			PlayerPrefs.SetInt ("Control", 1);
		}
		if (PlayerPrefs.GetInt ("Control") == 1)
		{
			dControl = true;
			rControl = false;
		}
		if (PlayerPrefs.GetInt ("Control") == 2)
		{
			dControl = false;
			rControl = true;
		}
	}
	
	public Texture playButton, quitButton;

	void OnGUI ()
	{
		/* MANUAL
		playerName = GUI.TextField (new Rect (Screen.width / 2 - 100, 175, 200, 40), playerName, 10, textField);
		playerName = playerName.Replace("\n","");
		PlayerPrefs.SetString ("Name", playerName);

		if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 100), "Play"))
		{
			Application.LoadLevel("Play");
			PlayerPrefs.SetString ("Name", playerName);
		}

		if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 + 100, 150, 50), "Quit"))
		{
			Application.Quit();
		}
		*/

		GUILayout.BeginArea (new Rect (Screen.width/2 - 150, Screen.height/2 - 150, 300, 300));

		playerName = GUILayout.TextField (playerName, 10);
		playerName = playerName.Replace("\n","");

		GUILayout.FlexibleSpace();

		GUILayout.Label ("Control typre:");
		dControl = GUILayout.Toggle (dControl, "Directional");
		rControl = GUILayout.Toggle (rControl, "Rotational");
		if (dControl && rControl)
		{
			if (PlayerPrefs.GetInt ("Control") == 1)
			{
				dControl = false;
				rControl = true;
				PlayerPrefs.SetInt ("Control", 2);
			}
			else if (PlayerPrefs.GetInt ("Control") == 2)
			{
				dControl = true;
				rControl = false;
				PlayerPrefs.SetInt ("Control", 1);
			}
		}
		if (!dControl && !rControl)
		{
			if (PlayerPrefs.GetInt ("Control") == 1)
			{
				dControl = true;
			}
			if (PlayerPrefs.GetInt ("Control") == 2)
			{
				rControl = true;
			}
		}

		GUILayout.FlexibleSpace();
		
		if (GUILayout.Button (playButton))
		{
			Application.LoadLevel("Play");
			PlayerPrefs.SetString ("Name", playerName);
		}

		GUILayout.FlexibleSpace();

		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			if (GUILayout.Button (quitButton))
			{
				Application.Quit();
			}
		}

		GUILayout.EndArea ();
	}

	void Update ()
	{
		if (Input.GetKey("x") && Input.GetKey("k") && Input.GetKey("t"))
		{
			PlayerPrefs.DeleteAll ();
			Application.LoadLevel ("MainMenu");
		}
	}
}
