using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundSetter : MonoBehaviour {

    public string compound;
	void Start () {
        DataPersistor.persist.compoundNeeded = compound;
	}
	
	
}
