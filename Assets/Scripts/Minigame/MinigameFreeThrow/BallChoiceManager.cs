using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;


public class BallChoiceManager : MonoBehaviour {
    //REUSED SCRIPT SA MINIGAMETAPCOMPOUND MANAGER
    public static string[] ball = new string[3];
    private System.Random _random;

    public GameObject ballChoice1;
    public GameObject ballChoice2;
    public GameObject ballChoice3;


    // Use this for initialization
    void Awake() {
        _random = new System.Random();
        for (int i = 0; i < 3; i++)
        { ball[i] = ""; }
       // DataPersistor.persist.compoundNeeded = "Salt";
        //ball[0] = DataPersistor.persist.compoundNeeded; // change to the needed compound 
 
        for (int i = 0; i < ball.Length; i++)
            Debug.Log(ball[i]);
        //for (int i = 0; i < PairOfElementCompound.listOfPairElementCompound.Count(); i++)
        //Debug.Log(PairOfElementCompound.listOfPairElementCompound[i].elementcompound.Value);

        for (int i = 1; i <= 2; i++)
        { 
        var list = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Value != ball[0] && ec.elementcompound.Value != ball[1] && ec.elementcompound.Value != ball[2]);
            ball[i] = list.Select(e => e.elementcompound.Value).ElementAtOrDefault(_random.Next(0, list.Count()));
        }
        Shuffle(ball);

        for (int i = 0; i < ball.Length; i++)
            Debug.Log(ball[i]);
        
    }

    private void Start()
    {   //assign yung balls sa button choices
        string resourcepath = "";
        if(DataPersistor.persist.sectorCity.Equals("NonMetals"))
        {
            resourcepath = "Ball/BallChoices/";
        }
        else if(DataPersistor.persist.sectorCity.Equals("Unknown"))
        {
            resourcepath = "Compounds/";
            
        }
        AssignToGameObject(resourcepath);

    
    }

    public void AssignToGameObject(string resourcepath)
    {
        ballChoice1.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[0]);
        ballChoice2.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[1]);
        ballChoice3.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[2]);
        if(DataPersistor.persist.sectorCity.Equals("Unknown"))
        {
            ballChoice1.name = ball[0];
            ballChoice2.name = ball[1];
            ballChoice3.name = ball[2];
        }
    }


    public void Shuffle<T>(T[] array) // fisher yates swap algo
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }


}
