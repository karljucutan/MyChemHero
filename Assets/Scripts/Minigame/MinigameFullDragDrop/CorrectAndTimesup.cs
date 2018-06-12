using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectAndTimesup : MonoBehaviour {

    void OnEnable()
    {
        StartCoroutine("LoadEndScene");
    }

    private IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(2f);

        //SceneManager.LoadScene("Help_EndingSceneForAll");
        LevelManager.lvlmgr.LoadLevel("Help_EndingSceneForAll");
    }
}
