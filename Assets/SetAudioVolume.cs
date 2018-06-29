using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioVolume : MonoBehaviour {

    private void Start()
    {
        GameObject.Find("BGMSlider").GetComponent<Slider>().value = AudioManager.instance.bgmVolume;
        GameObject.Find("SFXSlider").GetComponent<Slider>().value = AudioManager.instance.sfxVolume;
    }

    public void SetBGMVolume()
    {
        AudioManager.instance.bgmVolume = GameObject.Find("BGMSlider").GetComponent<Slider>().value;
        AudioManager.instance.SetSoundProperties();
    }

    public void SetSFXVolume()
    {
        AudioManager.instance.bgmVolume = GameObject.Find("SFXSlider").GetComponent<Slider>().value;
        AudioManager.instance.SetSoundProperties();
    }
}
