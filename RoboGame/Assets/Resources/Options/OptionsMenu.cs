
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider MasterSlide;
    public Slider MusicSlide;
    public Slider SFXSlide;
    public AudioManager audioManager;

    
    void Start()
    {
    }

    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            close();
        }
    }

    public void close()
    {
        PlayerPrefs.Save();
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        MasterSlide.value = audioManager.getMasterVolume();
        MusicSlide.value = audioManager.getMusicVolume();
        SFXSlide.value = audioManager.getSFXVolume();
    }
}
