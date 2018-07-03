using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public GameObject GameOverPanel;
    public Text VictorTeamName;
    public int winnerTeamId;
    bool done = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(GetWinner());
    }

    IEnumerator GetWinner()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetWinner.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the winner: " + get.error);
        }
        else
        {
            var teamid = get.text;
            if(!string.IsNullOrEmpty(teamid))
            {
                int.TryParse(teamid, out winnerTeamId);
                GameOverPanel.SetActive(true);
                var teamname = ListOfTeams.TeamList.Where(t => t.teamId.Equals(winnerTeamId)).Select(t => t.teamName).SingleOrDefault();
                VictorTeamName.text = teamname;
                done = true;
            }
        }
        if(!done)
        {
            StartCoroutine(GetWinner());
        }
    }
}
