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
        DialogueText.GetComponent<Dialogue>().dialogueString = DataPersistor.persist.endSceneDialogueString;
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
