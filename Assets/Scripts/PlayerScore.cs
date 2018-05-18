using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	// Use this for initialization
    public Sprite[] brokenSolid;
    public Sprite[] brokenLiquid;
    public Sprite[] brokenGas;

    public Sprite[] solidContent;
    public Sprite[] liquidContent;
    public Sprite[] gasContent;

    public GameObject solidBroke;
    public GameObject liquidBroke;
    public GameObject gasBroke;

    public GameObject sound;

    private Text scoreText;
    private int score = 0;

    private int solidBrokeCount = 0;
    private int liquidBrokeCount = 0;
    private int gasBrokeCount = 0;

    private int solidCorrect = 0;
    private int liquidCorrect = 0;
    private int gasCorrect = 0;

    private SpriteRenderer solidRenderer;
    private SpriteRenderer solidBrokeRenderer;

    private SpriteRenderer liquidRenderer;
    private SpriteRenderer liquidBrokeRenderer;

    private SpriteRenderer gasRenderer;
    private SpriteRenderer gasBrokeRenderer;


    void Awake()
    {
        solidBrokeRenderer = solidBroke.GetComponent<SpriteRenderer>();
        solidRenderer = GetComponent<SpriteRenderer>();

        liquidBrokeRenderer = liquidBroke.GetComponent<SpriteRenderer>();
        liquidRenderer = GetComponent<SpriteRenderer>();

        gasBrokeRenderer = gasBroke.GetComponent<SpriteRenderer>();
        gasRenderer = GetComponent<SpriteRenderer>();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter(Collider target)
    {
        //if pag tama dito
        if (this.tag == target.tag)
        {
            if (solidCorrect == 10 || liquidCorrect == 10 || gasCorrect == 10)
            {
                //dito panalo na next scene save score sa datapersistor
                Debug.Log("panalo");
            }
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Solid"))
            {
                solidRenderer.sprite = solidContent[solidCorrect];
                solidCorrect++;
            }
            if (this.tag.Equals("Liquid"))
            {
                liquidRenderer.sprite = liquidContent[liquidCorrect];
                liquidCorrect++;
            }
            if (this.tag.Equals("Gas"))
            {
                Debug.Log("pasok gas");
                gasRenderer.sprite = gasContent[gasCorrect];
                gasCorrect++;
            }

            
            score += 100;
            scoreText.text = score.ToString();
        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            //target.gameObject.SetActive(false);
            if (this.tag.Equals("Solid"))
            {
                if (solidBrokeCount <=2)
                {
                    solidBrokeRenderer.sprite = brokenSolid[solidBrokeCount];
                    solidBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    solidBrokeRenderer.sprite = brokenSolid[solidBrokeCount];
                    solidRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                }
                

            }
            if (this.tag.Equals("Liquid"))
            {
                if (liquidBrokeCount <= 2)
                {
                    liquidBrokeRenderer.sprite = brokenLiquid[liquidBrokeCount];
                    liquidBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    liquidBrokeRenderer.sprite = brokenLiquid[liquidBrokeCount];
                    liquidRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                    
                }
                
            }
            if (this.tag.Equals("Gas"))
            {
                if (gasBrokeCount <= 2)
                {
                    gasBrokeRenderer.sprite = brokenGas[gasBrokeCount];
                    gasBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    gasBrokeRenderer.sprite = brokenGas[gasBrokeCount];
                    gasRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                }
                
            }
            
            //Debug.Log("Mali");
        }
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
