using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FallingObjectSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject fallingObjectPrefab;
    private float timeBetweenWaves = 2f;
    public Text textScore;
    public int score = -4;
    // Use this for initialization
    private void Start ()
    {
        
        InvokeRepeating("SpawnBlocks", 2.0f, timeBetweenWaves);
        SpawnBlocks();
       
	}
    private void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                score += 1;
                textScore.GetComponent<Text>().text = string.Format("{0:00}", score);
                Instantiate(fallingObjectPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}

