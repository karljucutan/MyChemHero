using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour {

    public GameObject confirmDialogObj;

    private string color;
    private int teamid;

    private void Start()
    {
        teamid = 0;
        color = "";
    }

    public void setColor(string _color)
    {
        color = _color;
    }

    public void setTeamid(int id)
    {
        teamid = id;
    }

    public void checkJoin()
    {
        if(teamid == 0)//no team selected yet in Join
        {
            //some alert
        }
        else
        {
            confirmDialogObj.SetActive(true);
        }
    }


    public void confirmChoice()
    {
        if (DataPersistor.persist != null)
        {
            DataPersistor.persist.colorStr = color;
            DataPersistor.persist.teamSelecetionFactionId = teamid;
            LevelManager.lvlmgr.LoadLevel("Character Customization");
        }
    }
}
