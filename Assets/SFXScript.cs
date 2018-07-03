using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFXScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {


    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play("Click");
        Debug.Log("Click To");
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        AudioManager.instance.Play("Hover");
        Debug.Log("Hover To");
        //throw new System.NotImplementedException();
    }
}
