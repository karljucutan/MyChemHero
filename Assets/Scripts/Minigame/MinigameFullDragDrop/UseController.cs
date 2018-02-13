using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseController : MonoBehaviour {
    public static GameObject compound;
   
    public void UseOnClick()
    {
        GameObject.Find("Canvas/MixButton").GetComponent<MixedElementChecker>().UseCompoundInPanelUse();
        GameObject.Find("Canvas/Panel_Bag/Panel_Compound").GetComponent<PanelUseController>().HidePanel();

        
    }


}
