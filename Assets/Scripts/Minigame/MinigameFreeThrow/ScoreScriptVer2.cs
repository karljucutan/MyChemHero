using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptVer2 : MonoBehaviour {

    public Text text;
    
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag.Equals("Ball"))
        {
            if (collide.gameObject.name.Equals("toxic") && DataPersistor.persist.mTime.seconds > 0)
            {
                if(DataPersistor.persist.ToxicList.Contains(BallChoiceManagerVer2.Elements.Peek()))
                {
                    DataPersistor.persist.totalPoints += 1;
                    DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
                    //SOUND EFFECT
                    text.text = string.Format("{0:00}", DataPersistor.persist.totalPoints);
                }
            }

            if(collide.gameObject.name.Equals("nontoxic") && DataPersistor.persist.mTime.seconds > 0)
            {
                if (DataPersistor.persist.NonToxicList.Contains(BallChoiceManagerVer2.Elements.Peek()))
                {
                    DataPersistor.persist.totalPoints += 1;
                    DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
                    //SOUND EFFECT
                    text.text = string.Format("{0:00}", DataPersistor.persist.totalPoints);
                }
            }
        }
    }

   
}
