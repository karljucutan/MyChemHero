using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuilderMixElements : MonoBehaviour, IHasChanged{
    [SerializeField] Transform slots;
    [SerializeField] Text mixer;

    private string atomicnumber;
    public string combinedElements;
   // private GameObject item;
	void Start () {
        HasChanged();
	}

    public void HasChanged()
    {
        System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder();
        foreach(Transform slottransform in slots)
        {
            //if (DataPersistor.persist.GAMEMODE.Equals("MinigameFullDragDrop"))
            //{
                GameObject item = slottransform.GetComponent<DropHandlerMinigameFullDragDrop>().item;
                if (item)
                {
                    if (item.GetComponent<ElementAtomicNumber>().ATOMICNUMBER == 1)
                    { atomicnumber = ""; }
                    else
                    { atomicnumber = item.GetComponent<ElementAtomicNumber>().ATOMICNUMBER.ToString(); }
                    stringbuilder.Append(item.name + atomicnumber);//item.name + item atomicnumber
                }
            //}
            //else if (DataPersistor.persist.GAMEMODE.Equals("Minigame"))
            //{
            //    GameObject item = slottransform.GetComponent<DropHandler>().item;
            //    if (item)
            //    {
            //        stringbuilder.Append(item.name);
            //    }
            //}
          


        }
        combinedElements = stringbuilder.ToString();
        mixer.text = combinedElements;
    }
}
namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }

}
