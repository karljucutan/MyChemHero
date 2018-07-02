using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneSetter : MonoBehaviour {

    private string endSceneBG;
    public GameObject bgGameobj;

	void Awake () {

        endSceneBG = DataPersistor.persist.sectorCity;
        //switch(endSceneBG)
        //{
        //    case "CityId_1": bgGameobj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CityBG/"+endSceneBG); break;
        //    case "CityId_2": bgGameobj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CityBG/" + endSceneBG); break;
        //}
        bgGameobj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CityBG/" + endSceneBG);

        DataPersistor.persist.endSceneBG = endSceneBG;
	}
	

}
