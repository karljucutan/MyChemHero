using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour {

	public VideoPlayer vidplayer;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            vidplayer.Stop();
        }
        if(vidplayer.isPlaying == false)
        {
            LevelManager.lvlmgr.LoadLevel("Load");
        }
    }
}
