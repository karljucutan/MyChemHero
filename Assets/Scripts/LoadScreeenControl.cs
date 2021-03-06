﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using Assets.Scripts.Minigame.Models;

public class LoadScreeenControl : MonoBehaviour {

    public GameObject loadingScreenObj;
    public Slider slider;
    AsyncOperation async;
    private bool idFlag = false, infoFlag = false, loadFLag = false;

    void Start()
    {
        StartCoroutine(GetPlayerId());
        AudioManager.instance.Play("Title");
    }

    //IEnumerator GetPlayerSession()
    //{
    //    WWW get = new WWW(Configuration.BASE_ADDRESS + "unityLink.php");
    //    yield return get;

    //    if (get.error != null)
    //    {
    //        Debug.Log("There was an error getting the high score: " + get.error);
    //    }
    //    else
    //    {
    //        name = get.text;
    //        name = Configuration.NAME;
    //        Debug.Log("name is: " + name);
    //        sessionFlag = true;
    //        slider.value += 0.25f;
    //    }

    //    StartCoroutine(GetPlayerId());

    //}
    IEnumerator GetPlayerId()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "unityLink.php");

        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {

            //DataPersistor.persist.user.ID = int.Parse(get.text); //set actual retrieved ID from unityLink
            DataPersistor.persist.user.ID = Configuration.ID; //temporary player ID set thru Configuration.CS
            idFlag = true;
            slider.value += 0.25f;
        }
        
        StartCoroutine(RetrieveUserInfo());
    }
    public IEnumerator RetrieveUserInfo()//FOR USERS INFO
    {

        WWW hs_get = new WWW(Configuration.BASE_ADDRESS + "RetrieveInfo.php?pid=" + DataPersistor.persist.user.ID);
        yield return hs_get;

        if (hs_get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hs_get.error);

        }
        else
        {
            string help = hs_get.text;
            string[] userInfo = help.Split(';');

            //temporary lng to kukuha pa sa php session ng value
            if (userInfo[1] != "")
            {
                Debug.Log(userInfo[0]+" "+userInfo[1]);
                DataPersistor.persist.user.UserName = userInfo[0];
                DataPersistor.persist.user.UserCharacter.Body = int.Parse(userInfo[1]);
                DataPersistor.persist.user.UserCharacter.Hair = int.Parse(userInfo[2]);
                DataPersistor.persist.user.UserCharacter.EyeBrows = int.Parse(userInfo[3]);
                DataPersistor.persist.user.UserCharacter.Eyes = int.Parse(userInfo[4]);
                DataPersistor.persist.user.UserCharacter.Nose = int.Parse(userInfo[5]);
                DataPersistor.persist.user.UserCharacter.Mouth = int.Parse(userInfo[6]);
                DataPersistor.persist.user.UserCharacter.Gender = userInfo[7].ToString();
                DataPersistor.persist.user.TotalScore = int.Parse(userInfo[8]);
                DataPersistor.persist.user.HelpsMade = int.Parse(userInfo[9]);
                DataPersistor.persist.user.SectorsHold = int.Parse(userInfo[10]);
                DataPersistor.persist.user.TeamId = int.Parse(userInfo[11]);
            }
            //user.SectorsHold = int.Parse();
            infoFlag = true;
            slider.value += 0.25f;
        }
        
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        WWW get = new WWW(Configuration.BASE_ADDRESS + "getplayerstate.php?playerid=" + DataPersistor.persist.user.ID);
        yield return get;

        DataPersistor.persist.state = get.text;
        Debug.Log("STATE:   " + DataPersistor.persist.state);
       
        //Debug.Log("GET:   " + get.text);
        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            //while (true)
            //{

            //    if (slider.value != 1f)
            //    {
            //        slider.value += 0.4f;
            //    }
            //    else
            //        break;

            //}
            loadFLag = true;
            slider.value += 0.25f;
            
            //GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Map"); 

        }
        proceedToLoad();

      
    }

    void proceedToLoad()
    {
        if (idFlag && infoFlag && loadFLag)//check if all flags are true(no problem loading)
        {
            LevelManager.lvlmgr.LoadLevel("Lobby");
        }
           
        else // retry fetching
        {
            //some dialog box for confirmation on retry load
            StartCoroutine(GetPlayerId());
        }
           
    }

   
   

}
