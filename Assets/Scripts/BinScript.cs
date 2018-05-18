using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{

	// Use this for initialization
    public GameObject elem;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            

         
        }
	}
    void OnMouseDown()
    {
        Vector2 pos = new Vector2(this.transform.position.x, elem.GetComponent<ElementSpawner>().transform.position.y);
        Instantiate(elem.GetComponent<ElementSpawner>().element, pos, Quaternion.identity);
        elem.GetComponent<ElementSpawner>().queueElement();
    }
}
