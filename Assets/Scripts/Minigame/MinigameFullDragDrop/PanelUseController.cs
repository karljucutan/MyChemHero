using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUseController : MonoBehaviour {

    public GameObject panelUse;

    public void ShowPanel()
    {
        panelUse.SetActive(true);
    }

    public void HidePanel()
    {
        panelUse.SetActive(false);
    }
}
