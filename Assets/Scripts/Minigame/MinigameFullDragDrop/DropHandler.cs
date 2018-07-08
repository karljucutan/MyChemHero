using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler {

    public GameObject panelAddMinusAmount;
   
    public GameObject item {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }



    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            if (DragHandler.startParent.tag == "InventorySlot")
            {
                if (gameObject.transform.parent == GameObject.Find("Canvas/Panel_Slot").transform && DragHandler.itemBeingDragged.CompareTag("Element"))
                {
                    panelAddMinusAmount.SetActive(true);
                }
                DestroyElementFromInventorySlot();
                //if (gameObject.transform.parent.CompareTag("InventoryCompoundPanel"))
                //{
                //    DragHandler.itemBeingDragged.transform.SetParent(null);
                //    Destroy(DragHandler.itemBeingDragged);
                //}
             
            }
            
            DragHandler.itemBeingDragged.transform.SetParent(transform);

            if (DragHandler.itemBeingDragged.CompareTag("Element") && DragHandler.startParent.parent.CompareTag("MixingPanel") && gameObject.transform.parent.CompareTag("InventoryCompoundPanel"))
            {
               
                if (gameObject.transform.childCount > 0)
                {
                    gameObject.transform.GetChild(0).transform.SetParent(DragHandler.startParent);
                }

            }
            if (DragHandler.startParent.tag != "InventorySlot")
            {
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
 
        }
        else
        {
            DestroyElementFromInventorySlot();
            
           // if (gameObject.transform.parent.CompareTag("MixingPanel"))
            if (DragHandler.startParent.CompareTag("MixerSlot") && gameObject.transform.parent.CompareTag("MixingPanel"))
            {
                Swap();
            }
            if(DragHandler.itemBeingDragged.CompareTag("Compound") && item.CompareTag("Compound"))
            {
                Swap();
            }



            //else
            //{
            //    item.transform.parent = null;
            //    Destroy(item);
            //    DragHandler.itemBeingDragged.transform.SetParent(transform);
            //}
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
       // ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
    }
    private void Swap()
    {
        Transform aux = DragHandler.startParent;
        DragHandler.itemBeingDragged.transform.SetParent(transform);
        item.transform.SetParent(aux);
    }
    private void DestroyElementFromInventorySlot()
    {
        if (gameObject.transform.parent.CompareTag("InventoryCompoundPanel") && DragHandler.startParent.CompareTag("InventorySlot"))
        {
            DragHandler.itemBeingDragged.transform.SetParent(null);
            Destroy(DragHandler.itemBeingDragged);
        }
    }
}
