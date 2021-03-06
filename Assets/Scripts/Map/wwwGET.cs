﻿using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwwGET : MonoBehaviour {
    public string[] sectorHolderValues;
    void Awake()
    {
        StartCoroutine(RetrieveAllUsersInfo());
        StartCoroutine(GetSectorHolderScores());

        
      //  StartCoroutine(RetrieveUserBadges());
    }

    IEnumerator GetSectorHolderScores()
   {
     //   Debug.Log("WWWGET GETTING SECTORHOLDERS");
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
            ListOfUser.ALLUSERS = new List<User>();
            Debug.Log("NEW LIST ALL USER");
            for (int i = 0; i < userInfo.Length - 1; i++)
           {
               string[] individualValues = userInfo[i].Split(';');
               TempUser = new User();
               TempUser.UserCharacter = new Character();
               TempUser.ID = int.Parse(individualValues[0]);
               TempUser.UserName = individualValues[1];
               TempUser.TeamId = int.Parse(individualValues[2]);
               TempUser.TotalScore = int.Parse(individualValues[3]);
               TempUser.UserCharacter.Body = int.Parse(individualValues[4]);
               TempUser.UserCharacter.Hair = int.Parse(individualValues[5]);
               TempUser.UserCharacter.EyeBrows = int.Parse(individualValues[6]);
               TempUser.UserCharacter.Eyes = int.Parse(individualValues[7]);
               TempUser.UserCharacter.Nose = int.Parse(individualValues[8]);
               TempUser.UserCharacter.Mouth = int.Parse(individualValues[9]);
               TempUser.UserCharacter.Gender = individualValues[10].ToString();
               TempUser.HelpsMade = int.Parse(individualValues[11]);
               TempUser.SectorsHold = int.Parse(individualValues[12]);
               //if(ListOfUser.ALLUSERS.Exists(item => item.ID.Equals(TempUser.ID)) == false)
                   ListOfUser.ALLUSERS.Add(TempUser);

           }
            DataPersistor.persist.doneLoadingAllUsers = true;

       }
       StartCoroutine(RetrieveAllUsersInfo());
   }
   //private IEnumerator RetrieveUserBadges()
   //{
   //    WWW get = new WWW(Configuration.BASE_ADDRESS + "GetBadges.php?playerid=" + DataPersistor.persist.user.ID);
   //    yield return get;

   //    if (get.error != null)
   //    {
   //        Debug.Log("There was an error getting the high score: " + get.error);
   //    }
   //    else
   //    {
   //        DataPersistor.persist.user.Badges.Clear();
   //        string help = get.text;
   //        //Debug.Log(help + "");
   //        string[] badges = help.Split(';');

   //        for (int i = 0; i < badges.Length - 1; i++)
   //        {
   //            DataPersistor.persist.user.Badges.Add(badges[i]);
   //            //Debug.Log(DataPersistor.persist.user.Badges[i] + "BADGETO");
   //        }

   //    }
   //    StartCoroutine(RetrieveUserBadges());
   //}

    

}
