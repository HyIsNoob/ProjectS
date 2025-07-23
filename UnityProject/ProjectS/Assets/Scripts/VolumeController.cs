using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private AudioMixer myMixer;
    // Master Volume Control
    [SerializeField] private TMP_Text masterVolumeTextValue = null;
    [SerializeField] private Slider masterVolumeSlider = null;

    // Music Volume Control
    [SerializeField] private TMP_Text musicVolumeTextValue = null;
    [SerializeField] private Slider musicVolumeSlider = null;

    // Sound Volume Control
    [SerializeField] private TMP_Text soundVolumeTextValue = null;
    [SerializeField] private Slider soundVolumeSlider = null;

    //Reset Default Volume
    [SerializeField] private float defaultVolume = 0.0000005f;
    
    public void ResetVolumeSettings()
    {
        // Set all sliders to default value
        masterVolumeSlider.value = defaultVolume;
        musicVolumeSlider.value = defaultVolume;
        soundVolumeSlider.value = defaultVolume;
        
        // Apply changes
        SetMasterVolume();
        SetMusicVolume();
        SetSoundVolume();
    }

    // ========== VOLUME CONTROL METHODS ==========

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
            SetMasterVolume();
            SetMusicVolume();
            SetSoundVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSoundVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = masterVolumeSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        if (masterVolumeTextValue != null)
        {
            masterVolumeTextValue.text = Mathf.RoundToInt(volume * 100).ToString() + "%";
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        if (musicVolumeTextValue != null)
        {
            musicVolumeTextValue.text = Mathf.RoundToInt(volume * 100).ToString() + "%";
        }
    }
    public void SetSoundVolume()
    {
        float volume = soundVolumeSlider.value;
        myMixer.SetFloat("sound", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", volume);
        if (soundVolumeTextValue != null)
        {
            soundVolumeTextValue.text = Mathf.RoundToInt(volume * 100).ToString() + "%";
        }
    }
    private void LoadVolume()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        soundVolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
    }
}
