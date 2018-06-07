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
    List<string> gamesCityId_1 = new List<string>() { 
        "SegregationVer2"};
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

    private string minigame;
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (!currentScene.name.Equals("Help_EndingSceneForAll"))
        {
            DialogueSetter();
        }
    }

    private void DialogueSetter()
    {
        RandomMinigameSetTimeandDialogue();
     
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
                //if (DataPersistor.persist.mTime.minutes <= 0 && DataPersistor.persist.mTime.seconds <= 0)
                //{
                    string[] info = DataPersistor.persist.values[DataPersistor.persist.currentSectorNumber - 1].Split(';');
                    var currentScore = int.Parse(info[1]);
                    Debug.Log("ID:" + (info[0]) + " SectorNumber:  " + DataPersistor.persist.currentSectorNumber + " Score: " + currentScore);

                    DataPersistor.persist.totalPoints = DataPersistor.persist.accumulatedPoints * DataPersistor.persist.difficultyMultiplier;
                    if (DataPersistor.persist.totalPoints > currentScore)
                    {
                        //Debug.Log(DataPersistor.persist.totalPoints);
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
                    DataPersistor.persist.accumulatedPoints = 0;
                    while (postPointsAndHelpsMadeRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    SceneManager.LoadScene("Map");


                //}
                //else
                //{
                //    GameObject.Find("SceneRandomizer").GetComponent<SceneRandomizer>().loadrandomScene();
                //}

            }
            else// else punta sa mini games kasi same dialogue to sa help scenes
            {
                SceneManager.LoadScene(minigame);
            }
        }
    }

    private string Randomizer(List<string> minigameslist)
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


    private void RandomMinigameSetTimeandDialogue()
    {
        // settime 60 / x 1 multiplier - level 1 difficulty
        //         50 / x 2 multiplier - level 2 difficulty
        //         40 / x 3 multiplier - level 3 difficulty
    
        string[] dialogue;
        string[] endSceneDialogueString;

        switch (DataPersistor.persist.sectorCity)
        {
            case "CityId_1": // level 2 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "H", "Li", "Mo"}; // ilagay yung iba pang elements na hindi part ng city pero pwede ipang mix sa ibang elements       
                DataPersistor.persist.CompoundsList = new List<string>() { "H2O" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "H", "Li", "Na", "K", "Rb", "Cs" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Na", "Li" };
                DataPersistor.persist.NonToxicList = new List<string>() { "H", "K", "Rb", "Cs" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 2;

                //minigame = Randomizer(gamesCityId_1);
                //temporary Delete bot line uncomment up line
                minigame = "MinigameFreeThrowVer1";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                       
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;


                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    case "MinigameFreeThrowVer3": 
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    //case "MinigameFullDragDropVer1": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer2": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer3s": SetTime(0, 30, 10); break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;


                        DataPersistor.persist.segregationTimer = 50;break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;


                        DataPersistor.persist.segregationTimer = 50;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;


                        DataPersistor.persist.segregationTimer = 50;
                        break; //SetTime(0, 30, 10); break;
                    //case "3rdgameVer2": SetTime(0, 30, 10); break;
                    //case "3rdgameVer3": SetTime(0, 30, 10); break;
                }

                break;

            case "CityId_2":// level 2 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Be", "Mg", "Ca", "Sr", "Ba", "Ra" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Be", "Mg", "Ca", "Sr", "Ba", "Ra" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Be", "Sr", "Ra"};
                DataPersistor.persist.NonToxicList = new List<string>() { "Mg", "Ca", "Ba"};
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 2;

                //minigame = Randomizer(gamesCityId_2);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    case "MinigameFreeThrowVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    //case "MinigameFullDragDropVer1": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer2": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer3s": SetTime(0, 30, 10); break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break;
                   
                }
                break;
            case "CityId_3":// level 2 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Sc", "Y", "Ti", "Zr", "Hf" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Sc", "Y", "Ti", "Zr", "Hf" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() {"Zr"};
                DataPersistor.persist.NonToxicList = new List<string>() { "Sc", "Y", "Ti", "Hf"};
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 2;

                //minigame = Randomizer(gamesCityId_3);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    case "MinigameFreeThrowVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    //case "MinigameFullDragDropVer1": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer2": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer3s": SetTime(0, 30, 10); break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break; //SetTime(0, 30, 10); break;
                               //case "3rdgameVer2": SetTime(0, 30, 10); break;
                               //case "3rdgameVer3": SetTime(0, 30, 10); break;
                }
                break;
            case "CityId_4":// level 2 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "V", "Nb", "Ta", "Cr", "Mo", "W" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 2;

                //minigame = Randomizer(gamesCityId_4);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                    
                    case "MinigameFreeThrowVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    //case "MinigameFullDragDropVer1": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer2": SetTime(0, 30, 10); break;
                    //case "MinigameFullDragDropVer3s": SetTime(0, 30, 10); break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break; //SetTime(0, 30, 10); break;
                               //case "3rdgameVer2": SetTime(0, 30, 10); break;
                               //case "3rdgameVer3": SetTime(0, 30, 10); break;
                }
                break;

            case "CityId_5":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Mn", "Tc", "Re", "Fe", "Ru", "Os" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Mn", "Tc", "Re", "Fe", "Ru", "Os" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Tc", "Ru", "Os" };
                DataPersistor.persist.NonToxicList = new List<string>() { "Mn", "Re", "Fe" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_5);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;

                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_6":// level 3 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Co", "Rh", "Ir", "Ni", "Pd", "Pt" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 3;

                //minigame = Randomizer(gamesCityId_6);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break; 
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break; 
                }
                break;

            case "CityId_7":// level 2 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "Cu", "Ag", "Au", "Zn", "Cd", "Hg" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Cu", "Ag", "Au", "Zn", "Cd", "Hg" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Cd", "Hg" };
                DataPersistor.persist.NonToxicList = new List<string>() { "Cu", "Ag", "Au", "Zn" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 2;

                //minigame = Randomizer(gamesCityId_7);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer1";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break; // DataPersistor.persist.Timechange - n sa time ,every n seconds change ng compound sa freethrowgame
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                    case "MinigameFreeThrowVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 50, 10); DataPersistor.persist.Timechange = 10; break;
                   
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 50;
                        break; //SetTime(0, 30, 10); break;
                               //case "3rdgameVer2": SetTime(0, 30, 10); break;
                               //case "3rdgameVer3": SetTime(0, 30, 10); break;
                }
                break;
            case "CityId_8":// level 1 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "B", "Al", "Ga", "In", "Tl" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "B", "Al", "Ga", "In", "Tl" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "B", "Tl" };
                DataPersistor.persist.NonToxicList = new List<string>() { "Al", "Ga", "Au", "In" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_8);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 30;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 30;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 30;
                        break; 
                }
                break;

            case "CityId_9":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "C", "Si", "Ge", "Sn", "Pb" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "C", "Si", "Ge", "Sn", "Pb" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Pb" };
                DataPersistor.persist.NonToxicList = new List<string>() { "C", "Si", "Ge", "Sn" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_9);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_10":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "N", "P", "As", "Sb", "Bi" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "N", "P", "As", "Sb", "Bi" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "As", "Bi" };
                DataPersistor.persist.NonToxicList = new List<string>() { "N", "P", "Sb"};
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_10);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_11":// level 1 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "O", "S", "Se", "Te", "Po" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "O", "S", "Se", "Te", "Po" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Te", "Po" };
                DataPersistor.persist.NonToxicList = new List<string>() { "O", "S", "Se" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_11);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_12":// level 1 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "F", "Cl", "Br", "I", "At" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "F", "Cl", "Br", "I", "At" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "F", "Cl", "Br" };
                DataPersistor.persist.NonToxicList = new List<string>() { "I", "At" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_12);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_13":// level 3 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "He", "Ne", "Ar", "Kr", "Xe", "Rn" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 3;

                //minigame = Randomizer(gamesCityId_13);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break; 
                }
                break;
            case "CityId_14":// level 3 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "La", "Ce", "Pr", "Nd", "Pm" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 3;

                //minigame = Randomizer(gamesCityId_14);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break;
                }
                break;
            case "CityId_15":// level 3 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "Sm", "Eu", "Gd", "Tb", "Dy"};
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 3;

                //minigame = Randomizer(gamesCityId_15);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 40;
                        break;
                }
                break;
            case "CityId_16":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Ho", "Er", "Tm", "Yb", "Lu" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Ho", "Er", "Tm", "Yb", "Lu" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Ho", "Er", "Tm", "Yb", "Lu" };
                DataPersistor.persist.NonToxicList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_16);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_17":// level 1 difficulty

                DataPersistor.persist.ElementsList = new List<string>() { "Ac", "Th", "Pa", "U", "Np" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Ac", "Th", "Pa", "U", "Np" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Ac", "Th", "Pa", "U", "Np" };
                DataPersistor.persist.NonToxicList = new List<string>() {"" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_17);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                    
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
            case "CityId_18":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Pu", "Am", "Cm", "Bk", "Cf" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Pu", "Am", "Cm", "Bk", "Cf" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Pu", "Am", "Cm", "Bk", "Cf" };
                DataPersistor.persist.NonToxicList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_18);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   // mag kakamali tong time change sa shootinggame ballchoicemanager update method kapag may minutes na kasi 1:00:00 seconds yung miniminusan sa start ng time
                   
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer1";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                }
                break;
            case "CityId_19":// level 1 difficulty
                DataPersistor.persist.ElementsList = new List<string>() { "Es", "Fm", "Md", "No", "Lr" };
                DataPersistor.persist.CompoundsList = new List<string>() { "" };
                DataPersistor.persist.ElementsListForToxicNonToxic = new List<string> { "Es", "Fm", "Md", "No", "Lr" }; // only elements na part ng city
                DataPersistor.persist.ToxicList = new List<string>() { "Es", "Fm", "Md", "No", "Lr" };
                DataPersistor.persist.NonToxicList = new List<string>() { "" };
                // Level of Difficulty Multiplier
                DataPersistor.persist.difficultyMultiplier = 1;

                //minigame = Randomizer(gamesCityId_19);
                //temporary Delete bot line uncomment up line
                minigame = "SegregationVer3";
                switch (minigame)
                {   
                   
                    case "MinigameFreeThrowVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "MinigameFreeThrowVer2";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        SetTime(0, 60, 10); DataPersistor.persist.Timechange = 10; break;
                    case "SegregationVer1":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer2":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break;
                    case "SegregationVer3":
                        dialogue = new string[2]; // change size depende sa dami ng lines ng saasabihin
                        dialogue[0] = "SegregationVer3";
                        dialogue[1] = DataPersistor.persist.sectorCity;
                        dialogueString = dialogue;

                        //dialogue ng hero sa end scene
                        endSceneDialogueString = new string[3];
                        endSceneDialogueString[0] = "qwertyuiop";
                        endSceneDialogueString[1] = "asdfghjkl";
                        endSceneDialogueString[2] = "zxcvbnm";
                        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;

                        DataPersistor.persist.segregationTimer = 60;
                        break; 
                }
                break;
        }


    }
}
