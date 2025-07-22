using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class MenuController : MonoBehaviour
{
    // ========== MENU BUTTONS ==========
    [Header("Levels to Load")]
    public string _newGameLevel;
    private string _currentLevel;
    [SerializeField] private GameObject noSavedGameDialog = null;

    // ========== VOLUME SETTINGS ==========
    [Header("Volume Settings")]
    // Master Volume Control
    [SerializeField] private TMP_Text MasterVolumeTextValue = null;
    [SerializeField] private Slider MasterVolumeSlider = null;

    // Music Volume Control
    [SerializeField] private TMP_Text MusicVolumeTextValue = null;
    [SerializeField] private Slider MusicVolumeSlider = null;

    // Sound Volume Control
    [SerializeField] private TMP_Text SoundVolumeTextValue = null;
    [SerializeField] private Slider SoundVolumeSlider = null;

    // Confirmation Prompt
    [SerializeField] private GameObject confirmationPrompt = null;

    // ========== GAME CONTROL METHODS ==========
    public void NewGameDialogConfirm()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    public void LoadGameDialogConfirm()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            _currentLevel = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(_currentLevel);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    // ========== VOLUME CONTROL METHODS ==========

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        if (MasterVolumeTextValue != null)
            MasterVolumeTextValue.text = (volume * 100).ToString("F0") + "%";
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
        if (MusicVolumeTextValue != null)
            MusicVolumeTextValue.text = (volume * 100).ToString("F0") + "%";
    }

    public void SetSoundVolume(float volume)
    {
        AudioManager.Instance.SetSoundVolume(volume);
        if (SoundVolumeTextValue != null)
            SoundVolumeTextValue.text = (volume * 100).ToString("F0") + "%";
    }

    public void VolumeApply()
    {
        // Save the current volumes to PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        PlayerPrefs.SetFloat("MusicVolume", AudioManager.Instance.GetMusicVolume());
        PlayerPrefs.SetFloat("SoundVolume", AudioManager.Instance.GetSoundVolume());
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
