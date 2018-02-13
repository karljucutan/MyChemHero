using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Minigame;
using System.Linq;

public class InputManager : MonoBehaviour {

  
    public Text TextScore;

	public void ButtonClick()
    {
        AnswerChecker();
    }

    private void AnswerChecker()
    {
        if(gameObject.name.Equals(DataPersistor.persist.compoundNeeded))
        {
            DataPersistor.persist.totalPoints += 1;
            DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
            TextScore.text = string.Format("{0:00}", DataPersistor.persist.totalPoints);
            Debug.Log("TAMA");
        }
        else
        {
            DataPersistor.persist.totalPoints -= 5;
            DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
            TextScore.text = string.Format("{0:00}", DataPersistor.persist.totalPoints);
        }
    }


}
