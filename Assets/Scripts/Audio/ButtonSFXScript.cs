using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSFXScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler { 
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play("Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.Play("Hover");
    }
}
