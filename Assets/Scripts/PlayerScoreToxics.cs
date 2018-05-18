using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreToxics : MonoBehaviour {

	// Use this for initialization
    public Sprite[] brokenToxic;
    public Sprite[] brokenNonToxic;

    public Sprite[] toxicContent;
    public Sprite[] nontoxicContent;

    public GameObject toxicBroke;
    public GameObject nontoxicBroke;

    public GameObject sound;

    private Text scoreText;
    private int score = 0;

    private int toxicBrokeCount = 0;
    private int nontoxicBrokeCount = 0;

    private int toxicCorrect = 0;
    private int nontoxicCorrect = 0;

    private SpriteRenderer toxicRenderer;
    private SpriteRenderer toxicBrokeRenderer;

    private SpriteRenderer nontoxicRenderer;
    private SpriteRenderer nontoxicBrokeRenderer;
	void Start () {
        toxicBrokeRenderer = toxicBroke.GetComponent<SpriteRenderer>();
        toxicRenderer = GetComponent<SpriteRenderer>();

        nontoxicBrokeRenderer = nontoxicBroke.GetComponent<SpriteRenderer>();
        nontoxicRenderer = GetComponent<SpriteRenderer>();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    void OnTriggerEnter(Collider target)
    {
        if (this.tag == target.tag)
        {
            if (nontoxicCorrect == 10 || toxicCorrect == 10)
            {
                //dito panalo na next scene save score sa datapersistor
            }
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Toxic"))
            {
                toxicRenderer.sprite = toxicContent[toxicCorrect];
                toxicCorrect++;
            }
            if (this.tag.Equals("NonToxic"))
            {
                Debug.Log("pasok gas");
                nontoxicRenderer.sprite = nontoxicContent[nontoxicCorrect];
                nontoxicCorrect++;
            }
          
            score += 100;
            scoreText.text = score.ToString();
        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Toxic"))
            {
                if (toxicBrokeCount <= 2)
                {
                    toxicBrokeRenderer.sprite = brokenToxic[toxicBrokeCount];
                    toxicBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    toxicBrokeRenderer.sprite = brokenToxic[toxicBrokeCount];
                    toxicRenderer.gameObject.SetActive(false);
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                }


            }
            if (this.tag.Equals("NonToxic"))
            {
                if (nontoxicBrokeCount <= 2)
                {
                    nontoxicBrokeRenderer.sprite = brokenNonToxic[nontoxicBrokeCount];
                    nontoxicBrokeCount++;
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    nontoxicBrokeRenderer.sprite = brokenNonToxic[nontoxicBrokeCount];
                    nontoxicRenderer.gameObject.SetActive(false);
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
