using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScoreToxics : MonoBehaviour {

	// Use this for initialization
    public Sprite[] brokenToxic;
    public Sprite[] brokenNonToxic;

    public Sprite[] toxicContent;
    public Sprite[] nontoxicContent;

    public GameObject toxicBroke;
    public GameObject nontoxicBroke;
    public GameObject gameOverUI;
    public GameObject goodJobUI;
    public GameObject[] toxicsDisable;

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
            DataPersistor.persist.accumulatedPoints += 1;
            scoreText.text = DataPersistor.persist.accumulatedPoints.ToString();

            if (nontoxicCorrect == 9 || toxicCorrect == 9)
            {
                foreach (GameObject jars in toxicsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                goodJobUI.SetActive(true);
                StartCoroutine("LoadEndingScene");
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

            
        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            if (this.tag.Equals("Toxic"))
            {
                toxicBrokeCount++;
                if (toxicBrokeCount <= 3)
                {
                    toxicBrokeRenderer.sprite = brokenToxic[toxicBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    toxicBrokeRenderer.sprite = brokenToxic[toxicBrokeCount-1];
                    toxicRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                  
                }


            }
            if (this.tag.Equals("NonToxic"))
            {
                nontoxicBrokeCount++;
                if (nontoxicBrokeCount <= 3)
                {
                    nontoxicBrokeRenderer.sprite = brokenNonToxic[nontoxicBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    nontoxicBrokeRenderer.sprite = brokenNonToxic[nontoxicBrokeCount-1];
                    nontoxicRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                   
                }

            }

            if (nontoxicBrokeCount == 4 || toxicBrokeCount == 4)
            {
                foreach (GameObject jars in toxicsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                GameObject.Find("TimerText").GetComponent<timerscript>().StopTime();
                gameOverUI.SetActive(true);
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
