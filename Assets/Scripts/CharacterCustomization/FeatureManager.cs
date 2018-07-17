using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FeatureManager : MonoBehaviour {

    public List<Feature> features;
    public int currentFeature;
    public string gender;

    void OnEnable()
    {
        LoadFemaleFeatures();
        LoadMaleFeatures();
        gender = "male";
        setBody(DataPersistor.persist.teamSelecetionFactionId - 1); // INDEX OF THE TEAM FOR THE BODY
      
    }
    //void OnDisable()
    //{
    //    SaveFeatures();
    //}

    public void LoadMaleFeatures()
    {
        features = new List<Feature>();
        features.Add(new Feature("MALE SET/BODY/800px", transform.Find("Body").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("MALE SET/HAIR/800px", transform.Find("Body").transform.Find("Hair").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("MALE SET/BROWS/800px", transform.Find("Body").transform.Find("EyeBrows").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("MALE SET/EYES/800px", transform.Find("Body").transform.Find("Eyes").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("MALE SET/NOSE/800px", transform.Find("Body").transform.Find("Nose").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("MALE SET/MOUTH/800px", transform.Find("Body").transform.Find("Mouth").GetComponent<SpriteRenderer>()));

        setBody(DataPersistor.persist.teamSelecetionFactionId - 1);// INDEX OF THE TEAM FOR THE BODY
        gender = "male";
    }
    public void LoadFemaleFeatures()
    { 
        features = new List<Feature>();
        features.Add(new Feature("FEMALE SET/BODY/800px", transform.Find("Body").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("FEMALE SET/HAIR/800px", transform.Find("Body").transform.Find("Hair").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("FEMALE SET/BROWS/800px", transform.Find("Body").transform.Find("EyeBrows").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("FEMALE SET/EYES/800px", transform.Find("Body").transform.Find("Eyes").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("FEMALE SET/NOSE/800px", transform.Find("Body").transform.Find("Nose").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("FEMALE SET/MOUTH/800px", transform.Find("Body").transform.Find("Mouth").GetComponent<SpriteRenderer>()));

        setBody(DataPersistor.persist.teamSelecetionFactionId - 1);// INDEX OF THE TEAM FOR THE BODY
        gender = "female";
    }
    //void SaveFeatures()
    //{ 
        

    //}
    void setBody(int index)
    {
        CheckFeatureIfNull();
        features[0].currIndex = index;
        features[0].UpdateFeature();
    }

    public void SetCurrent(int index)
    {
        CheckFeatureIfNull();
        currentFeature = index;

    }
    public void NextChoice()
    {
        CheckFeatureIfNull();
        features[currentFeature].currIndex++;
        features[currentFeature].UpdateFeature();
    }
    public void PreviousChoice()
    {
        CheckFeatureIfNull();
        features[currentFeature].currIndex--;
        features[currentFeature].UpdateFeature();
    }
    public int PreviousChoiceTest()
    {
        
        CheckFeatureIfNull();
        features[currentFeature].currIndex--;
        var index = features[currentFeature].currIndex;
        features[currentFeature].UpdateFeature();

        if (index == 0)
            return 1;
        else if (index == -1)
            return features[currentFeature].choices.Length;
        else
            return index + 1;

    }
    public int NextChoiceTest()
    {
        
        CheckFeatureIfNull();
        features[currentFeature].currIndex++;
        var index = features[currentFeature].currIndex;
        features[currentFeature].UpdateFeature();

        if (index == features[currentFeature].choices.Length)
            return 1;
        else
            return index + 1;
    }
    private void CheckFeatureIfNull()
    {
        if (features == null)
            return;
    }
    
}


[System.Serializable]
public class Feature
{
    public string ID;
    public int currIndex;
    public Sprite[] choices;
    public SpriteRenderer renderer;

    public Feature(string ID, SpriteRenderer renderer)
    {
        this.ID = ID;
        this.renderer = renderer;
        UpdateFeature();
    }

    public void UpdateFeature() { 
    
       
        choices = Resources.LoadAll<Sprite>("CharacterandHeroAssets/" + ID);

        if (choices == null || renderer == null)
          return;

        if (currIndex < 0)
            currIndex = choices.Length - 1;
        if (currIndex >= choices.Length)
            currIndex = 0;

        renderer.sprite = choices[currIndex];

    }
}
