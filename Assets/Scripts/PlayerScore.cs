using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject gameOverUI;
    public GameObject goodJobUI;
    public GameObject[] solidsDisable;

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
            DataPersistor.persist.accumulatedPoints += 1;
            scoreText.text = DataPersistor.persist.accumulatedPoints.ToString();

            if (solidCorrect == 9 || liquidCorrect == 9 || gasCorrect == 9)
            {
                foreach (GameObject jars in solidsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                goodJobUI.SetActive(true);
                StartCoroutine("LoadEndingScene");
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


          
        }
        else
        {
            //here pag mali ang pag segregate
            Destroy(target.gameObject, 0.2f);
            //target.gameObject.SetActive(false);
            if (this.tag.Equals("Solid"))
            {
                solidBrokeCount++;
                if (solidBrokeCount <=3)
                {
                    solidBrokeRenderer.sprite = brokenSolid[solidBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    solidBrokeRenderer.sprite = brokenSolid[solidBrokeCount-1];
                    solidRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                    
                }
                

            }
            if (this.tag.Equals("Liquid"))
            {
                liquidBrokeCount++;
                if (liquidBrokeCount <= 3)
                {
                    liquidBrokeRenderer.sprite = brokenLiquid[liquidBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    liquidBrokeRenderer.sprite = brokenLiquid[liquidBrokeCount-1];
                    liquidRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
                   

                }
                
            }
            if (this.tag.Equals("Gas"))
            {
                gasBrokeCount++;
                if (gasBrokeCount <= 3)
                {
                    gasBrokeRenderer.sprite = brokenGas[gasBrokeCount-1];
                    
                    sound.GetComponent<SoundManagerScript>().playSound("crack");
                }
                else
                {
                    gasBrokeRenderer.sprite = brokenGas[gasBrokeCount-1];
                    gasRenderer.sprite = null;
                    sound.GetComponent<SoundManagerScript>().playSound("break");
               
                }
                
            }
            if (solidBrokeCount == 4 || liquidBrokeCount == 4 || gasBrokeCount == 4)
            {
                foreach (GameObject jars in solidsDisable)
                {
                    jars.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                gameOverUI.SetActive(true);
                StartCoroutine("LoadEndingScene");
            }

            //Debug.Log("Mali");
        }
    }

    private IEnumerator LoadEndingScene()
    {
        yield return new WaitForSeconds(2);

        //SceneManager.LoadScene("Help_EndingSceneForAll");
        LevelManager.lvlmgr.LoadLevel("Help_EndingSceneForAll");
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
