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
   

    private List<string> myTeamScore = new List<string>(); //List ng city conquered
    private Sprite[] TeamHeroes = new Sprite[4];
    private Sprite[] NumbersImages;
    private Sprite[] StarsImages;

    private List<int> enemyTeamColorId;
    private bool teamNotCompleted = true;
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

        //Counter for the number of cities conquery by my team
        var myTeamCitiesConquered = ListOfCity.Cities.Where(c => c.Sectors.All(s => s.conqueror.TeamId.Equals(DataPersistor.persist.user.TeamId))).Select(c => c.Id).ToList();        
        var myTeamcount = myTeamCitiesConquered.Count().ToString();
        if (myTeamcount.Length > 1)
        {
            myTeam_ScoreTens.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[0])];
            myTeam_ScoreOnes.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[1])];
        }
        else
        {
            myTeam_ScoreOnes.GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(myTeamcount[0])];
        }
        for(int a = 0; a < 19; a++)
        {
            if(myTeamCitiesConquered.Any(id => id.Equals(a + 1)))
            {
                cityStars[a].GetComponent<Image>().overrideSprite = StarsImages[1];
            }
            else
            {
                cityStars[a].GetComponent<Image>().overrideSprite = StarsImages[0];
            }
            
        }
      //  Debug.Log("Conquered By My Team" + myTeamcount + "grpup:" + myTeamCitiesConquered[a]);


        //Counter for the number of cities conquery by enemies team
        if (ListOfTeams.TeamList.Count() > 1)
        {
            for (int i = 0; i < enemyTeamColorId.Count(); i++)
            {
                var enemyCitiesConquered = from c in ListOfCity.Cities
                                           where c.Sectors.All(s => s.conqueror.TeamId.Equals(enemyTeamColorId[i]))
                                           select c;
                var countCities = enemyCitiesConquered.Count().ToString();
                if(countCities.Length > 1)
                {
                    enemyTeam_ScoreTens[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
                    enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[1])];
                    Debug.Log("First Char" + countCities[0] + "SECOND CHAR" + countCities[1]);
                }
                else
                {
                    enemyTeam_ScoreOnes[i].GetComponent<Image>().overrideSprite = NumbersImages[(int)char.GetNumericValue(countCities[0])];
                    Debug.Log("First Char" + countCities[0]);
                }
            }
        }


        //CHECKER KUNG SAME LAHAT NG TEAMID NG MGA CONQEUROR NG SECTOR PER CITY PANG DISPLAY SA STAR 
        //var city1 = GetCity("Group1");
        //if (city1.Sectors.All(s => s.conqueror.TeamId.Equals(city1.Sectors[0].conqueror.TeamId)))
        //{
        //    var teamid = city1.Sectors[0].conqueror.TeamId;
        //    if (DataPersistor.persist.user.TeamId.Equals(teamid))
        //    {
        //        myTeamScore.Add("Group1");
        //    }
        //}


    }
  

    private City GetCity(string cityname)
    {
        var city = ListOfCity.Cities.Where(c => c.Name.Equals(cityname)).FirstOrDefault();
        return city;
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
                ListOfTeams.TeamList.Clear();
                Team tempTeam = new Team();
                for (int i = 0; i < teamInfo.Length - 1; i++)
                {
                    string[] individualValues = teamInfo[i].Split(';');
                    tempTeam = new Team();
                    tempTeam.teamId = int.Parse(individualValues[0]);
                    tempTeam.teamName = individualValues[1];
                    tempTeam.teamColorId = int.Parse(individualValues[2]);

                    ListOfTeams.TeamList.Add(tempTeam);
                }
            }
            yield return new WaitForSeconds(2f);
        }
          

        
    }


}
