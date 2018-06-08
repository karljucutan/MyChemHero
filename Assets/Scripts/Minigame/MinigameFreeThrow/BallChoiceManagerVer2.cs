using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;


public class BallChoiceManagerVer2 : MonoBehaviour {
   
    public static string[] ball = new string[2];
    private System.Random _random;

    public GameObject BallPressedChoicesVer2;

    public GameObject ballChoice1;
    public GameObject ballChoice2;
  
    public Text ElementText;

    public GameObject TimerObject;
    public static string randomElement;
    //public static Queue<string> Elements;
    private int seconds;
    // Use this for initialization
    void Awake() {
        _random = new System.Random();

        BallAssignment();
        // sa una irandom yung list of elements
        // get first index
        ShuffleList(DataPersistor.persist.ElementsListForToxicNonToxic);
        //Elements = new Queue<string>(DataPersistor.persist.ElementsList);
        //ElementText.text = Elements.Peek();
        randomElement = DataPersistor.persist.ElementsListForToxicNonToxic[RandomNumber()];
        ElementText.text = DataPersistor.persist.elementNameDictionary.Where(e => e.Key.Equals(randomElement)).Select(e => e.Value).SingleOrDefault();
        AssignToGameObject("Ball/BallChoices/");
        seconds = DataPersistor.persist.mTime.seconds;

    }

    // every n seconds change na ng compound (DEQUEUE) tapos change narin yung ball choices
    private void Update()
    {
        
        if (TimerObject.GetComponent<MinigameFreeThrowTimer>().GameTimerStarts)
        { 
            if (TimerObject.GetComponent<MinigameFreeThrowTimer>().mTime.seconds <= seconds - DataPersistor.persist.Timechange)
            {
                //if (Elements.Count > 0)
                //{
                //    Elements.Dequeue();
                //    if (Elements.Count > 0)
                //    {
                        //SOUND EFFECT FOR CHANGES
                        randomElement = DataPersistor.persist.ElementsListForToxicNonToxic[RandomNumber()];
                        ElementText.text = DataPersistor.persist.elementNameDictionary.Where(e => e.Key.Equals(randomElement)).Select(e => e.Value).SingleOrDefault(); 

                        //BallAssignment();
                        //AssignToGameObject("Ball/BallChoices/");
                        //var BPCscript = BallPressedChoicesVer2.GetComponent<BallPressedChoicesVer2>();
                        //BPCscript.OriginalColor(BPCscript.ball1Container);
                        //BPCscript.OriginalColor(BPCscript.ball2Container);
                        
                    //}
                    seconds -= DataPersistor.persist.Timechange;
                //}
            }
        }
    }

    private int RandomNumber()
    {
        var length = DataPersistor.persist.ElementsListForToxicNonToxic.Count;
        return UnityEngine.Random.Range(0, length);
    }

    private void BallAssignment()
    {
        ball[0] = "toxic";
        ball[1] = "nontoxic";
    }

    public void AssignToGameObject(string resourcepath)
    {
        ballChoice1.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[0]);
        ballChoice2.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[1]);
    }

    public void ShuffleList<T>(IList<T> list) // fisher yates swap algo
    {
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + _random.Next(n - i);
            T t = list[r];
            list[r] = list[i];
            list[i] = t;
        }
    }

}
