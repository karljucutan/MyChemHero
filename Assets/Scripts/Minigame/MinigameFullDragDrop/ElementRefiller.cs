using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRefiller : MonoBehaviour {

    public GameObject elementPrefab;
    GameObject clone;

    void Start()
    {
        //elementPrefab = transform.GetChild(0).gameObject;
    }

    void Update ()
    {
        //if (transform.childCount == 0)
        //{
        //    clone = Instantiate(elementPrefab,transform);
        //    clone.name = elementPrefab.name;
        //}      
    }
}
