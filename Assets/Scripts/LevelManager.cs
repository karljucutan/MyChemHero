﻿using Assets.Scripts;
using Assets.Scripts.Minigame.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

   
    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

}
