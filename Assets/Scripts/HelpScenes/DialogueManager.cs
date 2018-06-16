using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public Sprite[] BlueProHero;
    public Sprite[] RedProHero;
    public Sprite[] GreenProHero;
    public Sprite[] YellowProHero;

	// Use this for initialization
	void Awake () {
        BlueProHero = Resources.LoadAll<Sprite>("CharacterandHeroAssets/HEROES/BLUE/800px");
        RedProHero = Resources.LoadAll<Sprite>("CharacterandHeroAssets/HEROES/RED/800px");
        GreenProHero = Resources.LoadAll<Sprite>("CharacterandHeroAssets/HEROES/GREEN/800px");
        YellowProHero = Resources.LoadAll<Sprite>("CharacterandHeroAssets/HEROES/YELLOW/800px");
	}

    public Sprite[] GetHeroByTeam(int teamcolorid)
    {
        if(teamcolorid == 1)
        {
            return BlueProHero;
        }
        else if(teamcolorid == 2)
        {
            return RedProHero;
        }
        else if(teamcolorid == 3)
        {
            return GreenProHero;
        }
        else if(teamcolorid == 4)
        {
            return YellowProHero;
        }
        return null;
    }

}
