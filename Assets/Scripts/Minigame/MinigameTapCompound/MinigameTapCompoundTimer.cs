using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameTapCompoundTimer : MonoBehaviour {


    public Text Time;
    private ModelTime mTime;
    public GameObject panelStartTime;
    public GameObject panelGameOver;
    public GameObject minigameCompoundTapManager;
    public Text textStartTime;
    private string time;
    private IEnumerator coroutineSwap;
    private int swapTimePerSecond;
    private int swapTime;
   // private bool isSwap = true;
   // private bool startSwapRoutine = true;
    bool timeIsRunning = true;

    private void Start()
    {
       
        mTime = new ModelTime();
        mTime.milliseconds = 10;
        mTime.seconds = 3;
        mTime.minutes = 0;
        swapTimePerSecond = 2;
        swapTime = 8;
      //  coroutineSwap = SwapCompounds(swapTime);
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
        //StartCoroutine(coroutineSwap);
        InvokeRepeating("GameTimer", 0, 0.1f);

    }

    private void GameTimer()
    {
        if (timeIsRunning)
        {
            mTime.milliseconds--;

            time = string.Format("{0:00}", mTime.seconds);
            Time.text = time;
            if(mTime.seconds == swapTime)
            {
                //swap
                var script = minigameCompoundTapManager.GetComponent<BallChoiceManager>();
                script.Shuffle(BallChoiceManager.ball);
                script.AssignToGameObject("Compounds/");
                swapTime -= swapTimePerSecond;
                swapTimePerSecond = 1;
            }
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

    //private IEnumerator SwapCompounds(float waitTime)
    //{
    //    while (isSwap)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        //swap
    //    }
    //}



}


