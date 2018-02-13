using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagCompoundLoader : MonoBehaviour {

    public GameObject bagCompounds;
    public GameObject prefabCompound;
    // Use this for initialization
   
	void Start () {
       
        int noOfCompounds = DataPersistor.persist.bagCompounds.Count;
        Debug.Log("COMPOUND PERSIST NUMBER: " + noOfCompounds);
        if(noOfCompounds > 0)
        { 
            for (int i = 0; i < noOfCompounds; ++i)
            {
                Debug.Log(DataPersistor.persist.bagCompounds[i]);
                if (!DataPersistor.persist.bagCompounds[i].Equals(null))
                {
                    // Instantiate(DataPersistor.persist.bagCompounds[i], bagCompounds.transform.GetChild(i).transform);
                    var newCompound = Instantiate(prefabCompound, bagCompounds.transform.GetChild(i).transform);
                    newCompound.name = DataPersistor.persist.bagCompounds[i];
                    //newCompound.GetComponent<DragHandler>().enabled = false;
                    newCompound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Compounds/" + newCompound.name);
                }
            }
        }

    }

}
