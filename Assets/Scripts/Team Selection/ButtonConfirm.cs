﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonConfirm : MonoBehaviour {

    public GameObject confirmDialogObj;
    public GameObject AlertPanelGameObj;
    public GameObject JoinGameButtonObj;


    private bool SelectedTeam = false;

    private void Update()
    {
        if (SelectedTeam)
        {
            JoinGameButtonObj.GetComponent<Button>().interactable = true;
            var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute
            ExecuteEvents.Execute(JoinGameButtonObj, pointer, ExecuteEvents.pointerEnterHandler);//force hover
        }
        else
            JoinGameButtonObj.GetComponent<Button>().interactable = false;
    }

    public void SetSelectedTeamTeamState(bool state)
    {
        SelectedTeam = state;
    }

    public void CheckJoinToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            switch (toggle.gameObject.name)
            {
                case "BlueJoin": BlueTeam(); break;
                case "RedJoin": RedTeam(); break;
                case "GreenJoin": GreenTeam(); break;
                case "YellowJoin": YellowTeam(); break;
            }
            SetSelectedTeamTeamState(true);
        }
        else
        {
            NoTeam();
            SetSelectedTeamTeamState(false);
        }
            
    }

    public void BlueTeam()
    {
        DataPersistor.persist.teamSelecetionFactionId = 1;
        DataPersistor.persist.colorStr = "blue";
    }

    public void RedTeam()
    {
        DataPersistor.persist.teamSelecetionFactionId = 2;
        DataPersistor.persist.colorStr = "red";
    }

    public void GreenTeam()
    {
        DataPersistor.persist.teamSelecetionFactionId = 3;
        DataPersistor.persist.colorStr = "green";
    }

    public void YellowTeam()
    {
        DataPersistor.persist.teamSelecetionFactionId = 4;
        DataPersistor.persist.colorStr = "yellow";
    }

    public void NoTeam()
    {
        DataPersistor.persist.teamSelecetionFactionId = 0;
        DataPersistor.persist.colorStr = "";
    }

    public void checkJoin()
    {
        if(DataPersistor.persist.teamSelecetionFactionId == 0)//no team selected yet in Join
        {
            AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Please Select a Team to Join!";
            AlertPanelGameObj.SetActive(true);//some alert
        }
        else
        {
            confirmDialogObj.SetActive(true);
        }
    }


    public void confirmChoice()
    {
        LevelManager.lvlmgr.LoadLevel("Character Customization");
    }
}
