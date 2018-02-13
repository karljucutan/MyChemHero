using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRend;
    void Awake()
    {
    }

    void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        if(DataPersistor.persist != null)
            spriteRend.color = DataPersistor.persist.color;
    }

}
