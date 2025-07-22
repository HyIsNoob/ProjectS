using UnityEngine;

namespace ProjectS.Menu
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;
        public AudioSource voiceSource;
        
        [Header("Menu Audio")]
        public AudioClip menuBackgroundMusic;
        public AudioClip buttonClickSound;
        public AudioClip buttonHoverSound;
        public AudioClip menuOpenSound;
        public AudioClip menuCloseSound;
        
        [Header("Game Audio")]
        public AudioClip gameplayMusic;
        public AudioClip ambientForestSound;
        
        public static AudioManager Instance;
        
        private void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }
        
        private void Start()
        {
            // Load audio settings
            LoadAudioSettings();
        }
        
        public void PlayMenuMusic()
        {
            if (menuBackgroundMusic != null && musicSource != null)
            {
                musicSource.clip = menuBackgroundMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        
        public void PlayGameplayMusic()
        {
            if (gameplayMusic != null && musicSource != null)
            {
                musicSource.clip = gameplayMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        
        public void PlayButtonClick()
        {
            PlaySFX(buttonClickSound);
        }
        
        public void PlayButtonHover()
        {
            PlaySFX(buttonHoverSound);
        }
        
        public void PlayMenuOpen()
        {
            PlaySFX(menuOpenSound);
        }
        
        public void PlayMenuClose()
        {
            PlaySFX(menuCloseSound);
        }
        
        public void PlaySFX(AudioClip clip)
        {
            if (clip != null && sfxSource != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }
        
        public void PlayVoice(AudioClip clip)
        {
            if (clip != null && voiceSource != null)
            {
                voiceSource.clip = clip;
                voiceSource.Play();
            }
        }
        
        public void StopMusic()
        {
            if (musicSource != null)
                musicSource.Stop();
        }
        
        public void StopAllSFX()
        {
            if (sfxSource != null)
                sfxSource.Stop();
        }
        
        public void StopVoice()
        {
            if (voiceSource != null)
                voiceSource.Stop();
        }
        
        public void SetMasterVolume(float volume)
        {
            AudioListener.volume = volume;
        }
        
        public void SetMusicVolume(float volume)
        {
            if (musicSource != null)
                musicSource.volume = volume;
        }
        
        public void SetSFXVolume(float volume)
        {
            if (sfxSource != null)
                sfxSource.volume = volume;
        }
        
        public void SetVoiceVolume(float volume)
        {
            if (voiceSource != null)
                voiceSource.volume = volume;
        }
        
        private void LoadAudioSettings()
        {
            // Load saved audio settings from PlayerPrefs
            float masterVol = PlayerPrefs.GetFloat("MasterVolume", 0.8f);
            float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
            float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.9f);
            float voiceVol = PlayerPrefs.GetFloat("VoiceVolume", 0.8f);
            
            SetMasterVolume(masterVol);
            SetMusicVolume(musicVol);
            SetSFXVolume(sfxVol);
            SetVoiceVolume(voiceVol);
        }
        
        // Call this when scene changes
        public void OnSceneChanged(string sceneName)
        {
            switch (sceneName)
            {
                case "MainMenu":
                    PlayMenuMusic();
                    break;
                case "GameplayScene":
                    PlayGameplayMusic();
                    break;
                default:
                    // Keep current music
                    break;
            }
        }
    }
}
