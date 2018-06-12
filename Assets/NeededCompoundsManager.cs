using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NeededCompoundsManager : MonoBehaviour {

    public List<GameObject> neededCompoundsGameObject;
    public List<string> neededCompounds;

    private void Awake()
    {
        neededCompounds = new List<string>();
        
        neededCompounds = DataPersistor.persist.CompoundsList;
        Shuffle(neededCompounds);//randomize here
    }

    public void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        
        while (n > 1)
        {
            int k = Random.Range(0,n) % n;
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // Use this for initialization
    void Start () {
        
        //populate
		foreach(string compound in neededCompounds)
        {
            string text = CompoundValueFinder(compound);//will only return text if string matches a key in the Dictionary
            foreach(GameObject obj in neededCompoundsGameObject)
            {
                if(string.IsNullOrEmpty(obj.GetComponent<Text>().text))
                {
                    obj.GetComponent<Text>().text = text;
                    break;
                }
            }
        }

        ////remove excess gameObjects
        //foreach (GameObject obj in neededCompoundsGameObject)
        //{
        //    if (string.IsNullOrEmpty(obj.GetComponent<Text>().text))
        //    {
        //        Destroy(obj.gameObject);
        //    }
        //}


    }
	
	public void removeCompound(string compoundName)
    {
        neededCompounds.Remove(compoundName); //remove from string list

        foreach (GameObject obj in neededCompoundsGameObject)
        {
            if (obj.GetComponent<Text>().text.Equals(CompoundValueFinder(compoundName)))
            {
                Destroy(obj.gameObject); //remove from GameObject List
                break;
            }
             
        }
        //GameObject removeObject = neededCompoundsGameObject.Find(gameObj => gameObj.GetComponent<Text>().Equals(compoundName));
        //neededCompoundsGameObject.Remove(removeObject);
    }

    private string CompoundValueFinder(string compoundKey)
    {
        string compoundValue = null;

        compoundValue = PairOfElementCompound.listOfPairElementCompoundScientific.Where(ec => ec.elementcompound.Key == compoundKey).Select(ec => ec.elementcompound.Value).SingleOrDefault();
        if (compoundValue != null)
        {
            return compoundValue;
        }

        return compoundValue;
    }
}
