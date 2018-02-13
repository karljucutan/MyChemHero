using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler {

    //public static GameObject itemBeingDragged;
    //Vector3 startPosition;
    //Transform startParent;

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    itemBeingDragged = gameObject;
    //    startPosition = transform.position;
    //    startParent = transform.parent;
    //    GetComponent<CanvasGroup>().blocksRaycasts = false;

        
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    transform.position = Input.mousePosition;
       
     
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    itemBeingDragged = null;
    //    //kahit wala yung if nagana
    //    if (transform.parent == startParent)
    //    {
    //        transform.position = startPosition;
    //        transform.parent = startParent;
    //    }
    //    GetComponent<CanvasGroup>().blocksRaycasts = true;


    //    if (transform.parent == startParent || transform.parent == startParent.parent.parent)
    //    {
    //        transform.position = startPosition;
    //        transform.SetParent(startParent);
    //    }
    //    GetComponent<CanvasGroup>().blocksRaycasts = true;
       
      
    //}




    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    public static Transform startParent;
    Transform canvas;
    //public static Transform previousParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //previousParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        transform.SetParent(canvas);
       // transform.SetParent
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == canvas)
        {
            
            if (startParent.CompareTag("InventorySlot"))
            {
                transform.SetParent(null);
                Destroy(gameObject);
            }
            //else if (startParent.transform.parent.CompareTag("InventoryCompoundPanel"))
            //{
            //    transform.position = startPosition;
            //    transform.SetParent(startParent);
            //}
            else 
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
            }
            
        }



    }
}
