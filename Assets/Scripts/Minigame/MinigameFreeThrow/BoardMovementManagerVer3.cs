using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovementManagerVer3 : MonoBehaviour {

    public GameObject MinigameFreeThrowTimer;
    public Transform Board;
    Vector3 pointA, pointB;
    private float speed = 0.2f;

    void Start()
    {
        pointA = new Vector3(Board.position.x - 1.5f, Board.position.y, Board.position.z);
        pointB = new Vector3(Board.position.x + 1.5f, Board.position.y, Board.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //PingPong between 0 and 1

        if (MinigameFreeThrowTimer.GetComponent<MinigameFreeThrowTimer>().GameTimerStarts)
        {
            float time = Mathf.PingPong(Time.time * speed, 1);
            Board.position = Vector3.Lerp(pointA, pointB, time);
           
        }
      

    }
}
