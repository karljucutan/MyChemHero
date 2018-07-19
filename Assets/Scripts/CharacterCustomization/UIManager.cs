using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    private FeatureManager featureManager;
	// Use this for initialization
	void Start () {
        featureManager = FindObjectOfType<FeatureManager>();
        
        transform.Find("NavigationPanel").Find("FacePreviousButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(1);
            transform.Find("NavigationPanel").Find("HairNum").GetComponent<Text>().text = featureManager.PreviousChoiceTest().ToString() + "/20";
        });
        transform.Find("NavigationPanel").Find("FaceNextButton").GetComponent<Button>().onClick.AddListener(() => { 
            featureManager.SetCurrent(1); 
            transform.Find("NavigationPanel").Find("HairNum").GetComponent<Text>().text = featureManager.NextChoiceTest().ToString() + "/20"; 
        });
        transform.Find("NavigationPanel").Find("HairPreviousButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(2);
            transform.Find("NavigationPanel").Find("BrowNum").GetComponent<Text>().text = featureManager.PreviousChoiceTest().ToString() + "/20";
        });
        transform.Find("NavigationPanel").Find("HairNextButton").GetComponent<Button>().onClick.AddListener(() => { 
            featureManager.SetCurrent(2);
            transform.Find("NavigationPanel").Find("BrowNum").GetComponent<Text>().text = featureManager.NextChoiceTest().ToString() + "/20"; 
        });
        transform.Find("NavigationPanel").Find("EyesPreviousButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(3);
            transform.Find("NavigationPanel").Find("EyeNum").GetComponent<Text>().text = featureManager.PreviousChoiceTest().ToString() + "/25";
        });
        transform.Find("NavigationPanel").Find("EyesNextButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(3);
            transform.Find("NavigationPanel").Find("EyeNum").GetComponent<Text>().text = featureManager.NextChoiceTest().ToString() + "/25";
        });
        transform.Find("NavigationPanel").Find("NosePreviousButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(4);
            transform.Find("NavigationPanel").Find("NoseNum").GetComponent<Text>().text = featureManager.PreviousChoiceTest().ToString() + "/5";
        });
        transform.Find("NavigationPanel").Find("NoseNextButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(4);
            transform.Find("NavigationPanel").Find("NoseNum").GetComponent<Text>().text = featureManager.NextChoiceTest().ToString() + "/5"; 
        });
        transform.Find("NavigationPanel").Find("MouthPreviousButton").GetComponent<Button>().onClick.AddListener(() => { 
            featureManager.SetCurrent(5);
            transform.Find("NavigationPanel").Find("MouthNum").GetComponent<Text>().text = featureManager.PreviousChoiceTest().ToString() + "/5";
        });
        transform.Find("NavigationPanel").Find("MouthNextButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.SetCurrent(5);
            transform.Find("NavigationPanel").Find("MouthNum").GetComponent<Text>().text = featureManager.NextChoiceTest().ToString() + "/5";
        });

        transform.Find("NavigationPanel").Find("MaleButton").GetComponent<Image>().color = new Color32(245, 133, 23, 255);

        transform.Find("NavigationPanel").Find("MaleButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.LoadMaleFeatures();
            transform.Find("NavigationPanel").Find("FemaleButton").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            transform.Find("NavigationPanel").Find("MaleButton").GetComponent<Image>().color = new Color32(245, 133, 23, 255);
        });
        transform.Find("NavigationPanel").Find("FemaleButton").GetComponent<Button>().onClick.AddListener(() => {
            featureManager.LoadFemaleFeatures();
            transform.Find("NavigationPanel").Find("MaleButton").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            transform.Find("NavigationPanel").Find("FemaleButton").GetComponent<Image>().color = new Color32(245, 133, 23, 255);
        });
	}
	

}
