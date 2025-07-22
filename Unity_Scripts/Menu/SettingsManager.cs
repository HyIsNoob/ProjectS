using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

namespace ProjectS.Menu
{
    public class SettingsManager : MonoBehaviour
    {
        [Header("Audio Settings")]
        public AudioMixer audioMixer;
        public Slider masterVolumeSlider;
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;
        public Slider voiceVolumeSlider;
        
        [Header("Graphics Settings")]
        public Dropdown qualityDropdown;
        public Dropdown resolutionDropdown;
        public Toggle fullscreenToggle;
        public Toggle vsyncToggle;
        public Dropdown antiAliasingDropdown;
        
        [Header("Gameplay Settings")]
        public Slider mouseSensitivitySlider;
        public Toggle invertYAxisToggle;
        
        private Resolution[] resolutions;
        
        private void Start()
        {
            SetupResolutions();
            LoadSettings();
        }
        
        private void SetupResolutions()
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            
            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
        
        public void SetMasterVolume(float volume)
        {
            if (audioMixer != null)
                audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
        
        public void SetMusicVolume(float volume)
        {
            if (audioMixer != null)
                audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }
        
        public void SetSFXVolume(float volume)
        {
            if (audioMixer != null)
                audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }
        
        public void SetVoiceVolume(float volume)
        {
            if (audioMixer != null)
                audioMixer.SetFloat("VoiceVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("VoiceVolume", volume);
        }
        
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            PlayerPrefs.SetInt("QualityLevel", qualityIndex);
        }
        
        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        }
        
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        }
        
        public void SetVSync(bool isVSync)
        {
            QualitySettings.vSyncCount = isVSync ? 1 : 0;
            PlayerPrefs.SetInt("VSync", isVSync ? 1 : 0);
        }
        
        public void SetAntiAliasing(int aaIndex)
        {
            // 0 = Off, 1 = 2x, 2 = 4x, 3 = 8x
            int[] aaValues = { 0, 2, 4, 8 };
            QualitySettings.antiAliasing = aaValues[aaIndex];
            PlayerPrefs.SetInt("AntiAliasing", aaIndex);
        }
        
        public void SetMouseSensitivity(float sensitivity)
        {
            PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        }
        
        public void SetInvertYAxis(bool invert)
        {
            PlayerPrefs.SetInt("InvertYAxis", invert ? 1 : 0);
        }
        
        public void ApplySettings()
        {
            // Save all settings to PlayerPrefs
            PlayerPrefs.Save();
            Debug.Log("Settings applied and saved!");
        }
        
        public void ResetToDefaults()
        {
            // Reset all settings to default values
            if (masterVolumeSlider != null) masterVolumeSlider.value = 0.8f;
            if (musicVolumeSlider != null) musicVolumeSlider.value = 0.7f;
            if (sfxVolumeSlider != null) sfxVolumeSlider.value = 0.9f;
            if (voiceVolumeSlider != null) voiceVolumeSlider.value = 0.8f;
            
            if (qualityDropdown != null) qualityDropdown.value = QualitySettings.names.Length - 1;
            if (fullscreenToggle != null) fullscreenToggle.isOn = true;
            if (vsyncToggle != null) vsyncToggle.isOn = true;
            if (antiAliasingDropdown != null) antiAliasingDropdown.value = 2; // 4x AA
            
            if (mouseSensitivitySlider != null) mouseSensitivitySlider.value = 2.0f;
            if (invertYAxisToggle != null) invertYAxisToggle.isOn = false;
            
            // Apply the default settings
            ApplyCurrentSettings();
        }
        
        private void LoadSettings()
        {
            // Load audio settings
            if (masterVolumeSlider != null)
            {
                float masterVol = PlayerPrefs.GetFloat("MasterVolume", 0.8f);
                masterVolumeSlider.value = masterVol;
                SetMasterVolume(masterVol);
            }
            
            if (musicVolumeSlider != null)
            {
                float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
                musicVolumeSlider.value = musicVol;
                SetMusicVolume(musicVol);
            }
            
            if (sfxVolumeSlider != null)
            {
                float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.9f);
                sfxVolumeSlider.value = sfxVol;
                SetSFXVolume(sfxVol);
            }
            
            if (voiceVolumeSlider != null)
            {
                float voiceVol = PlayerPrefs.GetFloat("VoiceVolume", 0.8f);
                voiceVolumeSlider.value = voiceVol;
                SetVoiceVolume(voiceVol);
            }
            
            // Load graphics settings
            if (qualityDropdown != null)
            {
                int quality = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());
                qualityDropdown.value = quality;
                SetQuality(quality);
            }
            
            if (resolutionDropdown != null)
            {
                int resIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutionDropdown.value);
                resolutionDropdown.value = resIndex;
            }
            
            if (fullscreenToggle != null)
            {
                bool fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
                fullscreenToggle.isOn = fullscreen;
                SetFullscreen(fullscreen);
            }
            
            if (vsyncToggle != null)
            {
                bool vsync = PlayerPrefs.GetInt("VSync", 1) == 1;
                vsyncToggle.isOn = vsync;
                SetVSync(vsync);
            }
            
            if (antiAliasingDropdown != null)
            {
                int aa = PlayerPrefs.GetInt("AntiAliasing", 2);
                antiAliasingDropdown.value = aa;
                SetAntiAliasing(aa);
            }
            
            // Load gameplay settings
            if (mouseSensitivitySlider != null)
            {
                float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2.0f);
                mouseSensitivitySlider.value = sensitivity;
            }
            
            if (invertYAxisToggle != null)
            {
                bool invert = PlayerPrefs.GetInt("InvertYAxis", 0) == 1;
                invertYAxisToggle.isOn = invert;
            }
        }
        
        private void ApplyCurrentSettings()
        {
            // Apply all current slider/toggle values
            if (masterVolumeSlider != null) SetMasterVolume(masterVolumeSlider.value);
            if (musicVolumeSlider != null) SetMusicVolume(musicVolumeSlider.value);
            if (sfxVolumeSlider != null) SetSFXVolume(sfxVolumeSlider.value);
            if (voiceVolumeSlider != null) SetVoiceVolume(voiceVolumeSlider.value);
            
            if (qualityDropdown != null) SetQuality(qualityDropdown.value);
            if (resolutionDropdown != null) SetResolution(resolutionDropdown.value);
            if (fullscreenToggle != null) SetFullscreen(fullscreenToggle.isOn);
            if (vsyncToggle != null) SetVSync(vsyncToggle.isOn);
            if (antiAliasingDropdown != null) SetAntiAliasing(antiAliasingDropdown.value);
            
            if (mouseSensitivitySlider != null) SetMouseSensitivity(mouseSensitivitySlider.value);
            if (invertYAxisToggle != null) SetInvertYAxis(invertYAxisToggle.isOn);
        }
    }
}
