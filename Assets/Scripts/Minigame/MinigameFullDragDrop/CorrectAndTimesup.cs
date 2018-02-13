using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectAndTimesup : MonoBehaviour {
    public GameObject bagCompounds;

    void OnEnable()
    {
       
   
        StartCoroutine("LoadEndScene");
    }

    private IEnumerator LoadEndScene()
    {
     
        DataPersistor.persist.bagCompounds.Clear();
        yield return new WaitForSeconds(2f);
        int children = bagCompounds.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (bagCompounds.transform.GetChild(i).childCount > 0)
            {
                DataPersistor.persist.bagCompounds.Add(bagCompounds.transform.GetChild(i).GetChild(0).gameObject.name);
               
            }
        }
        int noOfCompounds = DataPersistor.persist.bagCompounds.Count;
        Debug.Log("COMPOUND PERSIST NUMBER: " + noOfCompounds);
        if (noOfCompounds > 0)
        {
            for (int i = 0; i < noOfCompounds; ++i)
            {
                Debug.Log(DataPersistor.persist.bagCompounds[i]);
              
            }
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Help_EndingSceneForAll");
    }
}
