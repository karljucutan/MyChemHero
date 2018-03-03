using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour {

    public string color;

    public void setColor(string _color)
    {
        color = _color;
    }
    public void confirmChoice()
    {
        if (DataPersistor.persist != null)
        {
            DataPersistor.persist.colorStr = color;
        }
    }
}
