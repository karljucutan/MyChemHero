using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Assets.Scripts;

public class VideoPlayerScript : MonoBehaviour {

	public VideoPlayer vidplayer;

    private bool playStarted = false;
    private bool clickedSkip = false;

    private void Awake()
    {
        vidplayer.url = Configuration.VideoURL;
        vidplayer.SetTargetAudioSource(0, GetComponent<AudioSource>());
        vidplayer.Prepare();
    }


    void Update()
    {
        if(playStarted == false)
        {
            if(vidplayer.isPrepared)
            {
                vidplayer.Play();
                playStarted = true;
            }
        }

        if ((playStarted || clickedSkip) && vidplayer.isPlaying == false)
        {
            LevelManager.lvlmgr.LoadLevel("Load");
        }
    }

    public void StopVideo()
    {
        vidplayer.Stop();
        clickedSkip = true;
    }
}
