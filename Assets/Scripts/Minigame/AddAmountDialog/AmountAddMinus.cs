using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountAddMinus : MonoBehaviour {

    public static int amount = 1;
    public InputField amountField;
    

    public void IncreaseAmount()
    {
        amount += 1;
        amountField.text = amount.ToString();
      //  Debug.Log(amount);
    }
    public void DecreaseAmount()
    {
        amount -= 1;
        amountField.text = amount.ToString();
      //  Debug.Log(amount);
    }
	
}
