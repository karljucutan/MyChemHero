using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Assets.Scripts;

public class VideoPlayerScript : MonoBehaviour {

	public VideoPlayer vidplayer;

    private void Awake()
    {
        vidplayer.url = Configuration.VideoURL;
        vidplayer.SetTargetAudioSource(0, GetComponent<AudioSource>());
        vidplayer.Play();
    }

    void Update()
    {
        
            if (Input.anyKeyDown)
            {
                vidplayer.Pause();
            }
            if (vidplayer.isPlaying == false)
            {
                LevelManager.lvlmgr.LoadLevel("Load");
            }
        
    }
}
