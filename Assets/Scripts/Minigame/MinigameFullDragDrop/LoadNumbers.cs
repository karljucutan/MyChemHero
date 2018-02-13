using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNumbers : MonoBehaviour {

   public static Sprite[] choices;
	void Start () {
        choices = Resources.LoadAll<Sprite>("Numbers/number");
	}
	
	
}
