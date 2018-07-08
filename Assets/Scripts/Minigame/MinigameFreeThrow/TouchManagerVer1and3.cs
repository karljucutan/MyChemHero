using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManagerVer1and3 : MonoBehaviour {

    private float initialTouchTime;
    private float finalTouchTime;
    private Vector2 initialTouchPosition;
    private Vector2 finalTouchPosition;
    private float xAxisForce;
    private float yAxisForce;
    private float zAxisForce;
    private Vector3 requiredForce;
    public static Rigidbody ball;
    public GameObject ballPrefab;
    public GameObject touchManager;

    GameObject clone;
    private bool leftClick;

    //ball
    public static string ballname;

    //private void Awake()
    //{
    //    ballname = BallChoiceManagerVer1and3.ball[0];
    //    StartCoroutine(CreateBall());
    //}
    private void Start()
    {
        ballname = BallChoiceManagerVer1and3.ball[0];
        StartCoroutine(CreateBall());

    }

    private void Update()
    {
        touchManager.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
           
    }

    public void OnTouchDown()
    {
        if (Input.GetMouseButton(0))
        {
            leftClick = true;
            initialTouchTime = Time.time;
            initialTouchPosition = Input.mousePosition;
        }
    }

    public void OnTouchUp()
    {
        if (leftClick)
        {
            finalTouchTime = Time.time;
            finalTouchPosition = Input.mousePosition;
            BallThrow();


            StartCoroutine(CreateBall());
            leftClick = false;
        }
   
    }

    private void BallThrow()
    {
        xAxisForce = finalTouchPosition.x - initialTouchPosition.x;
        yAxisForce = finalTouchPosition.y - initialTouchPosition.y;
        zAxisForce = finalTouchTime - initialTouchTime;
        requiredForce = new Vector3(xAxisForce/50f, yAxisForce/50f, zAxisForce * 15);
        ball.useGravity = true;
        ball.velocity = requiredForce;

        AudioManager.instance.Play("Shoot" + Random.Range(1, 3).ToString());

        //ball.GetComponent<Rigidbody>().AddForce(requiredForce, ForceMode.Impulse);
    }

    private IEnumerator CreateBall()
    {
        yield return new WaitForSeconds(0.1f);
        clone = Instantiate(ballPrefab);
        clone.GetComponent<Rigidbody>().useGravity = false;
        ball = clone.GetComponent<Rigidbody>();
        ball.name = ballname;
        Texture texture = Resources.Load("Sprites/Minigame/ElementsSymbol/" + ballname, typeof(Texture)) as Texture;
        ball.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);

    }

}


