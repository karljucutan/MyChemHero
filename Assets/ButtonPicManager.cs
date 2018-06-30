using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonPicManager : MonoBehaviour {
    private Sprite[] ButtonPic;

    public GameObject TopPlayers;
    public GameObject TopTeams;
    
    public GameObject TopPlayersPoints;
    public GameObject TopPlayersSectors;
    public GameObject TopPlayersHelpsMade;

    public GameObject TopTeamPoints;
    public GameObject TopTeamSectors;
    public GameObject TopTeamHelpsMade;
	// Use this for initialization
	void Start () {
        ButtonPic = new Sprite[2];
        ButtonPic[0] = Resources.Load<Sprite>("UNITY UI FREE ASSETS/Ultimate Game UI/Sliced/START_PAGE/but_frame");
        ButtonPic[1] = Resources.Load<Sprite>("UNITY UI FREE ASSETS/Ultimate Game UI/Sliced/START_PAGE/but_frame_pressed");
	}
	
    public void TopPlayers_OnClick()
    {
        TopPlayers.GetComponent<Image>().sprite = ButtonPic[1];
        TopTeams.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopTeams_OnClick()
    {
        TopPlayers.GetComponent<Image>().sprite = ButtonPic[0];
        TopTeams.GetComponent<Image>().sprite = ButtonPic[1];
    }

    public void TopPlayerPoints_OnClick()
    {
        TopPlayersPoints.GetComponent<Image>().sprite = ButtonPic[1];
        TopPlayersSectors.GetComponent<Image>().sprite = ButtonPic[0];
        TopPlayersHelpsMade.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopPlayerSectors_OnClick()
    {
        TopPlayersSectors.GetComponent<Image>().sprite = ButtonPic[1];
        TopPlayersPoints.GetComponent<Image>().sprite = ButtonPic[0];
        TopPlayersHelpsMade.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopPlayerHelpsMade_OnClick()
    {
        TopPlayersHelpsMade.GetComponent<Image>().sprite = ButtonPic[1];
        TopPlayersPoints.GetComponent<Image>().sprite = ButtonPic[0];
        TopPlayersSectors.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopTeamPoints_OnCLick()
    {
        TopTeamPoints.GetComponent<Image>().sprite = ButtonPic[1];
        TopTeamHelpsMade.GetComponent<Image>().sprite = ButtonPic[0];
        TopTeamSectors.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopTeamSectors_OnClick()
    {
        TopTeamSectors.GetComponent<Image>().sprite = ButtonPic[1];
        TopTeamPoints.GetComponent<Image>().sprite = ButtonPic[0];
        TopTeamHelpsMade.GetComponent<Image>().sprite = ButtonPic[0];
    }

    public void TopTeamHelpsMade_OnClick()
    {
        TopTeamHelpsMade.GetComponent<Image>().sprite = ButtonPic[1];
        TopTeamPoints.GetComponent<Image>().sprite = ButtonPic[0];
        TopTeamSectors.GetComponent<Image>().sprite = ButtonPic[0];
    }
}
