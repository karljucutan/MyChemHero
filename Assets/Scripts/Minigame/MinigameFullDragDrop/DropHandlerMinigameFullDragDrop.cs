using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandlerMinigameFullDragDrop : MonoBehaviour, IDropHandler
{
    private string amount;
    private char digit1st;
    private char digit2nd;
    //public GameObject panelAddMinusAmount;
   
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
        //if not gameobject
        if (!item)
        {
            //if (DragHandler.startParent.tag == "InventorySlot")
            //{
                
            //    DestroyElementFromInventorySlot();
                     
            //}
            
            DragHandler.itemBeingDragged.transform.SetParent(transform);

            //if (DragHandler.itemBeingDragged.CompareTag("Element") && DragHandler.startParent.parent.CompareTag("MixingPanel") && gameObject.transform.parent.CompareTag("InventoryCompoundPanel"))
            //{
               
            //    if (gameObject.transform.childCount > 0)
            //    {
            //        gameObject.transform.GetChild(0).transform.SetParent(DragHandler.startParent);
            //    }

            //}w
            if (DragHandler.itemBeingDragged.CompareTag("Compound") && gameObject.transform.CompareTag("MixerSlot"))
            {
                DragHandler.itemBeingDragged.transform.SetParent(DragHandler.startParent);
            }
            if (DragHandler.startParent.tag != "InventorySlot")
            {
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
 
        }
            //ifgameobject dito rin sa else ang checking kung same sila nung object tapos increment
        else
        {
            //DestroyElementFromInventorySlot();
            
           // if (gameObject.transform.parent.CompareTag("MixingPanel"))
            if (DragHandler.startParent.CompareTag("MixerSlot") && gameObject.transform.parent.CompareTag("MixingPanel"))
            {
                //checker kung same gameobject tapos increment
                //else
                if (!CheckerSameElement())
                {
                    Swap();
                }
                
                    

            }
            if(DragHandler.startParent.CompareTag("InventorySlot") && gameObject.transform.parent.CompareTag("MixingPanel"))
            {
                CheckerSameElement();
            }
            if(DragHandler.itemBeingDragged.CompareTag("Compound") && item.CompareTag("Compound"))
            {
                Swap();
            }

        }
        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
    }
    private bool CheckerSameElement()
    {
        if (DragHandler.itemBeingDragged.gameObject.name == item.name)
        {
            DragHandler.itemBeingDragged.GetComponent<ElementAtomicNumber>().ATOMICNUMBER += item.GetComponent<ElementAtomicNumber>().ATOMICNUMBER;
          //ADD IMAGE NUMBER
            amount = DragHandler.itemBeingDragged.GetComponent<ElementAtomicNumber>().ATOMICNUMBER.ToString();
            if (DragHandler.itemBeingDragged.GetComponent<ElementAtomicNumber>().ATOMICNUMBER <= 9 && DragHandler.itemBeingDragged.GetComponent<ElementAtomicNumber>().ATOMICNUMBER > 1)
            {

                digit1st = amount[0];
                int firstVal = (int)System.Char.GetNumericValue(digit1st);
                // Debug.Log(LoadNumbers.choices[firstVal]);
                DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<Image>().color = new Color(225, 255, 255, 255);
                DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<Image>().sprite = LoadNumbers.choices[firstVal];
                
            }
            else if (DragHandler.itemBeingDragged.GetComponent<ElementAtomicNumber>().ATOMICNUMBER >= 10)
            {
                digit1st = amount[0];
                digit2nd = amount[1];
                int firstVal = (int)System.Char.GetNumericValue(digit1st);
                int secondVal = (int)System.Char.GetNumericValue(digit2nd);
                DragHandler.itemBeingDragged.transform.GetChild(0).GetComponent<Image>().color = new Color(225, 255, 255, 255);
                DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<Image>().color = new Color(225, 255, 255, 255);
                DragHandler.itemBeingDragged.transform.GetChild(0).GetComponent<Image>().overrideSprite = LoadNumbers.choices[firstVal];
                DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<Image>().overrideSprite = LoadNumbers.choices[secondVal];
             
            }

            item.transform.SetParent(null);
            Destroy(item);
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            return true;
        }
        
        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        return false;
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
