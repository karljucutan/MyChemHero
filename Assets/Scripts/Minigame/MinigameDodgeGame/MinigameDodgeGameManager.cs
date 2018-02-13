using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameDodgeGameManager : MonoBehaviour {
    public GameObject FallingObjectSpawner;
	private float speed = 15;
	public void GameOver()
    {
        StartCoroutine("SlowMo");
    }

    private IEnumerator SlowMo()
    {
        Time.timeScale = 1f / speed;
        Time.fixedDeltaTime = Time.fixedDeltaTime / speed;
        DataPersistor.persist.totalPoints = FallingObjectSpawner.GetComponent<FallingObjectSpawner>().score;
        DataPersistor.persist.accumulatedPoints = DataPersistor.persist.totalPoints;
        yield return new WaitForSeconds(2f/speed);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * speed;
        //load endscene
        SceneManager.LoadScene("Help_EndingSceneForAll");
    }
}
