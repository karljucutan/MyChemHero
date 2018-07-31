using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.Minigame.Models;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class TeamCreation : MonoBehaviour
{

    // 1 = blue 2 = red 3 = green 4 = yellow
    static int teamColor = 0;
    private string teamName = "";
    public InputField teamNameInputField;
    private Team tempTeam;
    private bool teamNameSupplied = false, teamFlagSelected = false;

    public GameObject Blue, Red, Green, Yellow;  
    public Toggle CreateBlue, CreateRed, CreateGreen, CreateYellow;
    public Text BlueText, RedText, GreenText, YellowText;
    public GameObject JoinTeamBtn, CreateTeamBtn, CreateConfirmBtn;
    public GameObject PanelCreateTeamObj, AlertPanelGameObj;
    public void Start()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Team");
        teamNameInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        StartCoroutine(starPollingGetTeamsCreated());

    }

    public void setTeamNameState(bool state)
    {
        teamNameSupplied = state;
    }

    public void setFlagState(bool state)
    {
        teamFlagSelected = state;
    }

    private void Update()
    {
        if (teamNameSupplied && teamFlagSelected)
        {
            CreateConfirmBtn.GetComponent<Button>().interactable = true;

            var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute
            ExecuteEvents.Execute(CreateConfirmBtn, pointer, ExecuteEvents.pointerEnterHandler);//force hover
        }
        else
            CreateConfirmBtn.GetComponent<Button>().interactable = false;
    }
    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        string textOnField = teamNameInputField.text.Trim();

        if(!string.IsNullOrEmpty(textOnField))
        {
            teamName = teamNameInputField.text;
            setTeamNameState(true);
        }
        else
        {
            teamName = "";
            setTeamNameState(false);
        }
        
    }

    public void CheckToggleState(Toggle toggle)
    {
        if (toggle.isOn)
        {
            switch (toggle.gameObject.name)
            {
                case "Blue": BlueTeam(); break;
                case "Red": RedTeam(); break;
                case "Green": GreenTeam(); break;
                case "Yellow": YellowTeam(); break;
            }
            setFlagState(true);
        }
        else
        {
            NoTeam();
            setFlagState(false);
        }
            
    }

    public void BlueTeam()
    {
        teamColor = 1;
        DataPersistor.persist.teamSelecetionFactionId = teamColor;
        DataPersistor.persist.colorStr = "blue";

    }

    public void RedTeam()
    {
        teamColor = 2;
        DataPersistor.persist.teamSelecetionFactionId = teamColor;
        DataPersistor.persist.colorStr = "red";

    }

    public void GreenTeam()
    {
        teamColor = 3;
        DataPersistor.persist.teamSelecetionFactionId = teamColor;
        DataPersistor.persist.colorStr = "green";

    }

    public void YellowTeam()
    {
        teamColor = 4;
        DataPersistor.persist.teamSelecetionFactionId = teamColor;
        DataPersistor.persist.colorStr = "yellow";

    }

    public void NoTeam()
    {
        teamColor = 0;
        DataPersistor.persist.teamSelecetionFactionId = teamColor;
        DataPersistor.persist.colorStr = "";
    }
   
    public void CheckNoOfTeams()
    {
        if (ListOfTeams.TeamList.Count >= 4)
        {
            //Alert: no more teams to create
            AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Can't create beyond 4 teams, please join an existing one instead";
            AlertPanelGameObj.SetActive(true);

        }
        else
        {
            NoTeam(); //clear DataPersistor Values if player tried to Join Team first, but Clicked Create afterwards
            JoinTeamBtn.SetActive(false);
            CreateTeamBtn.SetActive(false);
            PanelCreateTeamObj.SetActive(true);
        }
    }

    public void CreateTeam()
    {
        //DataPersistor.persist.teamSelecetionFactionId = teamColor;
        // check kung may kapangalan yung team at validations kung may team na or team name
        //var has = ListOfTeams.TeamList.Any(t => t.teamName.Equals(teamNameInputField.text));
        if(!string.IsNullOrEmpty(teamNameInputField.text))
        {
            if(teamColor != 0)
            {
                var has = ListOfTeams.TeamList.Any(t => t.teamName.Equals(teamNameInputField.text));
                if (has != true)
                {
                    var teamIsCreated = ListOfTeams.TeamList.Any(t => t.teamColorId.Equals(teamColor));
                    if (!teamIsCreated)
                    {
                        StartCoroutine(PostCreatedTeam());
                    }
                    else
                    {
                        //Alert : Team Color already taken
                        AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Failed to create team, Team Color already taken!";
                        AlertPanelGameObj.SetActive(true);
                    }
                }
                else
                {
                    //Alert : Team Name Already Exists
                    AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Failed to create team, Team Name already taken!";
                    AlertPanelGameObj.SetActive(true);
                }
            }
            else
            {
                //Alert : Select A Team First
                AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Please Select a Team Flag to create first!";
                AlertPanelGameObj.SetActive(true);
            }
        }
        else
        {
            //Alert : Team Name Can't be Null
            AlertPanelGameObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Please input Team Name first!";
            AlertPanelGameObj.SetActive(true);
        }

        //var has = ListOfTeams.TeamList.Any(t => t.teamName.Equals(teamNameInputField.text));
        //if (teamColor != 0 && teamNameInputField.text != "" && has != true)
        //{
        //    DataPersistor.persist.teamSelecetionFactionId = teamColor;
        //    // check kung di pa na ccreate yung team color
        //    var teamIsCreated = ListOfTeams.TeamList.Any(t => t.teamColorId.Equals(teamColor));
        //    if (!teamIsCreated)
        //    {
        //        StartCoroutine(PostCreatedTeam());
        //    }
        //    else
        //    {
        //        //failed to create team, teamColor already taken
        //    }

        //}
        //else
        //{
        //    //failed to create team, either teamColor = 0 or team name already exists
        //}


    }
   
    IEnumerator PostCreatedTeam()
    {

        string post_url = Configuration.BASE_ADDRESS + "createTeam.php?team_name=" + teamName + "&team_colorid=" + teamColor + "&leaderid=" + DataPersistor.persist.user.ID ;

        // Post the URL to the site and create a download object to get the result.
        WWW CT_post = new WWW(post_url);
        yield return CT_post; // Wait until the download is done
        
        if (CT_post.error != null)
        {
            print("There was an error posting team created: " + CT_post.error);
        }

        DataPersistor.persist.teamId = int.Parse(CT_post.text);
        DataPersistor.persist.teamCreator = true;

        teamNameInputField.text = "";
        
        //SceneManager.LoadScene("Character Customization");
        LevelManager.lvlmgr.LoadLevel("Character Customization");
    }

    IEnumerator GetTeamId()
    {
        WWW get = new WWW(Configuration.BASE_ADDRESS + "getTeamId");
        yield return get;
    }


    //CREATE COROUTINE GET FOR TEAMID AND TEAMCOLOR
    IEnumerator GetTeamsCreated()
    {

        WWW get = new WWW(Configuration.BASE_ADDRESS + "getTeam.php");
        yield return get;

        if (get.error != null)
        {
            Debug.Log("There was an error getting the team: " + get.error);

        }
        else
        {
            string teams = get.text;
            //Debug.Log(teams + "");
            string[] teamInfo = teams.Split('+');
            ListOfTeams.TeamList.Clear();

            for (int i = 0; i < teamInfo.Length - 1; i++)
            {
                string[] individualValues = teamInfo[i].Split(';');
                tempTeam = new Team();
                tempTeam.teamId = int.Parse(individualValues[0]);
                tempTeam.teamName = individualValues[1];
                tempTeam.teamColorId = int.Parse(individualValues[2]);
                tempTeam.teamLeaderId = int.Parse(individualValues[3]);

                ListOfTeams.TeamList.Add(tempTeam);
            }
            //dipslayteamlist();

        }
     
    
    }
    private IEnumerator starPollingGetTeamsCreated()
    {
        while (true)
        {
            StartCoroutine(GetTeamsCreated());

            // dito i active yung mga button teams
            if (ListOfTeams.TeamList.Count > 0)
            {
                if ((ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(1)).Select(t => t.teamColorId).FirstOrDefault() == 1) && !Blue.activeInHierarchy)
                {
                    Blue.SetActive(true); BlueText.text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(1)).Select(t => t.teamName).FirstOrDefault();
                    //Blue.transform.SetSiblingIndex(ListOfTeams.TeamList.Count - 1); 
                    CreateBlue.enabled = false;
                    CreateBlue.gameObject.SetActive(false);
                }
                if (ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(2)).Select(t => t.teamColorId).FirstOrDefault() == 2 && !Red.activeInHierarchy)
                {
                    Red.SetActive(true); RedText.text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(2)).Select(t => t.teamName).FirstOrDefault();
                    // Red.transform.SetSiblingIndex(ListOfTeams.TeamList.Count - 1); 
                    CreateRed.enabled = false;
                    CreateRed.gameObject.SetActive(false);
                }
                if (ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(3)).Select(t => t.teamColorId).FirstOrDefault() == 3 && !Green.activeInHierarchy)
                {
                    Green.SetActive(true); GreenText.text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(3)).Select(t => t.teamName).FirstOrDefault();
                    //Green.transform.SetSiblingIndex(ListOfTeams.TeamList.Count - 1); 
                    CreateGreen.enabled = false;
                    CreateGreen.gameObject.SetActive(false);

                }
                if (ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(4)).Select(t => t.teamColorId).FirstOrDefault() == 4  && !Yellow.activeInHierarchy)
                {
                    Yellow.SetActive(true); YellowText.text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(4)).Select(t => t.teamName).FirstOrDefault();
                    //Yellow.transform.SetSiblingIndex(ListOfTeams.TeamList.Count - 1);
                    CreateYellow.enabled = false;
                    CreateYellow.gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void dipslayteamlist()
    {
        var size = ListOfTeams.TeamList.Count;
        for (int i = 0; i < size; i++)
        {
            Debug.Log("LIST OF TEAM: " + ListOfTeams.TeamList.Count);
            
        }


      

    }


}
