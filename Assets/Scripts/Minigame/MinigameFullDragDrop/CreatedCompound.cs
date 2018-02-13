using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreatedCompound : MonoBehaviour {

    public static int noOfClicks = 0;
    
     public void OnClick()
    {
           
         gameObject.GetComponent<DragHandler>().enabled = true;
         if (gameObject.transform.parent.parent.CompareTag("InventoryCompoundPanel"))
         {
             
             if (noOfClicks == 0)
             {
                 UseController.compound = gameObject;

                 GameObject.Find("Canvas/Panel_Bag/Panel_Compound").GetComponent<PanelUseController>().ShowPanel();
                 noOfClicks += 1;
                 //GameObject.Find("Canvas/PanelUseContainer").transform.position = new Vector3(transform.position.x - 32, transform.position.y + 26.5f, 0);
                 GameObject.Find("Canvas/PanelUseContainer").transform.position = transform.position;
             }
             else
             {
                 GameObject.Find("Canvas/Panel_Bag/Panel_Compound").GetComponent<PanelUseController>().HidePanel();
                 noOfClicks = 0;
             }
         }
       
        
     }

   
}
