using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnProfileSetter : MonoBehaviour {

    public GameObject Btn_UserCharBody;
    public GameObject Btn_UserCharHair;
    public GameObject Btn_UserCharEyebrows;
    public GameObject Btn_UserCharEyes;
    public GameObject Btn_UserCharNose;
    public GameObject Btn_UserCharMouth;

    public GameObject profilesetter;

    void Start()
    {
        Btn_UserCharBody.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Body);
        Btn_UserCharHair.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Hair);
        Btn_UserCharEyebrows.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.EyeBrows);
        Btn_UserCharEyes.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Eyes);
        Btn_UserCharNose.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Nose);
        Btn_UserCharMouth.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Mouth);
    }
}
