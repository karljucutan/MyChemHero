using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timerscript : MonoBehaviour {

	// Use this for initialization
    private float time = 30;
    private Text timerOb;
	void Start () {
        timerOb = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timerOb.text = time.ToString("f0");
        if (time == 0)
        {
            timerOb.text = "Time's Up!";
        }
	}
}
