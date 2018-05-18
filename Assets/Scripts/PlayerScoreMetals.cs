using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreMetals : MonoBehaviour {

	// Use this for initialization
    public Sprite[] brokenMetal;
    public Sprite[] brokenMetalloid;
    public Sprite[] brokenNonMetal;

    public Sprite[] metalContent;
    public Sprite[] metalloidContent;
    public Sprite[] nonmetalContent;

    public GameObject metalBroke;
    public GameObject metalloidBroke;
    public GameObject nonmetalBroke;

    public GameObject sound;

    private Text scoreText;
    private int score = 0;

    private int metalBrokeCount = 0;
    private int metalloidBrokeCount = 0;
    private int nonmetalBrokeCount = 0;

    private int metalCorrect = 0;
    private int metalloidCorrect = 0;
    private int nonmetalCorrect = 0;

    private SpriteRenderer metalRenderer;
    private SpriteRenderer metalBrokeRenderer;

    private SpriteRenderer metalloidRenderer;
    private SpriteRenderer metalloidBrokeRenderer;

    private SpriteRenderer nonmetalRenderer;
    private SpriteRenderer nonmetalBrokeRenderer;
	void Start () {
        metalBrokeRenderer = metalBroke.GetComponent<SpriteRenderer>();
        metalRenderer = GetComponent<SpriteRenderer>();

        metalloidBrokeRenderer = metalloidBroke.GetComponent<SpriteRenderer>();
        metalloidRenderer = GetComponent<SpriteRenderer>();

        nonmetalBrokeRenderer = nonmetalBroke.GetComponent<SpriteRenderer>();
        nonmetalRenderer = GetComponent<SpriteRenderer>();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
	}
    void OnTriggerEnter(Collider target)
    {
        if (this.tag == target.tag)
        {
            // check kung 10 na, 10 assets lng kasi meron kapag tama 
            if (nonmetalCorrect == 10 || metalloidCorrect == 10 || metalCorrect == 10)
            {
                //dito panalo na next scene save score sa datapersistor
            }

            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Metal"))
            {
                metalRenderer.sprite = metalContent[metalCorrect];
                metalCorrect++;
            }
            if (this.tag.Equals("Metalloid"))
            {
                metalloidRenderer.sprite = metalloidContent[metalloidCorrect];
                metalloidCorrect++;
            }
            if (this.tag.Equals("NonMetal"))
            {
                Debug.Log("pasok gas");
                nonmetalRenderer.sprite = nonmetalContent[nonmetalCorrect];
                nonmetalCorrect++;
            }

          
            score += 100;
            scoreText.text = score.ToString();
        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Metal"))
            {
                if (metalBrokeCount <= 2)
                {
                    metalBrokeRenderer.sprite = brokenMetal[metalBrokeCount];
                    metalBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");//play sound crack pag mali
                }
                else
                {
                    metalBrokeRenderer.sprite = brokenMetal[metalBrokeCount];
                    metalRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");//play break sound pag naka tatlong mali na
                }


            }
            if (this.tag.Equals("Metalloid"))
            {
                if (metalloidBrokeCount <= 2)
                {
                    metalloidBrokeRenderer.sprite = brokenMetalloid[metalloidBrokeCount];
                    metalloidBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    metalloidBrokeRenderer.sprite = brokenMetalloid[metalloidBrokeCount];
                    metalloidRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");

                }

            }
            if (this.tag.Equals("NonMetal"))
            {
                if (nonmetalBrokeCount <= 2)
                {
                    nonmetalBrokeRenderer.sprite = brokenNonMetal[nonmetalBrokeCount];
                    nonmetalBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    nonmetalBrokeRenderer.sprite = brokenNonMetal[nonmetalBrokeCount];
                    nonmetalRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                }

            }

            //Debug.Log("Mali");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
