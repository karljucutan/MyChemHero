using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System;
using System.Linq;


public class backdisabler : MonoBehaviour {

    public GameObject backbutton;

	void Start () {
        if (DataPersistor.persist.teamCreator)
        {
            backbutton.SetActive(false);
        }

    }
	
	
}
