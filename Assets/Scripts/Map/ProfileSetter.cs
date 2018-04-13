using Assets.Scripts.Minigame.Models;
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
	

}
