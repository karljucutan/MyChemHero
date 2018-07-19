using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConfirm : MonoBehaviour {

    public GameObject confirmDialogObj;
    public GameObject AlertPanelGameObj;

    static string color = "";
    static int teamid = 0;


    public void setColor(string _color)
    {
        color = _color;
    }

    public void setTeamid(int id)
    {
        teamid = id;
        Debug.Log("Team ID: " + teamid);
    }

    public void checkJoin()
    {
        if(teamid == 0)//no team selected yet in Join
        {
            AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Please Select a Team to Join!";
            AlertPanelGameObj.SetActive(true);//some alert
        }
        else
        {
            confirmDialogObj.SetActive(true);
            Debug.Log("Team ID: " + teamid);
        }
    }


    public void confirmChoice()
    {
        DataPersistor.persist.colorStr = color;
        DataPersistor.persist.teamSelecetionFactionId = teamid;
        LevelManager.lvlmgr.LoadLevel("Character Customization");
    }
}
