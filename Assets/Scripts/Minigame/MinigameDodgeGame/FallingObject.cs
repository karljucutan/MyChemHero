using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour {

   
    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 30f;
    }
    // Update is called once per frame
    private void Update ()
    {
        if (gameObject.transform.position.y <= -3)
        {
            Destroy(gameObject);  
        }
	}


}
