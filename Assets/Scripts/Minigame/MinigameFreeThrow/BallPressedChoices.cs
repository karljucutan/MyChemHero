using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPressedChoices : MonoBehaviour {
    public GameObject ball1Container;
    public GameObject ball2Container;
    public GameObject ball3Container;
   
    public static string currentBall;

    private void Start()
    {

        GreenColor(ball1Container); OriginalColor(ball2Container); OriginalColor(ball3Container);
        TouchManager.ballname = BallChoiceManager.ball[0];
        //change yung unang ball

    }

    // Update is called once per frame
    public void OnClick () {
       // Image img = gameObject.GetComponent<Image>();
       //Debug.Log(img.name);
       switch(gameObject.name)
        {
            case "Ball1":
                TouchManager.ballname = BallChoiceManager.ball[0];
                ChangeBallMaterial();
                currentBall = BallChoiceManager.ball[0]; GreenColor(ball1Container); OriginalColor(ball2Container); OriginalColor(ball3Container);
                break;
            case "Ball2":
                TouchManager.ballname = BallChoiceManager.ball[1];
                ChangeBallMaterial();
                currentBall = BallChoiceManager.ball[1]; GreenColor(ball2Container); OriginalColor(ball1Container); OriginalColor(ball3Container);
                break;
            case "Ball3":
                TouchManager.ballname = BallChoiceManager.ball[2];
                ChangeBallMaterial();
                currentBall = BallChoiceManager.ball[2]; GreenColor(ball3Container); OriginalColor(ball1Container); OriginalColor(ball2Container);
                break;

        }

        //Debug.Log(TouchManager.ballname);
    }
    private void ChangeBallMaterial()
    {
        Texture texture = Resources.Load("Compounds/" + TouchManager.ballname, typeof(Texture)) as Texture;
        TouchManager.ball.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        TouchManager.ball.name = TouchManager.ballname;
    }

    private void GreenColor(GameObject ballContainer)
    {
        var b = ballContainer.GetComponent<Image>();
        b.color = new Color32(145, 255, 0, 255);
    }

    private void OriginalColor(GameObject ballContainer)
    {
        var b = ballContainer.GetComponent<Image>();
        b.color = new Color32(255, 255, 255, 255);
    }
}
