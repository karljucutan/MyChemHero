using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneSetter : MonoBehaviour {

    public string endSceneBG;

	void Start () {
        DataPersistor.persist.endSceneBG = endSceneBG;


	}
	

}
