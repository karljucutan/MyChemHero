using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speed = 0.5f;
    private new Renderer renderer;
    private void Start()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Team");

        renderer = GetComponent<Renderer>();
    }


    private void Update()
    {
        Vector2 offset = new Vector2(-Time.time * speed, Time.time * speed);
        renderer.material.mainTextureOffset = offset;
    }

 }