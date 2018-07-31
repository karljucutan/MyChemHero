using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreScriptVer1and3 : MonoBehaviour {

    public Text text;
    
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag.Equals("Ball"))
        {

            //if(BallChoiceManagerVer1and3.randomItem.Contains(collide.gameObject.name) && DataPersistor.persist.mTime.seconds > 0)
            var compound = ListOfCompounds.Compounds.Where(c => c.Name.Equals(BallChoiceManagerVer1and3.randomItem)).FirstOrDefault();
            if (compound.Composition.Contains(collide.gameObject.name) && DataPersistor.persist.mTime.seconds > 0)
            {
                DataPersistor.persist.accumulatedPoints += 1;

                AudioManager.instance.Play("Cheer");//SOUND EFFECT
                text.text = string.Format("{0:00}", DataPersistor.persist.accumulatedPoints);
            }
        }
    }

   
}
