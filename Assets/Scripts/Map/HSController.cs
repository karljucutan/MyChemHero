using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Scripts;

public class HSController : MonoBehaviour
{
	private static HSController instance6;
	
	public static HSController Instance
	{
		get { return instance6; }
	}
	void Awake() {
		
		// If no Player ever existed, we are it.
		if (instance6 == null)
			instance6 = this;


	}
	void Start(){
		startGetScores ();

        HSController.Instance.startGetScores();
	}

	//private string secretKey = "123456789"; // Edit this value and make sure it's the same as the one stored on the server
    //string addScoreURL = "leaderboardtry.000webhostapp.com/addscore.php?"; //be sure to add a ? to your url
    //string highscoreURL = "leaderboardtry.000webhostapp.com/display.php";

	//for testing
	public string uniqueID;
	public string name3;
	int score;


	public string[] onlineHighscore;

	public void startGetScores()
	{
		StartCoroutine(GetScores());
	}
	IEnumerator GetScores()
	{
		Scrolllist.Instance.loading = true;

        WWW hs_get = new WWW(Configuration.BASE_ADDRESS+"display.php");

		yield return hs_get;
		
		if (hs_get.error != null)
		{
			Debug.Log("There was an error getting the high score: " + hs_get.error);

		}
		else
		{
			string help = hs_get.text;

			onlineHighscore  = help.Split(";"[0]);

		}
		Scrolllist.Instance.loading = false;
		Scrolllist.Instance.getScrollEntrys ();
	}
	
}
