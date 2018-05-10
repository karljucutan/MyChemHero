using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPressedChoicesVer2 : MonoBehaviour {
    public GameObject ball1Container;
    public GameObject ball2Container;

   
    public static string currentBall;

    private void Start()
    {

        GreenColor(ball1Container); OriginalColor(ball2Container); 

    }

    // Update is called once per frame
    public void OnClick () {
       // Image img = gameObject.GetComponent<Image>();
       //Debug.Log(img.name);
       switch(gameObject.name)
        {
            case "Ball1":
                TouchManagerVer2.ballname = BallChoiceManagerVer2.ball[0];
                ChangeBallMaterial();
                currentBall = BallChoiceManagerVer2.ball[0]; GreenColor(ball1Container); OriginalColor(ball2Container); 
                break;
            case "Ball2":
                TouchManagerVer2.ballname = BallChoiceManagerVer2.ball[1];
                ChangeBallMaterial();
                currentBall = BallChoiceManagerVer2.ball[1]; GreenColor(ball2Container); OriginalColor(ball1Container); 
                break;
        }

        //Debug.Log(TouchManager.ballname);
    }
    private void ChangeBallMaterial()
    {
        Texture texture = Resources.Load("Ball/BallChoices/" + TouchManagerVer2.ballname, typeof(Texture)) as Texture;
        TouchManagerVer2.ball.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        TouchManagerVer2.ball.name = TouchManagerVer2.ballname;
    }

    private void GreenColor(GameObject ballContainer)
    {
        var b = ballContainer.GetComponent<Image>();
        b.color = new Color32(145, 255, 0, 255);
    }

    public void OriginalColor(GameObject ballContainer)
    {
        var b = ballContainer.GetComponent<Image>();
        b.color = new Color32(255, 255, 255, 255);
    }
}
