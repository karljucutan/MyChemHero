using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BadgeManager : MonoBehaviour {

    // GG SA MAP SCENE PALANG GAGANA TONG SCRIPT NATO YUNG PAG CHECK KUNG NAGKAROON KA NG BADGE
    // GG KAPAG TOP 2 ka tapos yung top 1 nabawasan ng sectors hold tapos wala ka sa map scene di ka mag kakabadge

    public bool doneRetrieveUserBadge = false;
	// Use this for initialization
	void Start () {
      
        StartCoroutine(RetrieveUserBadges());
        //YUNG HELPSMADE AT TOTAL POINTS SA START LANG YUNG SECTORS HOLD SA UPDATE DAPAT.
        StartCoroutine(waitRetrieve());
       

    }

    private IEnumerator waitRetrieve()
    {
        Debug.Log("WAIT RETRIEVE");
        if(!DataPersistor.persist.doneLoadingAllUsers)
        yield return new WaitForSeconds(0.1f);
        if (!doneRetrieveUserBadge)
        yield return new WaitForSeconds(0.1f);

        BadgeByPointsChecker();
        BadgeByHelpsMadeChecker();
    }
    // Update is called once per frame
    void Update()
    {
        if (doneRetrieveUserBadge)
        {
            if(DataPersistor.persist.doneLoadingAllUsers)
            BadgeBySectorsChecker();
        }
    }


    private void BadgeByPointsChecker()
    {
        var playersByPoints = ListOfUser.ALLUSERS.Where(u => u.TotalScore != 0).Select(u => new { u.ID, u.TotalScore }).OrderByDescending(u => u.TotalScore).ToList();
        int count = 3;
        if (playersByPoints.Count == 1) count = 1;  // need para ndi mag error kapag players lessthan 3
        if (playersByPoints.Count == 2) count = 2;

        for (int i = 0; i < count; i++)
        {
            if (playersByPoints[i].ID.Equals(DataPersistor.persist.user.ID))
            {
                if (!DataPersistor.persist.user.Badges.Contains("Top"+(i+1).ToString()+"InPoints"))
                {
                    // NOTIFICATION NA MAY NA RECEIVE NA BADGE
                    StartCoroutine(PostBadge("Top" +(i+1).ToString()+ "InPoints"));    //POST YUNG BADGE
                }
            }
        }
    }

    private void BadgeBySectorsChecker()
    {
        var playersBySectors = ListOfUser.ALLUSERS.Where(u => u.SectorsHold != 0).Select(u => new { u.ID, u.SectorsHold }).OrderByDescending(u => u.SectorsHold).ToList();
        int count = 3;
        if (playersBySectors.Count == 1) count = 1;  // need para ndi mag error kapag players lessthan 3
        if (playersBySectors.Count == 2) count = 2;
        for (int i = 0; i < count; i++)
        {
            if (playersBySectors[i].ID.Equals(DataPersistor.persist.user.ID))
            {
                if (!DataPersistor.persist.user.Badges.Contains("Top" + (i+1).ToString() + "InSectors"))
                {
                    // NOTIFICATION NA MAY NA RECEIVE NA BADGE
                    StartCoroutine(PostBadge("Top" + (i+1).ToString() + "InSectors"));    //POST YUNG BADGE
                }
            }
        }
    }

    private void BadgeByHelpsMadeChecker()
    {
        var playersBySectors = ListOfUser.ALLUSERS.Where(u => u.HelpsMade != 0).Select(u => new { u.ID, u.HelpsMade }).OrderByDescending(u => u.HelpsMade).ToList();
        int count = 3;
        if (playersBySectors.Count == 1) count = 1;  // need para ndi mag error kapag players lessthan 3
        if (playersBySectors.Count == 2) count = 2;
        for (int i = 0; i < count; i++)
        {
            if (playersBySectors[i].ID.Equals(DataPersistor.persist.user.ID))
            {
                if (!DataPersistor.persist.user.Badges.Contains("Top" + (i + 1).ToString() + "InHelpsMade"))
                {
                    // NOTIFICATION NA MAY NA RECEIVE NA BADGE
                    StartCoroutine(PostBadge("Top" + (i + 1).ToString() + "InHelpsMade"));    //POST YUNG BADGE
                }
            }
        }
    }

    private IEnumerator RetrieveUserBadges()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetBadges.php?playerid=" + DataPersistor.persist.user.ID);
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            DataPersistor.persist.user.Badges = new List<string>();
            string help = get.text;
            //Debug.Log(help + "");
            string[] badges = help.Split(';');

            for (int i = 0; i < badges.Length - 1; i++)
            {
                DataPersistor.persist.user.Badges.Add(badges[i]);
                //Debug.Log(DataPersistor.persist.user.Badges[i] + "BADGETO");
            }
            doneRetrieveUserBadge = true;
        }
        StartCoroutine(RetrieveUserBadges());
    }

    IEnumerator PostBadge(string badge)
    {
        string post_url = Configuration.BASE_ADDRESS + "updateBadges.php?playerid=" + DataPersistor.persist.user.ID + "&badge=" + badge;
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
}
