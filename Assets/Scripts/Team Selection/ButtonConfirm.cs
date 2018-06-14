using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour {

    public string color;
    private int teamid;

    public void setColor(string _color)
    {
        color = _color;
    }

    public void setTeamid(int id)
    {
        teamid = id;
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
