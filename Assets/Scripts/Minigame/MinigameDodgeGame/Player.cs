using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 15f;
    private Rigidbody2D rb;
    private float mapWidth = 7;
    public GameObject gameManager;
    
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
        if (Input.GetMouseButton(0))
        {
          
            float x = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * speed;
            Vector2 newPosition = rb.position + Vector2.right * x;
            //mapWidth = (Screen.width /2 )/64;
            newPosition.x = Mathf.Clamp(newPosition.x , -mapWidth, mapWidth);
           // Debug.Log(mapWidth);
            rb.MovePosition(newPosition);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GetComponent<MinigameDodgeGameManager>().GameOver();
 
    }
}
