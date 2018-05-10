using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndScenePropertyLoader : MonoBehaviour {
    private string endSceneBG;
    private string endSceneHeroImage;
    private string[] endSceneDialogueString;
    public GameObject profilesetter;

    public GameObject Background;
    public GameObject HeroImage;
    public GameObject DialogueText;
    public GameObject CharacterFlag;
    public GameObject CharacterFace;
    public GameObject CharacterHair;
    public GameObject CharacterEyes;
    public GameObject CharacterNose;
    public GameObject CharacterMouth;
    public GameObject UserName;
    public GameObject ImageCompound;
    public GameObject Compound;
    public GameObject ElementsCombined;
    public GameObject AccumulatedPoints;
    public GameObject TotalPoints;

    private void Start()
    {
        //CharacterFace.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().FaceChoices[DataPersistor.persist.user.UserCharacter.Face];
        //CharacterHair.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().HairChoices[DataPersistor.persist.user.UserCharacter.Hair];
        //CharacterEyes.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().EyesChoices[DataPersistor.persist.user.UserCharacter.Eyes];
        //CharacterNose.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().NoseChoices[DataPersistor.persist.user.UserCharacter.Nose];
        //CharacterMouth.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().MouthChoices[DataPersistor.persist.user.UserCharacter.Mouth];
        CharacterFlag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[DataPersistor.persist.user.TeamId];
        UserName.GetComponent<Text>().text = DataPersistor.persist.user.UserName;
    }



    private void OnEnable ()
    {
        endSceneBG = DataPersistor.persist.endSceneBG;
        endSceneHeroImage = DataPersistor.persist.endSceneHeroImage;
        // end scene dialogue PWEDENG MAG CREATE NALANG NG ARRAY OF STRINGS NA IRARANDOM KUNG ANONG SASABIHIN
        endSceneDialogueString = DataPersistor.persist.endSceneDialogueString;

        // ILOAD SA UI!
        Background.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/"+endSceneBG);
        HeroImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+endSceneHeroImage);
        DialogueText.GetComponent<Dialogue>().dialogueString = endSceneDialogueString;

        //string time;
        //if (DataPersistor.persist.mTime.minutes <= 0 && DataPersistor.persist.mTime.seconds <= 0)
        //{
        //    time = string.Format("{0:00}:{1:00}.{2:00}", 0, 0, 0);
        //}
        //else
        //{
        //    time = string.Format("{0:00}:{1:00}.{2:00}", DataPersistor.persist.mTime.minutes, DataPersistor.persist.mTime.seconds, DataPersistor.persist.mTime.milliseconds);
        //}
        //TimeLeft.GetComponent<Text>().text += time;

        AccumulatedPoints.GetComponent<Text>().text += DataPersistor.persist.accumulatedPoints.ToString();
        TotalPoints.GetComponent<Text>().text += DataPersistor.persist.totalPoints.ToString();

        ImageCompound.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Compounds/"+DataPersistor.persist.compoundNeeded);
        Compound.GetComponent<Text>().text = DataPersistor.persist.compoundNeeded;
        ElementsCombined.GetComponent<Text>().text = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Value.Equals(DataPersistor.persist.compoundNeeded)).Select(ec => ec.elementcompound.Key).SingleOrDefault();
    }

}
