using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	// Use this for initialization
    public AudioClip crack, glassBreak;
    static AudioSource audiosrc;
	void Start () {
        audiosrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound(string clip)
    {
        switch (clip)
        {
            case "crack":
                audiosrc.PlayOneShot(crack);
                break;
            case "break":
                audiosrc.PlayOneShot(glassBreak);
                break;
        }
    }
}
