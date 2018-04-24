using Assets.Scripts.Minigame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;

public class MixedElementChecker : MonoBehaviour {
   
    public GameObject compoundCreatedPanel;
    public GameObject miniGameTimer;
    public GameObject prefabCompound;
    public GameObject PanelCorrectAnswerContainer;
    private GameObject newCompound;
    public GameObject PanelBadge;
    public GameObject TextBadgeName;
    public GameObject TextBadgeDescription;
    public GameObject SlotBadge;
    private string combinedElements;
   
    
    public void Mix()
    {
        //Debug.Log(DataPersistor.persist.mTime.minutes+":"+DataPersistor.persist.mTime.seconds+":"+DataPersistor.persist.mTime.milliseconds );
        combinedElements = GameObject.Find("Canvas").GetComponent<BuilderMixElements>().combinedElements;
        string compound = CompoundFinder("useCompound");
        if (compound != null)
        {

            //animate yung MIXING

            /*AALISIN NA YUNG BADGES SA MIXING TOP 1 - 3 LANG MUNA
            //check sa userlistofbadges kung meron ng ganun
            if (!DataPersistor.persist.user.Badges.Contains(compound))
            {
                //POST NA YUNG BADGE

                StartCoroutine(PostBadge(compound)); 

                TextBadgeName.GetComponent<Text>().text = compound + " Badge";
                TextBadgeDescription.GetComponent<Text>().text = "You received a " + compound + " badge";
                YourFunction(3);
               //pag nadagdagan na badge checker muna kung anong badge nareceive tapos pag madami nareceive na badage invoke nlng magkasunod 
            }
            */

            GameObject.Find("MixButton").GetComponent<Button>().enabled = false;
            compoundCreatedPanel.SetActive(true);
            newCompound = Instantiate(prefabCompound, compoundCreatedPanel.transform.Find("Slot"));
            newCompound.name = compound;
            newCompound.GetComponent<DragHandler>().enabled = false;
            newCompound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Compounds/" + compound);

        }
        else
        {
         
            //animate sabog ng elements
        }
 
     
        DestroyItemsInPanelSlot();
        
    }
    void YourFunction(int time)
    {
        PanelBadge.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(time, PanelBadge));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
 
    private bool CompoundNeededChecker(string methodName)
    {

        //checker kung naacreate ng compound needed in the scene
        if (DataPersistor.persist.compoundNeeded == CompoundFinder(methodName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string CompoundFinder(string methodName)
    {
        string compound = null;
        if (methodName == "useCompound")
        {
             compound = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Key == combinedElements).Select(ec => ec.elementcompound.Value).SingleOrDefault();
        }
        else if (methodName == "useCompoundInPanelUse")
        {
             compound = PairOfElementCompound.listOfPairElementCompound.Where(ec => ec.elementcompound.Value == UseController.compound.name).Select(ec => ec.elementcompound.Value).SingleOrDefault();
        }

        if(compound != null)
        {
              return compound;
        }

        return compound;
    }


    public void UseCompound()
    {//use compound sa  compound created panel
       
        if (CompoundNeededChecker("useCompound"))
        {
            Debug.Log("TAMA  " + DataPersistor.persist.compoundNeeded);
            GameObject.Find("Timer").GetComponent<MiniGameTimer>().pause();
            DataPersistor.persist.totalPoints += DataPersistor.persist.accumulatedPoints;
            DataPersistor.persist.helpsMade += 1;
            PanelCorrectAnswerContainer.SetActive(true);
        }
        else
        {
            Debug.Log("MALIIIIIIII  " + DataPersistor.persist.compoundNeeded);
      
        }
        DestroyItemInCompoundCreatedPanel();
        GameObject.Find("MixButton").GetComponent<Button>().enabled = true;
    }

    public void UseCompoundInPanelUse()
    {
        if (CompoundNeededChecker("useCompoundInPanelUse"))
        {
           // Debug.Log("TAMA  " + DataPersistor.persist.compoundNeeded);
            GameObject.Find("Timer").GetComponent<MiniGameTimer>().pause();
            DataPersistor.persist.totalPoints += DataPersistor.persist.accumulatedPoints;
            DataPersistor.persist.helpsMade += 1;
            PanelCorrectAnswerContainer.SetActive(true);
        }
        else
        {
            Debug.Log("MALIIIIIIII  " + DataPersistor.persist.compoundNeeded);
       

        }
        UseController.compound.transform.SetParent(null);
        Destroy(UseController.compound);
        CreatedCompound.noOfClicks = 0;
    }

    public void ReceivedCompound()
    {
           GameObject.Find("MixButton").GetComponent<Button>().enabled = true;
           newCompound.GetComponent<DragHandler>().enabled = true;
           GameObject panelCompound = GameObject.Find("Canvas/Panel_Bag/Panel_Compound");
            for (int i = 0; i < panelCompound.transform.childCount; i++)
            {
                var child = panelCompound.transform.GetChild(i).gameObject;
                if (child.transform.childCount == 0)
                {
                   
                    compoundCreatedPanel.transform.Find("Slot").transform.GetChild(0).transform.SetParent(child.transform);
                   // Debug.Log(child.name);
                    return;

                }
            }
            DestroyItemInCompoundCreatedPanel();
       
    }

    private void DestroyItemInCompoundCreatedPanel()
    {
        if (compoundCreatedPanel.transform.Find("Slot").transform.childCount > 0)
        {
            var childObject = compoundCreatedPanel.transform.Find("Slot").transform.GetChild(0).gameObject;
            childObject.transform.SetParent(null);
            Destroy(childObject);
        }
    }


    private void DestroyItemsInPanelSlot()
    {
        GameObject panelCompound = GameObject.Find("Canvas/Panel_Slot");
        for (int i = 0; i < panelCompound.transform.childCount; i++)
        {
            var childSlot = panelCompound.transform.GetChild(i).gameObject;
            if (childSlot.transform.childCount > 0)
            {
               var childObject = childSlot.transform.GetChild(0).gameObject;
               childObject.transform.SetParent(null);
               Destroy(childObject);
            }
        }

        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
    }

    IEnumerator PostBadge(string badge)
    {
       // postbadge_running = true;
       
     
        string post_url = Configuration.BASE_ADDRESS + "updateBadges.php?playerid=" + DataPersistor.persist.user.ID + "&badge=" + badge;
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
      //  postbadge_running = false;
    }


}
