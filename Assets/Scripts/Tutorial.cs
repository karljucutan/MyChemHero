using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
    public Sprite[] tutorialImages;
    public Image tutorial;
    public int count = 0;

    public void click()
    {
        tutorial = GameObject.Find("tut_img").GetComponent<Image>();
        tutorial.sprite = tutorialImages[count];
        count++;
        if (count == 7)
        {
            //here we go to the main game
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
