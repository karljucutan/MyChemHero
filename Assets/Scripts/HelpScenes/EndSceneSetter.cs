using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneSetter : MonoBehaviour {

    public string endSceneBG;
    public string endSceneHeroImage;
    public string[] endSceneDialogueString;
    public int pointsForThisSector;
	void Start () {
        DataPersistor.persist.endSceneBG = endSceneBG;
        DataPersistor.persist.endSceneHeroImage = endSceneHeroImage;
        DataPersistor.persist.endSceneDialogueString = endSceneDialogueString;
        DataPersistor.persist.accumulatedPoints = pointsForThisSector;

	}
	

}
