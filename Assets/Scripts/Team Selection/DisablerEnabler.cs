using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablerEnabler : MonoBehaviour {

    // Use this for initialization
    void Start () {        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btnDisabler(Button clickedbtn)
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach(Button btn in buttons)
        {
            if (btn != clickedbtn)
                btn.interactable = false;
        }
    }

    public void btnEnabler()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            btn.interactable = true;
        }
    }
}
