using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
  public AudioMixer mixer;
  public Slider masterSlider;
  public Slider musicSlider;
  public Slider FXSlider;

  void Start(){
    masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    FXSlider.value = PlayerPrefs.GetFloat("FXVolume");
  }

  public void SetMasterVolume(){
    SetVolume("MasterVolume", masterSlider.value);
  }

  public void SetMusicVolume(){
    SetVolume("MusicVolume", musicSlider.value);
  }

  public void SetFXVolume(){
    SetVolume("FXVolume", FXSlider.value);
  }

  void SetVolume(string name, float value){
    float volume = Mathf.Log10(value) * 20;
    if(value == 0) {
      volume = -80;
    }

    mixer.SetFloat(name, volume);
    PlayerPrefs.SetFloat(name, value);
  }
}
