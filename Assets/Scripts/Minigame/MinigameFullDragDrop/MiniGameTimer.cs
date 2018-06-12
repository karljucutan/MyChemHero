using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameTimer : MonoBehaviour {

    public Text Time;
    private ModelTime mTime;
    public GameObject panelCorrectAnswerContainer;
    public GameObject textFail;
    private string time;

    bool timeIsRunning = true;


    private void Start()
    {
        mTime = new ModelTime();
        mTime = DataPersistor.persist.mTime;// para sa natitirang time

        InvokeRepeating("Timer", 0, 0.1f);

    }

    private void Timer()
    {
        if (timeIsRunning)
        {
            mTime.milliseconds--;

            time = string.Format("{0:00}:{1:00}.{2:00}", mTime.minutes, mTime.seconds, mTime.milliseconds);
            Time.text = time;
            if (mTime.minutes <= 0 && mTime.seconds <= 0 && mTime.milliseconds <= 0)
            {

                timeIsRunning = false;
                Time.text = "Time's up.";  
                textFail.GetComponent<Text>().text = "Time's Up";
                panelCorrectAnswerContainer.SetActive(true);
                //SetScoreFailed();


            }
            if (mTime.minutes > 0 && mTime.seconds <= 0)
            {
                mTime.minutes -= 1;
                mTime.seconds = 59;
            }
            if (mTime.milliseconds <= 0)
            {
                mTime.milliseconds = 10;
                mTime.seconds -= 1;
            }


        }
     

    }

    private void SetScoreFailed()
    {
        DataPersistor.persist.accumulatedPoints = 0;
        DataPersistor.persist.totalPoints += 0;
    }

    public void pause()
    {
        timeIsRunning = false;
        DataPersistor.persist.mTime = mTime;
    }
}
