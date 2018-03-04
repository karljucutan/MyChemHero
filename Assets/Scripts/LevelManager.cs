using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string[] sectorHolderValues;
    void Awake()
    {
        StartCoroutine(GetSectorHolderScores());
        StartCoroutine(RetrieveAllUsersInfo());
        StartCoroutine(RetrieveUserBadges());
    }
    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    IEnumerator GetSectorHolderScores()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "GetSectorHolders.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            string help = get.text;
            DataPersistor.persist.values = help.Split('+');
        }
        StartCoroutine(GetSectorHolderScores());
    }
    private IEnumerator RetrieveAllUsersInfo()
    {
        User TempUser = new User();

        WWW hs_get = new WWW(Configuration.BASE_ADDRESS + "GetAllUsers.php");
        yield return hs_get;

        if (hs_get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hs_get.error);

        }
        else
        {
            string help = hs_get.text;

            string[] userInfo = help.Split('+');
            for (int i = 0; i < userInfo.Length - 1; i++)
            {
                string[] individualValues = userInfo[i].Split(';');
                TempUser = new User();
                TempUser.UserCharacter = new Character();
                TempUser.ID = int.Parse(individualValues[0]);
                TempUser.UserName = individualValues[1];
                TempUser.TeamId = int.Parse(individualValues[2]);
                TempUser.TotalScore = int.Parse(individualValues[3]);
                TempUser.UserCharacter.Face = int.Parse(individualValues[4]);
                TempUser.UserCharacter.Hair = int.Parse(individualValues[5]);
                TempUser.UserCharacter.Eyes = int.Parse(individualValues[6]);
                TempUser.UserCharacter.Nose = int.Parse(individualValues[7]);
                TempUser.UserCharacter.Mouth = int.Parse(individualValues[8]);

                if(ListOfUser.ALLUSERS.Exists(item => item.ID.Equals(TempUser.ID)) == false)
                    ListOfUser.ALLUSERS.Add(TempUser);

            }

        }
        StartCoroutine(RetrieveAllUsersInfo());
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
            DataPersistor.persist.user.Badges.Clear();
            string help = get.text;
            //Debug.Log(help + "");
            string[] badges = help.Split(';');

            for (int i = 0; i < badges.Length - 1; i++)
            {
                DataPersistor.persist.user.Badges.Add(badges[i]);
                //Debug.Log(DataPersistor.persist.user.Badges[i] + "BADGETO");
            }

        }
        StartCoroutine(RetrieveUserBadges());
    }
}
