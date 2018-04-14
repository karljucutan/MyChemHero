﻿using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSetter : MonoBehaviour {
    // male assets
    public Sprite[] MaleBodyChoices;
    public Sprite[] MaleHairChoices;
    public Sprite[] MaleEyeBrowsChoices;
    public Sprite[] MaleEyesChoices;
    public Sprite[] MaleNoseChoices;
    public Sprite[] MaleMouthChoices;

    //female assets
    public Sprite[] FemaleBodyChoices;
    public Sprite[] FemaleHairChoices;
    public Sprite[] FemaleEyeBrowsChoices;
    public Sprite[] FemaleEyesChoices;
    public Sprite[] FemaleNoseChoices;
    public Sprite[] FemaleMouthChoices;

    public Sprite[] TeamFlag;


    void Awake () {

        ////teamprofile
        TeamFlag = Resources.LoadAll<Sprite>("Sprites/TeamFlag");
        //myprofile
        MaleBodyChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/BODY/400px");
        MaleHairChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/HAIR/400px");
        MaleEyeBrowsChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/BROWS/400px");
        MaleEyesChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/EYES/400px");
        MaleNoseChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/NOSE/400px");
        MaleMouthChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/MALE SET/MOUTH/400px");

        FemaleBodyChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/BODY/400px");
        FemaleHairChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/HAIR/400px");
        FemaleEyeBrowsChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/BROWS/400px");
        FemaleEyesChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/EYES/400px");
        FemaleNoseChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/NOSE/400px");
        FemaleMouthChoices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/FEMALE SET/MOUTH/400px");


    }

    public Sprite GetCharacterBody(string gender, int index)
    {
        Sprite body;
        if (gender.Equals("male"))
        {
            body = MaleBodyChoices[index];
        }
        else
        {
            body = FemaleBodyChoices[index];
        }
        return body;
    }

    public Sprite GetCharacterHair(string gender, int index)
    {
        Sprite hair;
        if (gender.Equals("male"))
        {
            hair = MaleHairChoices[index];
        }
        else
        {
            hair = FemaleHairChoices[index];
        }
        return hair;
    }

    public Sprite GetCharacterEyebrows(string gender, int index)
    {
        Sprite eyebrows;
        if (gender.Equals("male"))
        {
            eyebrows = MaleEyeBrowsChoices[index];
        }
        else
        {
            eyebrows = FemaleEyeBrowsChoices[index];
        }
        return eyebrows;
    }

    public Sprite GetCharacterEyes(string gender, int index)
    {
        Sprite eyes;
        if (gender.Equals("male"))
        {
            eyes = MaleEyesChoices[index];
        }
        else
        {
            eyes = FemaleEyesChoices[index];
        }
        return eyes;
    }

    public Sprite GetCharacterNose(string gender, int index)
    {
        Sprite nose;
        if (gender.Equals("male"))
        {
            nose = MaleNoseChoices[index];
        }
        else
        {
            nose = FemaleNoseChoices[index];
        }
        return nose;
    }

    public Sprite GetCharacterMouth(string gender, int index)
    {
        Sprite mouth;
        if (gender.Equals("male"))
        {
            mouth = MaleMouthChoices[index];
        }
        else
        {
            mouth = FemaleMouthChoices[index];
        }
        return mouth;
    }


}
