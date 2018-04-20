using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System.Linq;
using Assets.Scripts.Minigame.Models;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    //Stars for City
    public GameObject[] cityStars;

    //My Team
    public GameObject myTeam_TeamLeaderHero;
    public GameObject myTeam_ScoreOnes;
    public GameObject myTeam_ScoreTens;

    public GameObject[] EnemiesContainer = new GameObject[3];

    public GameObject[] enemyTeam_TeamLeaderHero = new GameObject[3];
    public GameObject[] enemyTeam_ScoreOnes = new GameObject[3];
    public GameObject[] enemyTeam_ScoreTens = new GameObject[3];
   
    private Sprite[] TeamHeroes = new Sprite[4];
    private Sprite[] NumbersImages;
    private Sprite[] StarsImages;

    private List<int> enemyTeamColorId;
    private bool teamNotCompleted = true;

    private bool postteam_running;
    // 1 = blue 2 = red 3 = green 4 = yellow
    private void Awake()
    {
        TeamHeroes[0] = Resources.Load<Sprite>("CharacterandHeroAssets/HEROES/BLUE/800px/BLUE-A-800");
        TeamHeroes[1] = Resources.Load<Sprite>("CharacterandHeroAssets/HEROES/RED/800px/RED-A-800");
        TeamHeroes[2] = Resources.Load<Sprite>("CharacterandHeroAssets/HEROES/GREEN/800px/GREEN-A-800");
        TeamHeroes[3] = Resources.Load<Sprite>("CharacterandHeroAssets/HEROES/YELLOW/800px/YELLOW-A-800");

        NumbersImages = Resources.LoadAll<Sprite>("Numbers/number");
        StarsImages = Resources.LoadAll<Sprite>("Sprites/Symbols and Text/Stars");

    }

    private void Start()
    {
        if(teamNotCompleted)
        {
            StartCoroutine(GetTeamsCreated());
        }
        StartCoroutine(GetTeamsScore());
        myTeam_TeamLeaderHero.GetComponent<Image>().overrideSprite = TeamHeroes[DataPersistor.persist.user.TeamId - 1];
    }

    void Update () {
       
        if (teamNotCompleted)
        {
            if (ListOfTeams.TeamList.Count() > 1)
            {
                enemyTeamColorId = ListOfTeams.TeamList.Where(t => !t.teamColorId.Equals(DataPersistor.persist.user.TeamId)).Select(t => t.teamColorId).ToList();
                for (int i = 0; i < enemyTeamColorId.Count(); i++)
                {
                    EnemiesContainer[i].SetActive(true);
                    enemyTeam_TeamLeaderHero[i].GetComponent<Image>().overrideSprite = TeamHeroes[enemyTeamColorId[i] - 1];
                }
                if(ListOfTeams.TeamList.Count() >= 4)
                {
                    teamNotCompleted = false;
                }
            }
        }
       
            //Counter for the number of cities conquer by my team
            var myTeamCitiesConquered = ListOfCity.Cities.Where(c => c.Sectors.All(s => s.conqueror.TeamId.Equals(DataPersistor.persist.user.TeamId))).Select(c => c.Id).ToList();
        var myteam = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(DataPersistor.persist.user.TeamId)).SingleOrDefault();
        foreach (int cityid in myTeamCitiesConquered)
            {
            var exist = myteam.conqueredCities.Any(c => c.Equals(cityid));  
            if (!exist)
                {
                myteam.conqueredCities.Add(cityid);
                //post
                WWWForm form = new WWWForm();
                form.AddField("teamid", myteam.teamId.ToString());
                form.AddField("cityid", cityid.ToString());
                WWW www = new WWW(Configuration.BASE_ADDRESS + "PostTeamScore.php", form);

                StartCoroutine(PostTeamScore(www));
                //StartCoroutine(PostTeamScore(cityid, DataPersistor.persist.user.TeamId));
                  //  StartCoroutine(WaitPost());
                    
                }
            }   
        
            
            if (myteam.conqueredCities.Count() > 0)
            {
                var myTeamcount = myteam.conqueredCities.Count().ToString();
                if (myTeamcount.Length > 1)
                {
                    myTeam_ScoreTens.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[0])];
                    myTeam_ScoreOnes.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[1])];
                }
                else
                {
                    myTeam_ScoreOnes.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[0])];
                }
                for (int a = 0; a < 19; a++)
                {
                    if (myteam.conqueredCities.Any(id => id.Equals(a + 1)))
                    {
                        cityStars[a].GetComponent<Image>().overrideSprite = StarsImages[1];
                    }
                    //else
                    //{
                    //    cityStars[a].GetComponent<Image>().overrideSprite = StarsImages[0];
                    //}

                }
            }

        //NAG ADD LANG NG ADD ANG SCORE NG TEAM DEPENDE SA DAMI NG CURRENT CITY CONQUERED
        //Counter for the number of cities conquery by enemies team
        if (ListOfTeams.TeamList.Count() > 1)
        {
            for (int i = 0; i < enemyTeamColorId.Count(); i++)
            {
                var enemyteam = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(enemyTeamColorId[i])).SingleOrDefault();
                if (enemyteam.conqueredCities.Count() > 0)
                {
                    var countCities = enemyteam.conqueredCities.Count().ToString();
                    if (countCities.ToString().Length > 1)
                    {
                        enemyTeam_ScoreTens[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
                        enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[1])];
                        Debug.Log("First Char" + countCities[0] + "SECOND CHAR" + countCities[1]);
                    }
                    else
                    {
                        enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
                        //Debug.Log("First Char" + countCities[0]);
                    }
                }
            }
        }


        //NAG + - ANG SCORE NG TEAM DEPENDE SA DAMI NG CURRENT CITY CONQUERED
        //Counter for the number of cities conquery by enemies team
        //if (ListOfTeams.TeamList.Count() > 1)
        //{
        //    for (int i = 0; i < enemyTeamColorId.Count(); i++)
        //    {
        //        var enemyCitiesConquered = from c in ListOfCity.Cities
        //                                   where c.Sectors.All(s => s.conqueror.TeamId.Equals(enemyTeamColorId[i]))
        //                                   select c;
        //        var countCities = enemyCitiesConquered.Count().ToString();
        //        if (countCities.Length > 1)
        //        {
        //            enemyTeam_ScoreTens[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
        //            enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[1])];
        //            Debug.Log("First Char" + countCities[0] + "SECOND CHAR" + countCities[1]);
        //        }
        //        else
        //        {
        //            enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
        //            Debug.Log("First Char" + countCities[0]);
        //        }
        //    }
        //}



    }

    IEnumerator GetTeamsCreated()
    {
        while (teamNotCompleted)
        {
            WWW get = new WWW(Configuration.BASE_ADDRESS + "getTeam.php");
            yield return get;

            if (get.error != null)
            {
                Debug.Log("There was an error getting the team: " + get.error);

            }
            else
            {
                string teams = get.text;
                Debug.Log(teams + "");
                string[] teamInfo = teams.Split('+');
                Team tempTeam = new Team();
                for (int i = 0; i < teamInfo.Length - 1; i++)
                {
                    string[] individualValues = teamInfo[i].Split(';');
                    tempTeam = new Team();
                    tempTeam.teamId = int.Parse(individualValues[0]);
                    tempTeam.teamName = individualValues[1];
                    tempTeam.teamColorId = int.Parse(individualValues[2]);

                    if(!ListOfTeams.TeamList.Exists(t => t.teamId.Equals(tempTeam.teamId)))
                    {
                        ListOfTeams.TeamList.Add(tempTeam);
                    }
                }
            }
            yield return new WaitForSeconds(2f);
        } 
    }

    IEnumerator GetTeamsScore()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetTeamScore.php");
        yield return get;
       
        Debug.Log("POLLINGGETTEAMSCORE");
        if (get.error != null)
        {
            Debug.Log("There was an error getting the team: " + get.error);

        }
        else
        {
            string teams = get.text;
            Debug.Log(teams + "");
            string[] teamInfo = teams.Split('+');
            for (int i = 0; i < teamInfo.Length - 1; i++)
            {
                string[] individualValues = teamInfo[i].Split(';');
                var myteam = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(DataPersistor.persist.user.TeamId)).SingleOrDefault();
                var teamid = int.Parse(individualValues[0]);
                var cityid = int.Parse(individualValues[1]);
                if (teamid == myteam.teamId)
                {
                    if (!myteam.conqueredCities.Exists(id => id.Equals(cityid)))
                    {
                        myteam.conqueredCities.Add(cityid);
                    }
                }
                else
                {
                    foreach (int teamcolorid in enemyTeamColorId)
                    {
                        var enemyteam = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(teamcolorid)).SingleOrDefault();
                        if (teamid == enemyteam.teamId)
                        {
                            if (!enemyteam.conqueredCities.Exists(id => id.Equals(cityid)))
                            {
                                enemyteam.conqueredCities.Add(cityid);
                            }
                        }
                    }
                }
            }
        }
        StartCoroutine(GetTeamsScore());
    }

    //IEnumerator PostTeamScore(int teamid, int cityid)
    //{
    //    postteam_running = true;
    //    //Debug.Log("POSTTEAM");

    //    string post_url = Configuration.BASE_ADDRESS + "PostTeamScore.php?teamid=" + teamid + "&cityid=" + cityid;
    //    WWW hs_post = new WWW(post_url);
    //    yield return hs_post; // Wait until the download is done

    //    if (hs_post.error != null)
    //    {
    //        print("There was an error posting the team score: " + hs_post.error);
    //    }
    //    postteam_running = false;
    //}
    IEnumerator PostTeamScore(WWW www)
    {
        postteam_running = true;
        //Debug.Log("POSTTEAM");
        yield return www;
        //string post_url = Configuration.BASE_ADDRESS + "PostTeamScore.php?teamid=" + teamid + "&cityid=" + cityid;
        // WWW hs_post = new WWW(post_url);
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator WaitPost()
    {
        while(postteam_running)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
    }

}
