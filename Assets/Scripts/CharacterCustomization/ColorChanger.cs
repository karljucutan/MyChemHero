using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRend;
    void Awake()
    {
    }

    void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        if(DataPersistor.persist != null)
        spriteRend.color = setColor(DataPersistor.persist.colorStr);

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

    // 1 = blue 2 = red 3 = green 4 = yellow
    private void SetTeamId(int colorId)
    {
        DataPersistor.persist.teamId = ListOfTeams.TeamList.Where(t => t.teamColorId.Equals(colorId)).Select(t => t.teamId).SingleOrDefault();
    }

}
