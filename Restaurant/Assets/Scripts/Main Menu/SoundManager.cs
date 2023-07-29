using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public AudioSource buttonSound;



    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVol"))
        {
            LoadVol();
        }
        else
        {
            SetMasterVol();
            SetMusicVol();
            SetSFXVol();
        }
      
    }

    public void SetMasterVol()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVol", volume);
    }

    public void SetMusicVol()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    public void SetSFXVol()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVol", volume);
    }

    private void LoadVol()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVol");
        masterSlider.value = PlayerPrefs.GetFloat("masterVol");

        SetMasterVol();
        SetMusicVol();
        SetSFXVol();
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

}
