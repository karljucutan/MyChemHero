using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteElement : MonoBehaviour , IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
        if(DragHandler.itemBeingDragged.transform.parent.tag == "UI Canvas")//yung items dragged from mixer lang pwede idelete
        {
            DragHandler.itemBeingDragged.transform.SetParent(null);
            Destroy(DragHandler.itemBeingDragged.gameObject);

            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
        
    }
}
