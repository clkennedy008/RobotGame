using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioMixer audioMixer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setMasterVolume(float vol)
    {
        audioMixer.SetFloat("MasterVolume", vol);
        PlayerPrefs.SetFloat("MasterVolume", vol);
    }
    public void setMusicVolume(float vol)
    {
        audioMixer.SetFloat("MusicVolume", vol);
        PlayerPrefs.SetFloat("MusicVolume", vol);
    }
    public void setSFXVolume(float vol)
    {
        audioMixer.SetFloat("SFXVolume", vol);
        PlayerPrefs.SetFloat("SFXVolume", vol);
    }

    public float getSFXVolume()
    {
        float vol;
        audioMixer.GetFloat("SFXVolume", out vol);
        return vol;
    }
    public float getMusicVolume()
    {
        float vol;
        audioMixer.GetFloat("MusicVolume", out vol);
        return vol;
    }
    public float getMasterVolume()
    {
        float vol;
        audioMixer.GetFloat("MasterVolume", out vol);
        return vol;
    }

}