using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRend;

    void Start()
    {
        AudioManager.instance.StopAll();//stops music playing from previous scene
        AudioManager.instance.Play("Customize");

        
        if(!string.IsNullOrEmpty(DataPersistor.persist.colorStr))
        {
            spriteRend = gameObject.GetComponent<SpriteRenderer>();
            //spriteRend.color = setColor(DataPersistor.persist.colorStr);
            spriteRend.sprite = setSprite(DataPersistor.persist.colorStr);
        }
            

    }
    public Color setColor(string _color)
    {
        Color newColor = new Color();
        switch (_color)
        {
            case "blue": newColor = Color.blue; SetTeamId(1); break;
            case "red": newColor = Color.red; SetTeamId(2); break;
            case "green": newColor = Color.green; SetTeamId(3); break;
            case "yellow": newColor = Color.yellow; SetTeamId(4); break;
        }
        return newColor;
    }
    public Sprite setSprite(string color)
    {
        Sprite newSprite = new Sprite();

        switch (color)
        {
            case "blue": newSprite = Resources.Load<Sprite>("Sprites/BGHexBlue"); SetTeamId(1); break;
            case "red": newSprite = Resources.Load<Sprite>("Sprites/BGHexRed"); SetTeamId(2); break;
            case "green": newSprite = Resources.Load<Sprite>("Sprites/BGHexGreen"); SetTeamId(3); break;
            case "yellow": newSprite = Resources.Load<Sprite>("Sprites/BGHexYellow"); SetTeamId(4); break;
        }

        return newSprite;

    }

    // 1 = blue 2 = red 3 = green 4 = yellow
    private void SetTeamId(int colorId)
    {
        DataPersistor.persist.teamId = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(colorId)).Select(t => t.teamId).SingleOrDefault();
    }

}
