using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmAmount : MonoBehaviour {

   // public static GameObject element;
    private GameObject element;
    public GameObject panelAddMinusAmount;
    public InputField amountField;
    private Sprite tenths;
    private GameObject ones;
    private string amount;
    private char digit1st;
    private char digit2nd;
   // private Sprite[] choices;

    public void Start()
    {
     //   choices = Resources.LoadAll<Sprite>("Numbers/number");
      
    }
    public void OnEnable()
    {
        GameObject.Find("MixButton").GetComponent<Button>().enabled = false;
        element = DragHandler.itemBeingDragged;
        AmountAddMinus.amount = 1;
        amountField.text = "";
    }

	public void ConfirmClicked () 
    {
        amount = AmountAddMinus.amount.ToString();
        if (AmountAddMinus.amount <= 9 && AmountAddMinus.amount > 1)
        {
            
            digit1st = amount[0];
            int firstVal = (int)System.Char.GetNumericValue(digit1st);
           // Debug.Log(LoadNumbers.choices[firstVal]);
            element.transform.GetChild(1).GetComponent<Image>().color = new Color(225, 255, 255, 255);
            element.transform.GetChild(1).GetComponent<Image>().sprite = LoadNumbers.choices[firstVal];
            element.name += AmountAddMinus.amount.ToString();
        }
        else if (AmountAddMinus.amount >= 10)
        {
            digit1st = amount[0];
            digit2nd = amount[1];
            int firstVal = (int)System.Char.GetNumericValue(digit1st);
            int secondVal = (int)System.Char.GetNumericValue(digit2nd);
            element.transform.GetChild(0).GetComponent<Image>().color = new Color(225,255,255,255);
            element.transform.GetChild(1).GetComponent<Image>().color = new Color(225, 255, 255, 255);
            element.transform.GetChild(0).GetComponent<Image>().overrideSprite = LoadNumbers.choices[firstVal];
            element.transform.GetChild(1).GetComponent<Image>().overrideSprite = LoadNumbers.choices[secondVal];
            element.name += AmountAddMinus.amount.ToString();
            //     element.transform.GetChild(1).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Textures/sprite");
            // ganto kapag paisaisa hindi yung naka sprite multiple na inedit lng at tinrim sa unity sprite editor
        }
       
        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        GameObject.Find("MixButton").GetComponent<Button>().enabled = true;
        panelAddMinusAmount.SetActive(false);
	}

    public void CancelClickked()
    {
        panelAddMinusAmount.SetActive(false);
        element.transform.SetParent(null);
        Destroy(element);
        GameObject.Find("MixButton").GetComponent<Button>().enabled = true;
    }
  
    //setactive panel false

    //pag kabuttonclick confirm
    //if amount == 1
    // walang gagawin
   

   // ETO KAPAG MAAGKAKAHIWALAY ELEMENTS OBJECT NA e.g H, H2, H3
    //if amounut >=2
    //{
    // yung object name + amount tostring
    //     delee current obj sa slot child
    //    tapos create new object na same nunng ammount sa slot child
    //}



    // ETO KAPAG ISANG ELEMENTS OBJECT LANG O = Oxygen tapos papatungan nalang ng image na number 1,,2,34 etc. thru the child of the obj/element   
    //if amounut >=2  
    //{
    // yung object name + amount tostring
    //}
    //

}
