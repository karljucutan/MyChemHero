using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NeededCompoundsManager : MonoBehaviour {

    public List<GameObject> neededCompoundsGameObject;
    public List<string> neededCompounds;
    private bool flashing;

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
        AudioManager.instance.StopAll(); //stop music playing from previous scene

        //randomize Difficulty
        int n = Random.Range(1,3);
        Debug.Log("Random Range: " + n);
        DataPersistor.persist.difficultyMultiplier = n; //set multiplier to difficulty randomized

        //set BGM
        string nameStr = "Mixing";
        AudioManager.instance.Play(nameStr + n.ToString());

        //populate
        foreach (string compound in neededCompounds)
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
                //StartCoroutine("removeGameObject");
                StartCoroutine("startFlashing", obj);//flashing animations before removal
                StartCoroutine("removeGameObject", obj);
                break;
            }

        }
    }


    private IEnumerator removeGameObject(GameObject obj)
    {
        while (flashing)//trap in while to prevent deletion while still flashing text
            yield return new WaitForSeconds(0.1f);

        neededCompoundsGameObject.Remove(obj); //remove from GameObject List
        Destroy(obj);//remove actual GameObject in Scene
    }


    private IEnumerator startFlashing(GameObject obj)
    {
        flashing = true;

        obj.GetComponent<Text>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<Text>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<Text>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<Text>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<Text>().color = Color.green;


        flashing = false;
    }

    private string CompoundValueFinder(string compoundKey)
    {
        int difficulty = DataPersistor.persist.difficultyMultiplier;
        string compoundValue = null;

        switch(difficulty)
        {
            case 1: compoundValue = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Key == compoundKey).Select(ec => ec.elementcompound.Value).SingleOrDefault(); break;
            case 2: compoundValue = PairOfElementCompound.listOfPairElementCompoundScientific.Where(ec => ec.elementcompound.Key == compoundKey).Select(ec => ec.elementcompound.Value).SingleOrDefault(); break;
            //case 3: compoundValue = PairOfElementCompound.listOfPairElementCompoundScientific.Where(ec => ec.elementcompound.Key == compoundKey).Select(ec => ec.elementcompound.Value).SingleOrDefault(); break;
        }

        if (compoundValue != null)
        {
            return compoundValue;
        }

        return compoundValue;
    }
}
