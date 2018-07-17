using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;
using Assets.Scripts;

public class BallChoiceManagerVer1and3 : MonoBehaviour {
    //REUSED SCRIPT SA MINIGAMETAPCOMPOUND MANAGER
    public static string[] ball = new string[3];
    private System.Random _random;

    public GameObject BallPressedChoicesVer1and3;

    public GameObject ballChoice1;
    public GameObject ballChoice2;
    public GameObject ballChoice3;
    public Text CompoundText;

    public GameObject TimerObject;
    public  static string randomItem;
    //public static Queue<string> Compounds;
    private int seconds;
    // Use this for initialization
    void Awake() {
        _random = new System.Random();
        for (int i = 0; i < 3; i++)
        { ball[i] = ""; }


        ShuffleList(DataPersistor.persist.CompoundsList);
        //Compounds = new Queue<string>(DataPersistor.persist.CompoundsList);
        
        BallAssignment();
        //CompoundText.text = Compounds.Peek();

        AssignToGameObject("Sprites/Minigame/ElementsSymbol/");
        seconds = DataPersistor.persist.mTime.seconds;
    }

    // every n seconds change na ng compound (DEQUEUE) tapos change narin yung ball choices
    private void Update()
    {
        
        if (TimerObject.GetComponent<MinigameFreeThrowTimer>().GameTimerStarts)
        { 
            if (TimerObject.GetComponent<MinigameFreeThrowTimer>().mTime.seconds <= seconds - DataPersistor.persist.Timechange)
            {
                //if (Compounds.Count > 0)
                //{
                //   Compounds.Dequeue();
                //    if (Compounds.Count > 0)
                //    {

                        //SOUND EFFECT FOR CHANGES
                        BallAssignment();
                        AssignToGameObject("Sprites/Minigame/ElementsSymbol/");
                        var BPCscript = BallPressedChoicesVer1and3.GetComponent<BallPressedChoicesVer1and3>();
                        BPCscript.OriginalColor(BPCscript.ball1Container);
                        BPCscript.OriginalColor(BPCscript.ball2Container);
                        BPCscript.OriginalColor(BPCscript.ball3Container);
                        
                    //}
                    seconds -= DataPersistor.persist.Timechange;
                //}
            }
        }
    }

    private int RandomCompound()
    {
        var length = DataPersistor.persist.CompoundsList.Count;
        return UnityEngine.Random.Range(0, length);
    }

    private void BallAssignment()
    {
        //var FirstItem = Compounds.Peek();
        randomItem = DataPersistor.persist.CompoundsList[RandomCompound()];
        //var elementsInCompounds = DataPersistor.persist.ElementsList.Where(e => FirstItem.Contains(e)).ToList();
        //var elementsInCompounds = DataPersistor.persist.MixingList.Where(e => randomItem.Contains(e)).ToList();
        var elementsInCompound = ListOfCompounds.Compounds.Where(c => c.Name.Equals(randomItem)).Select(c => c.Composition).SingleOrDefault();
        ShuffleList(elementsInCompound);
        ball[0] = elementsInCompound[0];

        var listofelements = DataPersistor.persist.MixingList.Where(e => !e.Equals(ball[0])).ToList();
        ShuffleList(listofelements);
        ball[1] = listofelements[0];
        ball[2] = listofelements[1];

        ShuffleArray(ball);

        CompoundText.text = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Key == randomItem).Select(ec => ec.elementcompound.Value).SingleOrDefault();

    }

    public void AssignToGameObject(string resourcepath)
    {
        ballChoice1.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[0]);
        ballChoice2.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[1]);
        ballChoice3.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(resourcepath + ball[2]);

    }


    public void ShuffleArray<T>(T[] array) // fisher yates swap algo
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
