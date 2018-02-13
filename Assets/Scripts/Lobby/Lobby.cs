using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour {

	
	public void CheckState () {
       
        if (DataPersistor.persist.state.Equals("returning"))
        {
            SceneManager.LoadScene("Map");
        }
        else
        {
            SceneManager.LoadScene("Team Selection");
        }
	}
	
	
}
