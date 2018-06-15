using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Minigame.Models;
using System.Linq;
using Assets.Scripts;

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
    public GameObject UserTotalPoints;
    public GameObject UserNoOfSectorsHold;
    public GameObject UserHelpsMade;
    

    public GameObject profilesetter;
    public GameObject Prefabplayermember;
    public Transform TeamContentSizeFilter;
    public GameObject scoremanager;
    //TeamProfile
    public GameObject TeamName;
    public GameObject ProHero;
    public GameObject TeamFlag;
    public GameObject TeamID;
    public GameObject TeamTotalPoints;
    public GameObject TeamNoOfSectorsHold;
    public GameObject TeamHelpsMade;

    private void OnEnable()
    {
        //StartCoroutine(DataPersistor.persist.RetrieveUserInfo());
        if (DataPersistor.persist.doneLoadingAllUsers)
        {
            var user = ListOfUser.ALLUSERS.Where(u => u.ID.Equals(DataPersistor.persist.user.ID)).SingleOrDefault();
            UserName.GetComponent<Text>().text = DataPersistor.persist.user.UserName;
            UserCharBody.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Body);
            UserCharHair.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Hair);
            UserCharEyebrows.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.EyeBrows);
            UserCharEyes.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Eyes);
            UserCharNose.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Nose);
            UserCharMouth.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(DataPersistor.persist.user.UserCharacter.Gender, DataPersistor.persist.user.UserCharacter.Mouth);
            UserTotalPoints.GetComponent<Text>().text = user.TotalScore.ToString();
            UserId.GetComponent<Text>().text = DataPersistor.persist.user.ID.ToString();
            UserNoOfSectorsHold.GetComponent<Text>().text = user.SectorsHold.ToString();
            UserHelpsMade.GetComponent<Text>().text = user.HelpsMade.ToString();

            var teammembers = ListOfUser.ALLUSERS.Where(u => u.TeamId.Equals(DataPersistor.persist.user.TeamId)).ToList();
            var team = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(DataPersistor.persist.user.TeamId)).SingleOrDefault();
            team.members = new List<User>();
            team.members = teammembers;

            ProHero.GetComponent<Image>().overrideSprite = scoremanager.GetComponent<ScoreManager>().TeamHeroes[team.teamColorId - 1];
            TeamFlag.GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().TeamFlag[team.teamColorId - 1];
            TeamName.GetComponent<Text>().text = team.teamName;
            TeamID.GetComponent<Text>().text = team.teamId.ToString();
            TeamTotalPoints.GetComponent<Text>().text = team.members.Sum(u => u.TotalScore).ToString();
            TeamNoOfSectorsHold.GetComponent<Text>().text = team.members.Sum(u => u.SectorsHold).ToString();
            TeamHelpsMade.GetComponent<Text>().text = team.members.Sum(u => u.HelpsMade).ToString();

            foreach (var player in team.members)
            {
                var member = Instantiate(Prefabplayermember, TeamContentSizeFilter);
                member.transform.GetChild(0).GetComponent<Text>().text = player.UserName;
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterBody(player.UserCharacter.Gender, player.UserCharacter.Body);
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyebrows(player.UserCharacter.Gender, player.UserCharacter.EyeBrows);
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterEyes(player.UserCharacter.Gender, player.UserCharacter.Eyes);
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterNose(player.UserCharacter.Gender, player.UserCharacter.Nose);
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterMouth(player.UserCharacter.Gender, player.UserCharacter.Mouth);
                member.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().overrideSprite = profilesetter.GetComponent<ProfileSetter>().GetCharacterHair(player.UserCharacter.Gender, player.UserCharacter.Hair);

            }
        }
    }

    private void OnDisable()
    {
        for(int i = 2; i < TeamContentSizeFilter.childCount; i++)
        {
           Destroy(TeamContentSizeFilter.GetChild(i).gameObject);
        }
       
    }
}
