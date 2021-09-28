using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMasterVolume(float volumeMaster)
    {
        masterMixer.SetFloat("MasterVolume", volumeMaster);
    }

    public void SetMusicVolume(float volumeMusic)
    {
        masterMixer.SetFloat("MusicVolume", volumeMusic);
    }

    public void SetFXVolume(float volumeFX)
    {
        masterMixer.SetFloat("FXVolume", volumeFX);
    }
}
