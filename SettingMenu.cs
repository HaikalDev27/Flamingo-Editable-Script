using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMaster(float volume){
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetSong(float volume){
        audioMixer.SetFloat("SongVolume", volume);
    }
    public void SetSFX(float volume){
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
