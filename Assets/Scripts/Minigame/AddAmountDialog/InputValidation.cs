using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValidation : MonoBehaviour {

    public InputField amountField;


	void Start () {
        //amountField = gameObject.GetComponent<InputField>();

        amountField.onValidateInput += delegate(string input, int charIndex, char addedChar)
        {
            if (charIndex == 0 && addedChar == '0')
            {
                return '\0';
            }
            return MyValidate(addedChar); 
        };

       // amountField.onValidateInput += MyValidate;
    
        amountField.onValueChanged.AddListener(delegate {UpdateAmount(); });
	}
    private void UpdateAmount()
    {
        
        if (amountField.text != null)
        {
            //amount = int.Parse(amountField.text);
            int.TryParse(amountField.text, out AmountAddMinus.amount);
        }
        if (amountField.text == "")
        {
            AmountAddMinus.amount = 1;
        }
        //Debug.Log(AmountAddMinus.amount);
    }



    private char MyValidate(char charToValidate)
    {
        //if (charToValidate == '-')
        if (charToValidate != '1' && charToValidate != '2' && charToValidate != '3' && charToValidate != '4' && charToValidate != '5'
          && charToValidate != '6' && charToValidate != '7' && charToValidate != '8' && charToValidate != '9' && charToValidate != '0')
        {
           
            charToValidate = '\0';
        }
        return charToValidate;
    }

    
}
