using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FeatureManager : MonoBehaviour {

    public List<Feature> features;
    public int currentFeature;

    void OnEnable()
    {
        LoadFeatures();
    }
    void OnDisable() 
    {
        SaveFeatures();
    }
    void LoadFeatures()
    { 
        features = new List<Feature>();
        features.Add(new Feature("Face", transform.Find("Face").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Hair", transform.Find("Face").transform.Find("Hair").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Eyes", transform.Find("Face").transform.Find("Eyes").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Nose", transform.Find("Face").transform.Find("Nose").GetComponent<SpriteRenderer>()));
        features.Add(new Feature("Mouth", transform.Find("Face").transform.Find("Mouth").GetComponent<SpriteRenderer>()));
    }
    void SaveFeatures()
    { 
        

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

    public void UpdateFeature() 
    {
        choices = Resources.LoadAll<Sprite>("CharacterCustomization/" + ID);

        if (choices == null || renderer == null)
          return;

        if (currIndex < 0)
            currIndex = choices.Length - 1;
        if (currIndex >= choices.Length)
            currIndex = 0;

        renderer.sprite = choices[currIndex];

    }
}
