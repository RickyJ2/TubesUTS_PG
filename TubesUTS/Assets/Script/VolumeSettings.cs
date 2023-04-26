using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer MainMixer;
    [SerializeField] private Slider Slider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("volume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    public void SetVolume()
    {
        float volume = Slider.value;
        MainMixer.SetFloat("volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void LoadVolume()
    {
        Slider.value=PlayerPrefs.GetFloat("volume");
        SetVolume();
    }
}
