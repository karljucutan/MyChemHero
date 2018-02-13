using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    private FeatureManager featureManager;
	// Use this for initialization
	void Start () {
        featureManager = FindObjectOfType<FeatureManager>();
        
        transform.Find("NavigationPanel").Find("FacePreviousButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(0); featureManager.PreviousChoice(); });
        transform.Find("NavigationPanel").Find("FaceNextButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(0); featureManager.NextChoice(); });
        transform.Find("NavigationPanel").Find("HairPreviousButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(1); featureManager.PreviousChoice(); });
        transform.Find("NavigationPanel").Find("HairNextButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(1); featureManager.NextChoice(); });
        transform.Find("NavigationPanel").Find("EyesPreviousButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(2); featureManager.PreviousChoice(); ; });
        transform.Find("NavigationPanel").Find("EyesNextButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(2); featureManager.NextChoice(); });
        transform.Find("NavigationPanel").Find("NosePreviousButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(3); featureManager.PreviousChoice(); });
        transform.Find("NavigationPanel").Find("NoseNextButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(3); featureManager.NextChoice(); });
        transform.Find("NavigationPanel").Find("MouthPreviousButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(4); featureManager.PreviousChoice(); });
        transform.Find("NavigationPanel").Find("MouthNextButton").GetComponent<Button>().onClick.AddListener(() => { featureManager.SetCurrent(4); featureManager.NextChoice(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
