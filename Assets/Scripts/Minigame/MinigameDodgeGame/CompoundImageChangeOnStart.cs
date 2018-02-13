using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundImageChangeOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Compounds/" + DataPersistor.persist.compoundNeeded);
	}

}
