using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectS.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Menu Panels")]
        public GameObject mainMenuPanel;
        public GameObject settingsPanel;
        public GameObject creditsPanel;
        public GameObject loadingPanel;
        
        [Header("Main Menu Buttons")]
        public Button newGameButton;
        public Button loadGameButton;
        public Button settingsButton;
        public Button creditsButton;
        public Button exitButton;
        
        [Header("Settings Buttons")]
        public Button backFromSettingsButton;
        public Button applySettingsButton;
        
        [Header("Credits Buttons")]
        public Button backFromCreditsButton;
        
        [Header("Audio")]
        public AudioSource buttonClickSound;
        public AudioSource buttonHoverSound;
        
        private void Start()
        {
            InitializeMenu();
            BindButtonEvents();
        }
        
        private void InitializeMenu()
        {
            // Show main menu by default
            ShowMainMenu();
            
            // Hide loading panel
            if (loadingPanel != null)
                loadingPanel.SetActive(false);
                
            // Play background music if exists
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
                audioManager.PlayMenuMusic();
        }
        
        private void BindButtonEvents()
        {
            // Main menu buttons
            if (newGameButton != null)
                newGameButton.onClick.AddListener(() => { PlayClickSound(); StartNewGame(); });
                
            if (loadGameButton != null)
                loadGameButton.onClick.AddListener(() => { PlayClickSound(); LoadGame(); });
                
            if (settingsButton != null)
                settingsButton.onClick.AddListener(() => { PlayClickSound(); OpenSettings(); });
                
            if (creditsButton != null)
                creditsButton.onClick.AddListener(() => { PlayClickSound(); OpenCredits(); });
                
            if (exitButton != null)
                exitButton.onClick.AddListener(() => { PlayClickSound(); ExitGame(); });
            
            // Settings buttons
            if (backFromSettingsButton != null)
                backFromSettingsButton.onClick.AddListener(() => { PlayClickSound(); ShowMainMenu(); });
                
            if (applySettingsButton != null)
                applySettingsButton.onClick.AddListener(() => { PlayClickSound(); ApplySettings(); });
            
            // Credits buttons
            if (backFromCreditsButton != null)
                backFromCreditsButton.onClick.AddListener(() => { PlayClickSound(); ShowMainMenu(); });
        }
        
        public void StartNewGame()
        {
            Debug.Log("Starting New Game...");
            
            // Show loading screen
            if (loadingPanel != null)
                loadingPanel.SetActive(true);
            
            // Load gameplay scene
            StartCoroutine(LoadSceneAsync("GameplayScene"));
        }
        
        public void LoadGame()
        {
            Debug.Log("Loading Game...");
            
            // Check if save file exists
            if (SaveSystem.HasSaveFile())
            {
                // Load saved game
                SaveSystem.LoadGame();
                
                // Show loading screen
                if (loadingPanel != null)
                    loadingPanel.SetActive(true);
                
                // Load gameplay scene
                StartCoroutine(LoadSceneAsync("GameplayScene"));
            }
            else
            {
                Debug.Log("No save file found!");
                // Show message to player - could add UI notification here
            }
        }
        
        public void OpenSettings()
        {
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
        
        public void OpenCredits()
        {
            mainMenuPanel.SetActive(false);
            creditsPanel.SetActive(true);
        }
        
        public void ShowMainMenu()
        {
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false);
            creditsPanel.SetActive(false);
        }
        
        public void ApplySettings()
        {
            // Get settings manager and apply settings
            SettingsManager settingsManager = FindObjectOfType<SettingsManager>();
            if (settingsManager != null)
            {
                settingsManager.ApplySettings();
            }
            
            ShowMainMenu();
        }
        
        public void ExitGame()
        {
            Debug.Log("Exiting Game...");
            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        
        private void PlayClickSound()
        {
            if (buttonClickSound != null)
                buttonClickSound.Play();
        }
        
        private void PlayHoverSound()
        {
            if (buttonHoverSound != null)
                buttonHoverSound.Play();
        }
        
        private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            
            while (!operation.isDone)
            {
                // Update loading progress if you have a progress bar
                yield return null;
            }
        }
        
        // Call this method on button hover (setup in inspector)
        public void OnButtonHover()
        {
            PlayHoverSound();
        }
    }
}
