using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour {

	public VideoPlayer vidplayer;
    public GameObject lvlmgr;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            vidplayer.Stop();
        }
        if(vidplayer.isPlaying == false)
        {
            lvlmgr.GetComponent<LevelManager>().LoadLevel("Load");
        }
    }
}
