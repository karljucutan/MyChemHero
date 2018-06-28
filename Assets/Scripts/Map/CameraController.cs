using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed;
    private float oldPanSpeed;
    public float panBorderThickness;
    public float scrollSpeed;
    private float oldScrollSpeed;
    public float minSize;
    public float maxSize;
    public static bool isPaused = false;

    public Camera cam;
    public GameObject bg;
    float size;
    float camVertExtent, camHorzExtent;
    float leftBound, rightBound, bottomBound, topBound;


    void Awake()
    {
        oldPanSpeed = panSpeed;
        oldScrollSpeed = scrollSpeed;
    }

    private void Start()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Map");
    }

    // Update is called once per frame
    void Update () {
        cameraBounds();
        CanMove();
	}
    
    void cameraBounds()
    {
        getExtents();
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        size -= scroll * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
        size = Mathf.Clamp(size, minSize, maxSize);

        transform.position = Vector3.Lerp(transform.position, pos, 1.0f);
        cam.orthographicSize = size;
    }

    void getExtents()
    {
        size = cam.orthographicSize;
        camVertExtent = cam.orthographicSize;
        camHorzExtent = cam.aspect * camVertExtent;

        leftBound = bg.GetComponent<Collider2D>().bounds.min.x + camHorzExtent;
        rightBound = bg.GetComponent<Collider2D>().bounds.max.x - camHorzExtent;
        bottomBound = bg.GetComponent<Collider2D>().bounds.min.y + camVertExtent;
        topBound = bg.GetComponent<Collider2D>().bounds.max.y - camVertExtent;
    }

    private void CanMove()
    {
        if(isPaused)
        {
            panSpeed = 0;
            scrollSpeed = 0;
        }
        else 
        {
            panSpeed = oldPanSpeed;
            scrollSpeed = oldScrollSpeed;
        }
    }

}
