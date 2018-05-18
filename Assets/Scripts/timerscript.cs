using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerscript : MonoBehaviour {

	// Use this for initialization
    private float time = DataPersistor.persist.segregationTimer;
    private Text timerOb;
	void Start () {
        timerOb = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timerOb.text = time.ToString("f0");
        if (time <= 0)
        {
            timerOb.text = "Time's Up!";
            SceneManager.LoadScene("Help_EndingSceneForAll");
        }
	}
}
