using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour {

	public void CheckState () {
       

        if (DataPersistor.persist.state.Equals("returning"))
        {
            Debug.Log("RETURNING ME");
            SceneManager.LoadScene("Map");
        }
        else
        {
            Debug.Log("DI AKO RETURNING");
            SceneManager.LoadScene("Team Selection");
        }
	}
	
	
}
