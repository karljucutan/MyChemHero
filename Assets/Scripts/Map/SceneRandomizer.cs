using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour {

    private int randomNumber;
    private int repeat;
    private string[] scenesList;

    void Start()
    {
        randomNumber = 0;
        //scenesList = new string[]{
        //    "Help_AsGoodAsNew",
        //    "Help_BakersDilemma",
        //    "Help_CloudSeeding",
        //    "Help_Fire",
        //    "Help_LandLubberScurvy",
        //    "Help_MedicPanic",
        //    "Help_Shokugeki",
        //    "Help_StayCleanStaySafe",
        //    "Help_ToothFairy",
        //    "Help_ToSpace"};

        scenesList = new string[]{
            "StartScene"
        };
    }

    public void loadrandomScene()
    {
        //randomNumber = Random.Range(2,12);
        randomNumber = Random.Range(0, scenesList.Length);

        //SceneManager.LoadScene(randomNumber);
        LevelManager.lvlmgr.LoadLevel(scenesList[randomNumber]);
    }

    public void GoToLobby()
    {
        LevelManager.lvlmgr.LoadLevel("Lobby");      
    }

 
}
