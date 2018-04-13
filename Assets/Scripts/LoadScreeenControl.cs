using System.Collections;
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
    void Start()
    {
        StartCoroutine(GetPlayerSession());
    }

    IEnumerator GetPlayerSession()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "unityLink.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            // name =get.text;
            name = "qwe";
            Debug.Log("name is: " + name);
        }
        StartCoroutine(GetPlayerId());

    }
    IEnumerator GetPlayerId()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "getplayerid.php?name=" + name);
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + get.error);
        }
        else
        {
            DataPersistor.persist.user.ID = int.Parse(get.text);
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
                while (true)
                {

                    if (slider.value != 1f)
                    {
                        slider.value += 0.4f;
                    }
                    else
                        break;

                }
                SceneManager.LoadScene("Lobby");
            
           
        }

      
    }

   
   

}
