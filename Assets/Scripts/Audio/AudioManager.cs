using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;


public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public float bgmVolume = 1.0f;
    public float sfxVolume = 1.0f;

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if(s.tag.Equals(SoundTags.BGM))
                s.source.volume = bgmVolume;
            else if(s.tag.Equals(SoundTags.SFX))
                s.source.volume = sfxVolume;

            s.source.loop = s.loop;
        }
    }
	
	public void Play(string name)
    {
        try
        {
            Sound s = findSound(name);
            s.source.Play();
        }
        catch (Exception ex) { Debug.Log("Error: " + ex.Message); }
    }

    public void Stop(string name)
    {
        try
        {
            Sound s = findSound(name);
            s.source.Stop();
        }
        catch(Exception ex) { Debug.Log("Error: " + ex.Message); }
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public Sound findSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s;
    }

}
