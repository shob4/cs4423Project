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
  public AudioSource effect;

  void Start(){
    if (PlayerPrefs.GetInt("set first time volume") == 0){
      PlayerPrefs.SetInt("set first time volume", 1);
      masterSlider.value = .25f;
      musicSlider.value = .25f;
      FXSlider.value = .25f;
    }
    else {
      masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
      musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
      FXSlider.value = PlayerPrefs.GetFloat("FXVolume");
    }
  }

  public void SetMasterVolume(){
    SetVolume("MasterVolume", masterSlider.value);
  }

  public void SetMusicVolume(){
    SetVolume("MusicVolume", musicSlider.value);
  }

  public void SetFXVolume(){
    SetVolume("FXVolume", FXSlider.value);
    // TODO play sound effect
    effect.pitch = Random.Range(.9f, 1.1f);
    effect.Play();
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
