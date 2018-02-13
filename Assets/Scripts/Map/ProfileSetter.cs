using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSetter : MonoBehaviour {
   
    public Sprite[] FaceChoices;
    public Sprite[] HairChoices;
    public Sprite[] EyesChoices;
    public Sprite[] NoseChoices;
    public Sprite[] MouthChoices;

    public Sprite[] TeamFlag;


    
    void Awake () {

        ////teamprofile
        TeamFlag = Resources.LoadAll<Sprite>("Sprites/TeamFlag");
        //myprofile
        FaceChoices = Resources.LoadAll<Sprite>("CharacterCustomization/Face");
        HairChoices = Resources.LoadAll<Sprite>("CharacterCustomization/Hair");
        EyesChoices = Resources.LoadAll<Sprite>("CharacterCustomization/Eyes");
        NoseChoices = Resources.LoadAll<Sprite>("CharacterCustomization/Nose");
        MouthChoices = Resources.LoadAll<Sprite>("CharacterCustomization/Mouth");


    }
	

}
