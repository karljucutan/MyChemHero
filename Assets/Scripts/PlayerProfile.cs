using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour {
    //Myprofile
    public GameObject UserName;
    public GameObject UserCharBody;
    public GameObject UserCharHair;
    public GameObject UserCharEyebrows;
    public GameObject UserCharEyes;
    public GameObject UserCharNose;
    public GameObject UserCharMouth;
    public GameObject UserId;
    public GameObject UserRank;
    public GameObject UserTotalPoints;
    public GameObject UserNoOfSectorsHold;
    public GameObject UserHelpsMade;
    public GameObject PanelAchievement;

    public GameObject profilesetter;

    //TeamProfile
    //public GameObject;
    //public GameObject;
    //public GameObject;
    //public GameObject;
    //public GameObject;
    //public GameObject;

    void Start()
    {
        for (int i = 0; i < DataPersistor.persist.user.Badges.Count; i++)
        {

            Debug.Log(DataPersistor.persist.user.Badges.Count);
            Debug.Log(DataPersistor.persist.user.Badges[i] + "BADGETO");
        }
    }
    private void OnEnable()
    {
        //StartCoroutine(DataPersistor.persist.RetrieveUserInfo());

        UserName.GetComponent<Text>().text = DataPersistor.persist.user.UserName;
        UserCharBody.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Body);
        UserCharHair.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Hair);
        UserCharEyebrows.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.EyeBrows);
        UserCharEyes.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Eyes);
        UserCharNose.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Nose);
        UserCharMouth.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Mouth);
        UserTotalPoints.GetComponent<Text>().text = DataPersistor.persist.user.TotalScore.ToString();
        UserId.GetComponent<Text>().text = DataPersistor.persist.user.ID.ToString();
        UserNoOfSectorsHold.GetComponent<Text>().text = DataPersistor.persist.user.SectorsHold.ToString();
        UserHelpsMade.GetComponent<Text>().text = DataPersistor.persist.user.HelpsMade.ToString();

        for (int i = 0; i < DataPersistor.persist.user.Badges.Count - 1; i++)
        {
            if (i>4)
            { break; }
            PanelAchievement.transform.Find("Badge" + i).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Badges/Badge" + DataPersistor.persist.user.Badges[i]);

        }
         //PanelAchievement.transform.Find("Badge1").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Badges/Badge" + DataPersistor.persist.user.Badges[0]);



        //teamprofile
      

    }
   

   

 

}
