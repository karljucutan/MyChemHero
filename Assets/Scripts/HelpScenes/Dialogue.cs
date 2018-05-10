using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{

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
    //minigames
    //G1 = Mixing Compounds(Elements Names)
    //G2 = Mixing Compounds(Elements Symbols)
    //G3 = Mixing Compounds(Swapping Slots)
    //G4 = Segregation(Toxicity)
    //G5 = Segregation(Metal, Nonmetal, Metalloids
    //G6 = Segregation(Solid, Liquid, Gas)
    //G7 = Freethrow(Elements found in item)
    //G8 = Freethrow(Toxic or NonToxic)
    //G9 = Freethrow(Fill in the blanks)


    //mingames scene name                           // Temporary Names //Replace with Scene Names
    List<string> gamesCityId_1 = new List<string>() { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9" };
    List<string> gamesCityId_2 = new List<string>() { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9" };
    List<string> gamesCityId_3 = new List<string>() { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9" };
    List<string> gamesCityId_4 = new List<string>() { "G1", "G2", "G3", "G5", "G6", "G7", "G9" };
    List<string> gamesCityId_5 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_6 = new List<string>() { "G5", "G6", "G9" };
    List<string> gamesCityId_7 = new List<string>() { "G4", "G7", "G8" };
    List<string> gamesCityId_8 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_9 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_10 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_11 = new List<string>() { "G3", "G4", "G5" };
    List<string> gamesCityId_12 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_13 = new List<string>() { "G5", "G6" };
    List<string> gamesCityId_14 = new List<string>() { "G5", "G6" };
    List<string> gamesCityId_15 = new List<string>() { "G5", "G6" };
    List<string> gamesCityId_16 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_17 = new List<string>() { "G4", "G5", "G6", "G7", "G8" };
    List<string> gamesCityId_18 = new List<string>() { "G4", "G5", "G6", "G8" };
    List<string> gamesCityId_19 = new List<string>() { "Prologue", "Map" };

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
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "HELPASGOODASNEW";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;

            case "Help_BakersDilemma":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_BakersDilemma";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_CloudSeeding":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_CloudSeeding";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_Fire":               
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_Fire";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_LandLubberScurvy":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_LandLubberScurvy";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_MedicPanic":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_MedicPanic";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_Shokugeki":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_Shokugeki";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_StayCleanStaySafe":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_StayCleanStaySafe";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_ToothFairy":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_ToothFairy";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
            case "Help_ToSpace":
                dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                dialogue[0] = "Help_ToSpace";
                dialogue[1] = DataPersistor.persist.sectorCity;
                dialogueString = dialogue;
                break;
        }
    }


    void Start()
    {
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
            if (currentScene.name.Equals("Help_EndingSceneForAll")) // End Scene
            {
                if (DataPersistor.persist.mTime.minutes <= 0 && DataPersistor.persist.mTime.seconds <= 0)
                {
                    string[] info = DataPersistor.persist.values[DataPersistor.persist.currentSectorNumber - 1].Split(';');
                    var currentScore = int.Parse(info[1]);
                    Debug.Log("ID:" + (info[0]) + " SectorNumber:  " + DataPersistor.persist.currentSectorNumber + " Score: " + currentScore);

                    if (DataPersistor.persist.totalPoints > currentScore)
                    {
                        Debug.Log(DataPersistor.persist.totalPoints);
                        StartCoroutine(PostScores());
                    }
                    while (postScoresRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    if (DataPersistor.persist.totalPoints > 0 || DataPersistor.persist.helpsMade > 0)
                    {
                        StartCoroutine(PostPointsAndHelpsMade());
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
                //loading of games depending on the city
                switch (DataPersistor.persist.sectorCity)
                {
                    case "CityId_1":

                        DataPersistor.persist.ElementsList = new List<string>() { "H", "Li", "Na", "K", "Rb", "Cs" };
                        DataPersistor.persist.CompoundsList = new List<string>() { "H2O", "H2O2" };
                        DataPersistor.persist.ToxicList = new List<string>() { "H", "Li", "Na"};
                        DataPersistor.persist.NonToxicList = new List<string>() { "K", "Rb", "Cs" };
                        //var scene = RandomMinigame(gamesCityId_1);
                        //temporary Delete bot line uncomment up line
                        var scene = "MinigameFreeThrowVer2";
                        switch (scene)
                        {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                            case "MinigameFreeThrowVer1": SetTime(0, 20, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                            case "MinigameFreeThrowVer2": SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                            case "MinigameFreeThrowVer3": SetTime(0, 20, 10); DataPersistor.persist.Timechange = 10; break;
                            //case "MinigameFullDragDropVer1": SetTime(0, 30, 10); break;
                            //case "MinigameFullDragDropVer2": SetTime(0, 30, 10); break;
                            //case "MinigameFullDragDropVer3s": SetTime(0, 30, 10); break;
                            //case "3rdgameVer1": SetTime(0, 30, 10); break;
                            //case "3rdgameVer2": SetTime(0, 30, 10); break;
                            //case "3rdgameVer3": SetTime(0, 30, 10); break;
                        }
                         SceneManager.LoadScene(scene); break;

                    case "CityId_2":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break; 
                    case "CityId_4":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break;   
                    case "CityId_6":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_7":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_8":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_9":    SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_10":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_11":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_12":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_13":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_14":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_15":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_16":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_17":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_18":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                    case "CityId_19":   SceneManager.LoadScene("MinigameFreeThrowVer1"); break;
                }
            }
        }
    }

    private string RandomMinigame(List<string> minigameslist)
    {
        var randomnum = Random.Range(0, minigameslist.Count);
        return minigameslist[randomnum];
    }

    private void SetTime(int minutes, int seconds, int milliSeconds)
    {
        DataPersistor.persist.mTime.minutes = minutes;
        DataPersistor.persist.mTime.seconds = seconds;
        DataPersistor.persist.mTime.milliseconds = milliSeconds;
    }
    
    private 
    IEnumerator PostScores()
    {
        postScoresRunning = true;
        string post_url = Configuration.BASE_ADDRESS + "AddNewHighScore.php?sector=" + DataPersistor.persist.currentSectorNumber + "&playerid=" + DataPersistor.persist.user.ID + "&pscore=" + DataPersistor.persist.totalPoints;

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
       
        postPointsAndHelpsMadeRunning = true;
        string post_url = Configuration.BASE_ADDRESS + "UpdateScoreHelps.php?playerid=" + DataPersistor.persist.user.ID + "&totalpoints=" + DataPersistor.persist.totalPoints + "&helps=" + DataPersistor.persist.helpsMade;

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

    }

    private void HideIcon()
    {
        continueIcon.SetActive(false);

    }

    private void ShowIcon()
    {
        continueIcon.SetActive(true);
    }
}
