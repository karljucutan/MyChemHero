using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameFreeThrowTimer : MonoBehaviour {

    public Text Time;
    private ModelTime mTime;
    public GameObject panelStartTime;
    public GameObject panelGameOver;
    public Text textStartTime;
    private string time;
    bool timeIsRunning = true;

    private void Start()
    {
       
        mTime = new ModelTime();
        mTime.milliseconds = 10;
        mTime.seconds = 3;
        mTime.minutes = 0;
        InvokeRepeating("StartTimer", 0, 0.1f);
    }
    private void StartTimer()
    {
        mTime.milliseconds--;
        //every second SOUND EFFECTS
        time = string.Format("{0:0}", mTime.seconds);
        textStartTime.text = time;
        if (mTime.seconds <= 0 && mTime.milliseconds <= 10)
        {
            textStartTime.text = "";
            panelStartTime.SetActive(false);
            GameTimerStart();
            CancelInvoke("StartTimer");

        }
        if (mTime.milliseconds <= 0)
        {
            mTime.milliseconds = 10;
            mTime.seconds -= 1;
        }
    }

    private void GameTimerStart()
    {
        mTime = DataPersistor.persist.mTime;
        InvokeRepeating("GameTimer", 0, 0.1f);

    }

    private void GameTimer()
    {
        if (timeIsRunning)
        {
            mTime.milliseconds--;

            time = string.Format("{0:00}", mTime.seconds);
            Time.text = time;
            if (mTime.minutes <= 0 && mTime.seconds <= 0 && mTime.milliseconds <= 0)
            {
                DataPersistor.persist.mTime.seconds = mTime.seconds;
                timeIsRunning = false;
                Time.text = "00";
                panelGameOver.SetActive(true);
                StartCoroutine("LoadEndingScene");
              
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

    private IEnumerator LoadEndingScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Help_EndingSceneForAll");
    }



}
