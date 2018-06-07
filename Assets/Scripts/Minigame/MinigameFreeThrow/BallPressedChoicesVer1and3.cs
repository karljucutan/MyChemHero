using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPressedChoicesVer1and3 : MonoBehaviour {
    public GameObject ball1Container;
    public GameObject ball2Container;
    public GameObject ball3Container;
   
    public static string currentBall;
  
    private void Start()
    {

        GreenColor(ball1Container); OriginalColor(ball2Container); OriginalColor(ball3Container);

    }

    // Update is called once per frame
    public void OnClick () {
       // Image img = gameObject.GetComponent<Image>();
       //Debug.Log(img.name);
       switch(gameObject.name)
        {
            case "Ball1":
                TouchManagerVer1and3.ballname = BallChoiceManagerVer1and3.ball[0];
                ChangeBallMaterial();
                currentBall = BallChoiceManagerVer1and3.ball[0]; GreenColor(ball1Container);  OriginalColor(ball2Container); OriginalColor(ball3Container);
                break;
            case "Ball2":
                TouchManagerVer1and3.ballname = BallChoiceManagerVer1and3.ball[1];
                ChangeBallMaterial();
                currentBall = BallChoiceManagerVer1and3.ball[1]; GreenColor(ball2Container); OriginalColor(ball1Container); OriginalColor(ball3Container);
                break;
            case "Ball3":
                TouchManagerVer1and3.ballname = BallChoiceManagerVer1and3.ball[2];
                ChangeBallMaterial();
                currentBall = BallChoiceManagerVer1and3.ball[2]; GreenColor(ball3Container);  OriginalColor(ball1Container); OriginalColor(ball2Container);
                break;

        }

        //Debug.Log(TouchManager.ballname);
    }
    private void ChangeBallMaterial()
    {
        Texture texture = Resources.Load("Sprites/Minigame/ElementsSymbol/" + TouchManagerVer1and3.ballname, typeof(Texture)) as Texture;
        TouchManagerVer1and3.ball.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        TouchManagerVer1and3.ball.name = TouchManagerVer1and3.ballname;
    }

    public void GreenColor(GameObject ballContainer)
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
