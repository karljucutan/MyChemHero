using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour {

    private int randomNumber;
    private int repeat;
    void Start()
    {
        randomNumber = 0;
    }

    public void loadrandomScene()
    {
        randomNumber = Random.Range(2,12);
        SceneManager.LoadScene(randomNumber);
    }

 
}
