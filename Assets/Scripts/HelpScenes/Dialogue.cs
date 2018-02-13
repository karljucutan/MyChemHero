using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour {

    private Text textcomponent;
    public string[] dialogueString;
    public float secondsBetweenCharacters;
    public float characterRateMultiplier;

    public KeyCode dialogInput;

   
    public GameObject continueIcon;

    private bool isStringBeingRevealed;
    private bool isEndOfDialogue;
    //private bool isDialoguePlaying;

    private bool postPointsAndHelpsMadeRunning;
    private bool postScoresRunning;
	
    void Awake()
    {
        DialogueSetter();
    }

    private void DialogueSetter()
    {
        string[] dialogue;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Help_AsGoodAsNew":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELPASGOODASNEW";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELPASGOODASNEW";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELPASGOODASNEW";
                        dialogueString = dialogue;
                        break;
                    case "Unknown": DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELPASGOODASNEW";
                        dialogueString = dialogue;
                        break;
                }
                break;

            case "Help_BakersDilemma":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP BAKERS DILEMMA";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP BAKERS DILEMMA";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP BAKERS DILEMMA";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP BAKERS DILEMMA";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_CloudSeeding":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP CLOUD SEEDING";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP CLOUD SEEDING";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP CLOUD SEEDING";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP CLOUD SEEDING";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_Fire":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP FIRE";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP FIRE";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP FIRE";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP FIRE";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_LandLubberScurvy":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP LANDLUBBER SCURVY";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP LANDLUBBER SCURVY";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP LANDLUBBER SCURVY";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP LANDLUBBER SCURVY";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_MedicPanic":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP MEDIC PANIC";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP MEDIC PANIC";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP MEDIC PANIC";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP MEDIC PANIC";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_Shokugeki":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP SHOKUGEKI";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP SHOKUGEKI";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP SHOKUGEKI";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP SHOKUGEKI";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_StayCleanStaySafe":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP STAY CLEAN STAY SAFE";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP STAY CLEAN STAY SAFE";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP STAY CLEAN STAY SAFE";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP STAY CLEAN STAY SAFE";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_ToothFairy":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP TOOTH FAIRY";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP TOOTH FAIRY";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP TOOTH FAIRY";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP TOOTH FAIRY";
                        dialogueString = dialogue;
                        break;
                }
                break;
            case "Help_ToSpace":
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals":
                        dialogue = new string[3]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "METAL CITY";
                        dialogue[1] = "MINIGAME MIXING";
                        dialogue[2] = "HELP TO SPACE";
                        dialogueString = dialogue;
                        break;
                    case "NonMetals":
                        dialogue = new string[3];
                        dialogue[0] = "NONMETAL CITY";
                        dialogue[1] = "MINIGAME FREETHROW";
                        dialogue[2] = "HELP TO SPACE";
                        dialogueString = dialogue;
                        break;
                    case "Metalloids":
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME DODGEGAME";
                        dialogue[2] = "HELP TO SPACE";
                        dialogueString = dialogue;
                        break;
                    case "Unknown":
                        DialogueSetter();
                        dialogue = new string[3];
                        dialogue[0] = "METALLOIDS CITY";
                        dialogue[1] = "MINIGAME TAPTAPCOMPOUND";
                        dialogue[2] = "HELP TO SPACE";
                        dialogueString = dialogue;
                        break;
                }
                break;
        }
    }


	void Start () {
        postScoresRunning = false;
        postPointsAndHelpsMadeRunning = false;
        dialogInput = KeyCode.Mouse0;
        isStringBeingRevealed = false;
		textcomponent = GetComponent<Text>();
        textcomponent.text = "";
        isEndOfDialogue = false;
        // isDialoguePlaying = false;
        HideIcon();
        StartCoroutine(StartDialogue());
      
	}
	
	

    private IEnumerator DisplayString(string StringtoDisplay)
    {
        int stringLength = StringtoDisplay.Length;
        int currentCharacterIndex = 0;

        HideIcon();

        textcomponent.text = "";
        while (currentCharacterIndex < stringLength)
        {
            textcomponent.text += StringtoDisplay[currentCharacterIndex];
            currentCharacterIndex++;
            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(dialogInput))
                {
                    yield return new WaitForSeconds(secondsBetweenCharacters * characterRateMultiplier);
                }
                else 
                {
                    yield return new WaitForSeconds(secondsBetweenCharacters);
                }
                
            }
            else
            {
                break;
            }
        }

        ShowIcon();
        while (true)
        {
            if (Input.GetKeyDown(dialogInput))
            {
                break;
            }
            yield return 0;
        }
        HideIcon();
        isStringBeingRevealed = false;
        textcomponent.text = "";

        if (isEndOfDialogue)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("Help_EndingSceneForAll"))
            {
                if (DataPersistor.persist.mTime.minutes <= 0 && DataPersistor.persist.mTime.seconds <= 0)
                {
                    string[] info = DataPersistor.persist.values[DataPersistor.persist.currentSectorNumber-1].Split(';');
                    var currentScore = int.Parse(info[1]);
                    Debug.Log("ID:"+(info[0])+" SectorNumber:  "+ DataPersistor.persist.currentSectorNumber + " Score: "+ currentScore);
             
                    if (DataPersistor.persist.totalPoints > currentScore)
                    {
                        Debug.Log(DataPersistor.persist.totalPoints);
                        StartCoroutine(PostScores());
                    }
                    // dito yung post totalpoints at helps made
                    while (postScoresRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    if (DataPersistor.persist.totalPoints > 0 || DataPersistor.persist.helpsMade > 0)
                    { StartCoroutine(PostPointsAndHelpsMade()); 
                    }
                  
                    DataPersistor.persist.helpsMade = 0;
                    DataPersistor.persist.totalPoints = 0;

                    while (postPointsAndHelpsMadeRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    SceneManager.LoadScene("Map");
                  
  
                }
                else 
                {
                    GameObject.Find("SceneRandomizer").GetComponent<SceneRandomizer>().loadrandomScene();
                }
                
            }
            else// else punta sa mini games kasi same dialogue to sa help scenes
            {
                switch (DataPersistor.persist.sectorCity)
                {
                    case "Metals": SceneManager.LoadScene("MinigameFullDragDrop"); break;
                    case "NonMetals": SceneManager.LoadScene("MinigameFreeThrow"); break;
                    case "Metalloids": SceneManager.LoadScene("MinigameDodgeGame"); break;
                    case "Unknown": SceneManager.LoadScene("MinigameTapCompound"); break;
                }
                //// check yung tag kung anong city for minigames
                //if (DataPersistor.persist.sectorCity.Equals("Metals"))
                //{
                //    //minigame combine elements
                //    SceneManager.LoadScene("MinigameFullDragDrop");
                //}
                //else if (DataPersistor.persist.sectorCity.Equals("NonMetals"))
                //{
                //    // FreeThrow basketball
                //    SceneManager.LoadScene("MinigameFreeThrow");
                //}
                //else if (DataPersistor.persist.sectorCity.Equals("Metalloids"))
                //{
                //    // DodgeGame
                //    SceneManager.LoadScene("MinigameDodgeGame");
                //}
                //else if(DataPersistor.persist.sectorCity.Equals("Unknown"))
                //{
                //    // Tapcompound
                //    SceneManager.LoadScene("MinigameTapCompound");
                //}
                  
               
            }
        }
    }
    IEnumerator PostScores()
    {
        postScoresRunning = true;
        string post_url = Configuration.BASE_ADDRESS+"AddNewHighScore.php?sector="+DataPersistor.persist.currentSectorNumber+"&playerid="+DataPersistor.persist.user.ID+"&pscore="+ DataPersistor.persist.totalPoints;
        //string post_url = Configuration.BASE_ADDRESS + "AddNewHighScore.php?sector=" + 16 + "&playerid=" + 12+ "&pscore=" + 1000;
        Debug.Log(DataPersistor.persist.currentSectorNumber);
        Debug.Log(DataPersistor.persist.user.ID);
        Debug.Log("KEALU nagana posting");
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        postScoresRunning = false;
    }

    private IEnumerator PostPointsAndHelpsMade()
    {
        Debug.Log("POSTPOINTSHELPSMADE");
        postPointsAndHelpsMadeRunning = true;
        string post_url = Configuration.BASE_ADDRESS + "UpdateScoreHelps.php?playerid="+ DataPersistor.persist.user.ID +"&totalpoints="+DataPersistor.persist.totalPoints+"&helps="+DataPersistor.persist.helpsMade;
        
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
      
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        postPointsAndHelpsMadeRunning = false;
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = dialogueString.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !isStringBeingRevealed)
        {
            if (!isStringBeingRevealed)
            {
                isStringBeingRevealed = true;
                StartCoroutine(DisplayString(dialogueString[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    isEndOfDialogue = true;
                }
                
                
            }
            yield return 0;
        }


        //HideIcon();
        //isEndOfDialogue = false;
        //isDialoguePlaying = false;

    }﻿

    private void HideIcon()
    {
        continueIcon.SetActive(false);
      
    }

    private void ShowIcon() 
    {
        continueIcon.SetActive(true);
    }
}
