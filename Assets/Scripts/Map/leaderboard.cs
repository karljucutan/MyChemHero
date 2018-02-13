using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour {

	
    public void displayLeaderboard()
    {
        CameraController.isPaused = true;
    }

    public void hideLeaderboard()
    {
        CameraController.isPaused = false;
    }
}
