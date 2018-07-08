using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioVolume : MonoBehaviour {
    public GameObject bgmSlider;
    public GameObject sfxSlider;

    private void Start()
    {
        bgmSlider.GetComponent<Slider>().value = AudioManager.instance.bgmVolume;
        sfxSlider.GetComponent<Slider>().value = AudioManager.instance.sfxVolume;
    }

    public void SetBGMVolume()
    {
        AudioManager.instance.bgmVolume = bgmSlider.GetComponent<Slider>().value;
        AudioManager.instance.SetSoundProperties();
    }

    public void SetSFXVolume()
    {
        AudioManager.instance.sfxVolume = sfxSlider.GetComponent<Slider>().value;
        AudioManager.instance.SetSoundProperties();
    }
}
