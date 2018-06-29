using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager lvlmgr;

    void Awake()
    {
        if(lvlmgr == null)
        {
            lvlmgr = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Animator animator;
    private string levelToLoad;

    public void LoadLevel(string levelname)
    {
        //Debug.Log(levelname);
        levelToLoad = levelname;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log(levelToLoad);
        animator.ResetTrigger("FadeOut");
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }
}
