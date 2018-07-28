using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject gameOverPanel;
    public GameObject goodJobUI;
    public GameObject[] metalsDisable;
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
            DataPersistor.persist.accumulatedPoints += 1;
            scoreText.text = DataPersistor.persist.accumulatedPoints.ToString();
            // check kung 10 na, 10 assets lng kasi meron kapag tama 
            if (nonmetalCorrect == 9 || metalloidCorrect == 9 || metalCorrect == 9)
            {
                //dito panalo na next scene save score sa datapersistor
                foreach (GameObject jars in metalsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                goodJobUI.SetActive(true);
                StartCoroutine("LoadEndingScene");
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

        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Metal"))
            {
                metalBrokeCount++;
                if (metalBrokeCount <= 3)
                {
                    metalBrokeRenderer.sprite = brokenMetal[metalBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");//play sound crack pag mali
                }
                else
                {
                    metalBrokeRenderer.sprite = brokenMetal[metalBrokeCount-1];
                    metalRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");//play break sound pag naka tatlong mali na
                }


            }
            if (this.tag.Equals("Metalloid"))
            {
                metalloidBrokeCount++;
                if (metalloidBrokeCount <= 3)
                {
                    metalloidBrokeRenderer.sprite = brokenMetalloid[metalloidBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    metalloidBrokeRenderer.sprite = brokenMetalloid[metalloidBrokeCount-1];
                    metalloidRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
               

                }

            }
            if (this.tag.Equals("NonMetal"))
            {
                nonmetalBrokeCount++;
                if (nonmetalBrokeCount <= 3)
                {
                    nonmetalBrokeRenderer.sprite = brokenNonMetal[nonmetalBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    nonmetalBrokeRenderer.sprite = brokenNonMetal[nonmetalBrokeCount-1];
                    nonmetalRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                    
                }

            }

            if (metalBrokeCount == 4 || nonmetalBrokeCount == 4 || metalloidBrokeCount == 4)
            {
                foreach(GameObject jars in metalsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                GameObject.Find("TimerText").GetComponent<timerscript>().StopTime();
                gameOverPanel.SetActive(true);
                StartCoroutine("LoadEndingScene");
            }

            //Debug.Log("Mali");
        }
    }

    private IEnumerator LoadEndingScene()
    {
        yield return new WaitForSeconds(4);

        //SceneManager.LoadScene("Help_EndingSceneForAll");
        LevelManager.lvlmgr.LoadLevel("Help_EndingSceneForAll");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
