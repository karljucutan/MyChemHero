using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Linq;

public class Lobby : MonoBehaviour {
    private void Start()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Title");
        //Debug.Log("ID" + DataPersistor.persist.user.ID +" Name: " + DataPersistor.persist.user.UserName);
    }
    public void CheckState () {
       
        if(ListOfTeams.TeamList.Any(t => t.teamLeaderId.Equals(DataPersistor.persist.user.ID)) && !DataPersistor.persist.state.Equals("returning"))//to check if user is the teamcreator and refreshed in Char custom
        {
            var team = ListOfTeams.TeamList.Find(t => t.teamLeaderId.Equals(DataPersistor.persist.user.ID));
            DataPersistor.persist.teamSelecetionFactionId = team.teamColorId; //set Body Color
            string colorStr = "";
            switch(team.teamColorId)
            {
                case 1: colorStr = "blue"; break;
                case 2: colorStr = "red"; break;
                case 3: colorStr = "green"; break;
                case 4: colorStr = "yellow"; break;
            }

            DataPersistor.persist.colorStr = colorStr; //set color of BG

            DataPersistor.persist.teamCreator = true; //to disable back button on return

            LevelManager.lvlmgr.LoadLevel("Character Customization");
        }
        else if (DataPersistor.persist.state.Equals("returning"))
        {
            //Debug.Log("RETURNING ME");
            //SceneManager.LoadScene("Map");
            LevelManager.lvlmgr.LoadLevel("Map");
        }
        else
        {
            //Debug.Log("DI AKO RETURNING");
            //SceneManager.LoadScene("Team Selection");
            LevelManager.lvlmgr.LoadLevel("Team Selection");
        }
	}
	
	
}
