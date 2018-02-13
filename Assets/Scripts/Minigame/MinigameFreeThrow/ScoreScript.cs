﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text text;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag.Equals("Ball"))
        {
            if (DataPersistor.persist.compoundNeeded.Equals(collide.gameObject.name) && (DataPersistor.persist.mTime.seconds > 0))
            {
                DataPersistor.persist.totalPoints += 1;
                DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
                //SOUND EFFECT
                text.text = string.Format("{0:00}", DataPersistor.persist.totalPoints);
            }
        }
    }

   
}
