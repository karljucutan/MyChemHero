using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CityColorManager : MonoBehaviour {

    public GameObject Scoremanager;

    public GameObject[] CityId1;
    public GameObject[] CityId2;
    public GameObject[] CityId3;
    public GameObject[] CityId4;
    public GameObject[] CityId5;
    public GameObject[] CityId6;
    public GameObject[] CityId7;
    public GameObject[] CityId8;
    public GameObject[] CityId9;
    public GameObject[] CityId10;
    public GameObject[] CityId11;
    public GameObject[] CityId12;
    public GameObject[] CityId13;
    public GameObject[] CityId14;
    public GameObject[] CityId15;
    public GameObject[] CityId16;
    public GameObject[] CityId17;
    public GameObject[] CityId18;
    public GameObject[] CityId19;

    // 1 = blue 2 = red 3 = green 4 = yellow


    // COLOR NG CITY IF NOT CONQUERED
    //private int[] CityId1;
    //private int[] CityId2;
    //private int[] CityId3;
    //private int[] CityId4;
    //private int[] CityId5;
    //private int[] CityId6;
    //private int[] CityId7;
    //private int[] CityId8;
    //private int[] CityId9;
    //private int[] CityId10;
    //private int[] CityId11;
    //private int[] CityId12;
    //private int[] CityId13;
    //private int[] CityId14;
    //private int[] CityId15;
    //private int[] CityId16;
    //private int[] CityId17;
    //private int[] CityId18;
    //private int[] CityId19;
    private void Start()
    {
        StartCoroutine(waitRetrieve());
    }
    private IEnumerator waitRetrieve()
    {
        Debug.Log("WAIT RETRIEVE");
        if (!DataPersistor.persist.doneLoadingAllUsers)
            yield return new WaitForSeconds(0.1f);

        colorChanger();
    }
    void colorChanger()
    {
        if (DataPersistor.persist.doneLoadingAllUsers)
        {
            // KUNIN MUNA LAHAT NG CITIES NA CONQUERED NG TEAM TAPOS CHANGE YUNG property na conquerorteam sa city TAPOS CHECK YUNG conquerorteam ICOMPARE SA listteam teamcolorid TAPOS CHANGE COLOR
            //var asd = ListOfCity.Cities.Where(c => c.Sectors.All(s => s.conqueror.TeamId.Equals(DataPersistor.persist.user.TeamId))).ToList();
            //foreach (var city in asd)
            //{
            //    city.ConquerorTeam = DataPersistor.persist.user.TeamId;
            //    //CityToChange(city.Id, DataPersistor.persist.user.TeamId);
            //}

            // my team and enemy team are separated para mas readable
            var citiesCount = ListOfCity.Cities.Count();
            for(int i = 1; i < citiesCount; i++)
            {
                var city = ListOfCity.Cities.Where(c => c.Id.Equals(i)).SingleOrDefault();

                //var conquered = city.Sectors.All(s => s.conqueror.TeamId.Equals(DataPersistor.persist.user.TeamId));
                //if(conquered)
                //{
                //    city.ConquerorTeam = DataPersistor.persist.user.TeamId;
                //}
                //else
                //{
                //    city.ConquerorTeam = -1;
                //}
    
                var TeamColorId = Scoremanager.GetComponent<ScoreManager>().enemyTeamColorId;
                TeamColorId.Add(DataPersistor.persist.user.TeamId);
                for (int z = 0; z < TeamColorId.Count; z++)
                {
                    var conquered = city.Sectors.All(s => s.conqueror.TeamId.Equals(TeamColorId[z]));
                    if(conquered)
                    {
                        city.ConquerorTeam = TeamColorId[z];break;
                    }
                    else
                    {
                        city.ConquerorTeam = -1;
                    }
                }

                if (city.ConquerorTeam != -1)
                {
                    CityToChange(city.Id, city.ConquerorTeam);
                }
                else
                {
                    CityToChange(city.Id, -1);
                }
            }

            ////kunin lahat ng conquered cities per team tapos kulayan yung mga cities na naconquered else default color
            //var myTeamCitiesConquered = ListOfCity.Cities.Where(c => c.Sectors.All(s => s.conqueror.TeamId.Equals(DataPersistor.persist.user.TeamId))).Select(c => c.Id).ToList();
            //foreach(var cityid in myTeamCitiesConquered)
            //{
            //    CityToChange(cityid, DataPersistor.persist.user.TeamId);
            //}

            //var enemiesTeamColorId = Scoremanager.GetComponent<ScoreManager>().enemyTeamColorId;
            //for(int i = 0; i < enemiesTeamColorId.Count; i++ )
            //{
            //    var enemyteam = ListOfCity.Cities.Where(c => c.Sectors.All(s => s.conqueror.TeamId.Equals(enemiesTeamColorId[i]))).Select(c => c.Id).ToList();
            //    foreach(var cityid in enemyteam)
            //    {
            //        CityToChange(cityid, enemiesTeamColorId[i]);
            //    }
            //}
        }
    }

    private void CityToChange(int cityid, int teamcolorid)
    {
        byte r, g, b;
        if(teamcolorid != -1)
        {
            byte[][] teamColor = new byte[][] { new byte[] { 0, 86, 255 }, new byte[] { 255, 10, 10 }, new byte[] { 0, 220, 0 }, new byte[] { 255, 255, 0 } };
            r = teamColor[teamcolorid - 1][0];
            g = teamColor[teamcolorid - 1][1];
            b = teamColor[teamcolorid - 1][2];
        }
        else
        {
            byte[][] cityColor = new byte[][] { new byte[] { 255, 255, 255 }, new byte[] { 255, 153, 153 }, new byte[] { 188, 122, 255 }
                                                , new byte[] { 118, 255, 116 }, new byte[] { 250, 0, 240 }, new byte[] { 184, 227, 255 }
                                                , new byte[] { 255, 166, 64 }, new byte[] { 0, 255, 255 }, new byte[] { 255, 102, 255 }
                                                , new byte[] { 174, 255, 187 }, new byte[] { 255, 173, 173 }, new byte[] { 113, 217, 255 }
                                                , new byte[] { 255, 204, 153 }, new byte[] { 204, 255, 153 }, new byte[] { 102, 178, 255 }
                                                , new byte[] { 190, 190, 190 }, new byte[] { 153, 255, 204 }, new byte[] { 255, 231, 147 }
                                                , new byte[] { 255, 141, 141 }};
            r = cityColor[cityid - 1][0];
            g = cityColor[cityid - 1][1];
            b = cityColor[cityid - 1][2];
        }
        switch (cityid)
        {
            case 1: ChangeColor(CityId1, r, g, b); break;
            case 2: ChangeColor(CityId2, r, g, b); break;
            case 3: ChangeColor(CityId3, r, g, b); break;
            case 4: ChangeColor(CityId4, r, g, b); break;
            case 5: ChangeColor(CityId5, r, g, b); break;
            case 6: ChangeColor(CityId6, r, g, b); break;
            case 7: ChangeColor(CityId7, r, g, b); break;
            case 8: ChangeColor(CityId8, r, g, b); break;
            case 9: ChangeColor(CityId9, r, g, b); break;
            case 10: ChangeColor(CityId10, r, g, b); break;
            case 11: ChangeColor(CityId11, r, g, b); break;
            case 12: ChangeColor(CityId12, r, g, b); break;
            case 13: ChangeColor(CityId13, r, g, b); break;
            case 14: ChangeColor(CityId14, r, g, b); break;
            case 15: ChangeColor(CityId15, r, g, b); break;
            case 16: ChangeColor(CityId16, r, g, b); break;
            case 17: ChangeColor(CityId17, r, g, b); break;
            case 18: ChangeColor(CityId18, r, g, b); break;
            case 19: ChangeColor(CityId19, r, g, b); break;
            default: break;
        }
    }

    //private void ChangeColor(GameObject[] city, int teamcolorid)
    //{
    //    byte[][] teamColor = new byte[][] { new byte[] { 0, 86, 255 }, new byte[] { 255, 10, 10 }, new byte[] { 0, 220, 0 }, new byte[] { 255, 255, 0 } };
    //    foreach(var c in city)
    //    {
    //        c.GetComponent<Image>().color = new Color32(teamColor[teamcolorid - 1][0], teamColor[teamcolorid - 1][1], teamColor[teamcolorid - 1][2], 150);
    //    }
    //}

    private void ChangeColor(GameObject[] city, byte r, byte g, byte b)
    {
        foreach (var c in city)
        {
            c.GetComponent<Image>().color = new Color32(r, g, b, 150);
        }
    }
}
