using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts;

public class EndScenePropertyLoader : MonoBehaviour {
    private string endSceneBG;
    private string endSceneHeroImage;
    private string[] endSceneDialogueString;
    public GameObject profilesetter;

    public GameObject Background;
    public GameObject HeroImage;
    public GameObject DialogueText;
    public GameObject CharacterFlag;

    public GameObject CharacterBody;
    public GameObject CharacterHair;
    public GameObject CharacterEyebrows;
    public GameObject CharacterEyes;
    public GameObject CharacterNose;
    public GameObject CharacterMouth;

    public GameObject UserName;
    public GameObject TeamName;

    public GameObject AccumulatedPoints;
    public GameObject Multiplier;
    public GameObject TotalPoints;
    private void Awake()
    {
        //    
        string[] endSceneDialogueStringWIN = new string[2];
        endSceneDialogueStringWIN[0] = "Wow! You have conquered the sector!";
        endSceneDialogueStringWIN[1] = "Good Job Apprentice, keep up the good work and keep up conquering the sectors!";

        string[] endSceneDialogueStringLOSE = new string[2];
        endSceneDialogueStringLOSE[0] = "Ughhhhh, You have failed to conquer the sector...";
        endSceneDialogueStringLOSE[1] = "Try again and better luck next time!";

        string[] info = DataPersistor.persist.values[DataPersistor.persist.currentSectorNumber - 1].Split(';');
        var currentScore = int.Parse(info[1]);

        DataPersistor.persist.totalPoints = DataPersistor.persist.accumulatedPoints * DataPersistor.persist.difficultyMultiplier;
        Debug.Log("ID:" + (info[0]) + " SectorNumber:  " + DataPersistor.persist.currentSectorNumber + " Score: " + currentScore);
        Debug.Log("TOTALPOINTS: " + DataPersistor.persist.totalPoints);
        if (DataPersistor.persist.totalPoints >= currentScore && DataPersistor.persist.totalPoints!=0)
        {
            DialogueText.GetComponent<Dialogue>().dialogueString = endSceneDialogueStringWIN;
        }
        else
        {
            DialogueText.GetComponent<Dialogue>().dialogueString = endSceneDialogueStringLOSE;
        }
        //DialogueText.GetComponent<Dialogue>().dialogueString = DataPersistor.persist.endSceneDialogueString;
    }
    private void Start()
    {
        CharacterBody.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Body);
        CharacterHair.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Hair);
        CharacterEyebrows.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.EyeBrows);
        CharacterEyes.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Eyes);
        CharacterNose.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Nose);
        CharacterMouth.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Mouth);
        CharacterFlag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[DataPersistor.persist.user.TeamId - 1];
        UserName.GetComponent<Text>().text = DataPersistor.persist.user.UserName;
        TeamName.GetComponent<Text>().text = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(DataPersistor.persist.user.TeamId)).Select(t => t.teamName).SingleOrDefault();

        AccumulatedPoints.GetComponent<Text>().text = DataPersistor.persist.accumulatedPoints.ToString();
        Multiplier.GetComponent<Text>().text = DataPersistor.persist.difficultyMultiplier.ToString();
        TotalPoints.GetComponent<Text>().text = (DataPersistor.persist.accumulatedPoints * DataPersistor.persist.difficultyMultiplier).ToString();
    }



    private void OnEnable ()
    {
        endSceneBG = DataPersistor.persist.endSceneBG;

        //Background.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/"+endSceneBG);
        Background.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CityBG/" + endSceneBG);

        // HERO IMAGE GAWING NAG BABAGO BAGO
        HeroImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + endSceneHeroImage);

        AccumulatedPoints.GetComponent<Text>().text += DataPersistor.persist.accumulatedPoints.ToString();
        TotalPoints.GetComponent<Text>().text += DataPersistor.persist.totalPoints.ToString();

       
    }

}
