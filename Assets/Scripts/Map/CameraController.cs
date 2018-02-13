using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed;
    public float panBorderThickness;
    public Vector2 panLimit;
    public float scrollSpeed;
    public float minZoom;
    public float maxZoom;
    public static bool isPaused = false;
    // Update is called once per frame
    void Update () {
        CameraMovement();
        CanMove();
     
	}

    private void CameraMovement()
    {
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
        pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;
        panLimit.x += scroll * scrollSpeed * 100f * Time.deltaTime;
        panLimit.y += scroll * (scrollSpeed / 2) * 100f * Time.deltaTime;

        panLimit.x = Mathf.Clamp(panLimit.x, minZoom, maxZoom);
        panLimit.y = Mathf.Clamp(panLimit.y, minZoom / 2, maxZoom / 2);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        pos.z = Mathf.Clamp(pos.z, minZoom, maxZoom);

        transform.position = pos;
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
            panSpeed = 250;
            scrollSpeed = 100;
        }
    }

}
