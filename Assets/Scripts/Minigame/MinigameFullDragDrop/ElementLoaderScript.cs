using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementLoaderScript : MonoBehaviour {

    public GameObject[] elementSlots;
    public GameObject mixingElementPrefab;

    private List<string> elementsInBag;

    void Awake()
    {
        elementsInBag = DataPersistor.persist.MixingList; 
    }
    void Update()
    {   
        //element refiller for empty slots
        foreach (GameObject slot in elementSlots)
        {
            int slotIndex = Array.IndexOf(elementSlots, slot);
            if (slot.transform.childCount == 0 && slotIndex<elementsInBag.Count)
            {            
                var item = Instantiate(mixingElementPrefab, slot.transform); //instantiate GameObject as child
                item.name = elementsInBag[slotIndex]; //set child name
                item.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Minigame/ElementsSymbol/" + item.name); //set child sprite
            }
        }
    }

}
