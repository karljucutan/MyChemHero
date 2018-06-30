using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {

    public List<User> leaders;
    public GameObject profilesetter;
    public GameObject scoremanager;
    //individual
    public Transform contentsizefilter;
    public GameObject prefabPanelPlayerPoints;
    public GameObject prefabPlanelPlayerSectors;
    public GameObject prefabPanelPlayersHelpsMade;


    //team
    public Transform Teamcontentsizefilter;
    public GameObject prefabTeamPanelPlayerPoints;
    public GameObject prefabTeamPanelPlayerSectors;
    public GameObject prefabTeamPanelPlayersHelpsMade;

    private void OnEnable()
    {
        leaders = new List<User>();
        
        if(DataPersistor.persist.doneLoadingAllUsers)
        {
            LeaderBoardPoints();
            TeamLeaderBoardPoints();
        }
    }
   
    public void LeaderBoardPoints()
    {
        deleteContent(contentsizefilter);
        int i = 1;

        var players = ListOfUser.ALLUSERS.Where(u => u.TotalScore > 0 ).Select(u => new { u.UserName, u.TeamId, u.TotalScore }).OrderByDescending(u => u.TotalScore).ToList();
        foreach (var player in players)
        {
            var clone = Instantiate(prefabPanelPlayerPoints, contentsizefilter);
            var rank = clone.transform.GetChild(0).gameObject;
            rank.GetComponent<Text>().text = i.ToString();
            var username = clone.transform.GetChild(1).gameObject;
            username.GetComponent<Text>().text = player.UserName;
            var teamname = clone.transform.GetChild(2).gameObject;
            teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(player.TeamId)).Select(t => t.teamName).SingleOrDefault();
            var points = clone.transform.GetChild(4).gameObject;
            points.GetComponent<Text>().text = player.TotalScore.ToString();
            var flag = clone.transform.GetChild(5).gameObject;
            flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[player.TeamId - 1];

            i++;
        }
    }

    public void LeaderboardSectors()
    {
        deleteContent(contentsizefilter);
        int i = 1;

        var players = ListOfUser.ALLUSERS.Where(u => u.SectorsHold > 0 ).Select(u => new { u.UserName, u.TeamId, u.SectorsHold }).OrderByDescending(u => u.SectorsHold).ToList();
        foreach (var player in players)
        {
            var clone = Instantiate(prefabPlanelPlayerSectors, contentsizefilter);
            var rank = clone.transform.GetChild(0).gameObject;
            rank.GetComponent<Text>().text = i.ToString();
            var username = clone.transform.GetChild(1).gameObject;
            username.GetComponent<Text>().text = player.UserName;
            var teamname = clone.transform.GetChild(2).gameObject;
            teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(player.TeamId)).Select(t => t.teamName).SingleOrDefault();
            var points = clone.transform.GetChild(4).gameObject;
            points.GetComponent<Text>().text = player.SectorsHold.ToString();
            var flag = clone.transform.GetChild(5).gameObject;
            flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[player.TeamId - 1];

            i++;
        }
    }

    public void LeaderboardHelpsMade()
    {
        deleteContent(contentsizefilter);
        int i = 1;

        var players = ListOfUser.ALLUSERS.Where(u => u.HelpsMade > 0).Select(u => new { u.UserName, u.TeamId, u.HelpsMade }).OrderByDescending(u => u.HelpsMade).ToList();
        foreach (var player in players)
        {
            var clone = Instantiate(prefabPanelPlayersHelpsMade, contentsizefilter);
            var rank = clone.transform.GetChild(0).gameObject;
            rank.GetComponent<Text>().text = i.ToString();
            var username = clone.transform.GetChild(1).gameObject;
            username.GetComponent<Text>().text = player.UserName;
            var teamname = clone.transform.GetChild(2).gameObject;
            teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(player.TeamId)).Select(t => t.teamName).SingleOrDefault();
            var points = clone.transform.GetChild(4).gameObject;
            points.GetComponent<Text>().text = player.HelpsMade.ToString();
            var flag = clone.transform.GetChild(5).gameObject;
            flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[player.TeamId - 1];

            i++;
        }
    }

    public void TeamLeaderBoardPoints()
    {
        deleteContent(Teamcontentsizefilter);
        int i = 0;

        var players = ListOfUser.ALLUSERS
                    .GroupBy(u => u.TeamId)
                    .Select(u => new {
                         teamid = u.Key,
                         total = u.Sum(g => g.TotalScore)}).OrderByDescending(u => u.total);
        foreach (var p in players)
        {
            if (p.total > 0)
            {
                var clone = Instantiate(prefabTeamPanelPlayerPoints, Teamcontentsizefilter);
                var rank = clone.transform.GetChild(0).gameObject;
                rank.GetComponent<Text>().text = i.ToString();
                var flag = clone.transform.GetChild(1).gameObject;
                flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[p.teamid - 1];
                var teamname = clone.transform.GetChild(2).gameObject;
                teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(p.teamid)).Select(t => t.teamName).SingleOrDefault();
                var points = clone.transform.GetChild(4).gameObject;
                points.GetComponent<Text>().text = p.total.ToString();

                i++;
            }
      
        }
    }

    public void TeamLeaderBoardSectors()
    {
        deleteContent(Teamcontentsizefilter);
        int i = 0;

        var players = ListOfUser.ALLUSERS
                    .GroupBy(u => u.TeamId)
                    .Select(u => new {
                        teamid = u.Key,
                        total = u.Sum(g => g.SectorsHold)
                    }).OrderByDescending(u => u.total);
        foreach (var p in players)
        {
            if (p.total > 0)
            {
                var clone = Instantiate(prefabTeamPanelPlayerSectors, Teamcontentsizefilter);
                var rank = clone.transform.GetChild(0).gameObject;
                rank.GetComponent<Text>().text = i.ToString();
                var flag = clone.transform.GetChild(1).gameObject;
                flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[p.teamid - 1];
                var teamname = clone.transform.GetChild(2).gameObject;
                teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(p.teamid)).Select(t => t.teamName).SingleOrDefault();
                var points = clone.transform.GetChild(4).gameObject;
                points.GetComponent<Text>().text = p.total.ToString();

                i++;
            }
        }
    }

    public void TeamLeaderBoardHelpsMade()
    {
        deleteContent(Teamcontentsizefilter);
        int i = 0;

        var players = ListOfUser.ALLUSERS
                    .GroupBy(u => u.TeamId)
                    .Select(u => new {
                        teamid = u.Key,
                        total = u.Sum(g => g.HelpsMade)
                    }).OrderByDescending(u => u.total);
        foreach (var p in players)
        {
            if (p.total > 0)
            {
                var clone = Instantiate(prefabTeamPanelPlayersHelpsMade, Teamcontentsizefilter);
                var rank = clone.transform.GetChild(0).gameObject;
                rank.GetComponent<Text>().text = i.ToString();
                var flag = clone.transform.GetChild(1).gameObject;
                flag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[p.teamid - 1];
                var teamname = clone.transform.GetChild(2).gameObject;
                teamname.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(p.teamid)).Select(t => t.teamName).SingleOrDefault();
                var points = clone.transform.GetChild(4).gameObject;
                points.GetComponent<Text>().text = p.total.ToString();

                i++;
            }
        }
    }

    private void deleteContent(Transform contentfilter)
    {
        foreach (Transform child in contentfilter.transform)
        {
            Destroy(child.gameObject);
        }
    }
   
    
}
