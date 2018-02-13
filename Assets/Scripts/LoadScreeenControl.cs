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
    public User user;
    private bool isdone = false;
    AsyncOperation async;
    void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        WWW get = new WWW(Configuration.BASE_ADDRESS + "getplayerstate.php?playerid=" + DataPersistor.persist.id);
        yield return get;

        DataPersistor.persist.state = get.text;
        Debug.Log("STATE:   " + DataPersistor.persist.state);
        Debug.Log("GET:   " + get.text);
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
