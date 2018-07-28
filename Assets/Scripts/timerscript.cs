using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerscript : MonoBehaviour {

	// Use this for initialization
    private float time = DataPersistor.persist.segregationTimer;
    private Text timerOb;
    private int milli = 10;
    public bool timeIsRunning = true;
    public bool GameTimerStarts = false;
	void Start () {
        timerOb = GetComponent<Text>();
        InvokeRepeating("StartTimer", 0, 0.1f);
	}
    public void StopTime()
    {
        CancelInvoke("StartTimer");
    }
    private void StartTimer()
    {
        milli--;
        //every second SOUND EFFECTS
        timerOb.text = time.ToString("f0");
        if (time <= 0 && milli <= 10)
        {
            GameTimerStart();
            CancelInvoke("StartTimer");

        }
        if (milli <= 0)
        {
            milli = 10;
            time -= 1;
        }
    }

    private void GameTimerStart()
    {
       
        InvokeRepeating("GameTimer", 0, 0.1f);
        GameTimerStarts = true;

    }

    private void GameTimer()
    {
        if (timeIsRunning)
        {
           milli--;

            timerOb.text = time.ToString("f0");
            if (time <= 0 && milli <= 0)
            {
                
                timeIsRunning = false;
                timerOb.text = "Times Up!";
                StartCoroutine("loadEnding");

            }

            if (milli <= 0)
            {
                milli = 10;
                time -= 1;
            }

        }

    }

    private IEnumerator loadEnding()
    {
        yield return new WaitForSeconds(1);

        LevelManager.lvlmgr.LoadLevel("Help_EndingSceneForAll");
       
    }
}
