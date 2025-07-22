# Menu Implementation Guide - Step by Step

## 🚀 Quick Start Implementation

### **Step 1: Setup Main Menu Scene (30 minutes)**

1. **Create New Scene**
   - File → New Scene
   - Save as `MainMenu.unity` in `Assets/_ProjectS/Scenes/`

2. **Setup Canvas**
   - GameObject → UI → Canvas
   - Canvas → Render Mode: Screen Space - Overlay
   - Canvas Scaler → UI Scale Mode: Scale With Screen Size
   - Reference Resolution: 1920x1080

3. **Add Background**
   - GameObject → UI → Image (child of Canvas)
   - Name: "Background"
   - Anchor: Stretch to full screen
   - Color: Dark gray (#2C2C2C) temporarily

### **Step 2: Create Basic Button Layout (45 minutes)**

4. **Create Title**
   - GameObject → UI → Text - TextMeshPro
   - Name: "GameTitle"
   - Text: "ProjectS"
   - Font Size: 72
   - Color: White
   - Position: Top center

5. **Create Button Container**
   - GameObject → Create Empty (child of Canvas)
   - Name: "ButtonContainer"
   - Add Vertical Layout Group component
   - Spacing: 20
   - Child Alignment: Middle Center

6. **Create Menu Buttons**
   - GameObject → UI → Button - TextMeshPro (child of ButtonContainer)
   - Create 5 buttons: "New Game", "Load Game", "Settings", "Credits", "Exit"
   - Each button size: 300x60

### **Step 3: Basic Script Implementation (60 minutes)**

7. **Create MenuManager Script**
```csharp
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    
    [Header("Buttons")]
    public Button newGameButton;
    public Button loadGameButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button exitButton;
    
    private void Start()
    {
        // Bind button events
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        settingsButton.onClick.AddListener(OpenSettings);
        creditsButton.onClick.AddListener(OpenCredits);
        exitButton.onClick.AddListener(ExitGame);
        
        // Show main menu by default
        ShowMainMenu();
    }
    
    public void StartNewGame()
    {
        Debug.Log("Starting New Game...");
        // TODO: Load gameplay scene
        // SceneManager.LoadScene("GameplayScene");
    }
    
    public void LoadGame()
    {
        Debug.Log("Loading Game...");
        // TODO: Implement load system
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
    
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
```

### **Step 4: Settings Panel (90 minutes)**

8. **Create Settings Panel**
   - GameObject → UI → Panel (child of Canvas)
   - Name: "SettingsPanel"
   - Set inactive by default

9. **Add Settings Controls**
```csharp
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    
    [Header("Graphics")]
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    
    [Header("Panels")]
    public GameObject settingsPanel;
    public MenuManager menuManager;
    
    private void Start()
    {
        LoadSettings();
        SetupResolutionDropdown();
    }
    
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
    
    public void ApplySettings()
    {
        PlayerPrefs.Save();
        BackToMainMenu();
    }
    
    public void BackToMainMenu()
    {
        menuManager.ShowMainMenu();
    }
    
    private void LoadSettings()
    {
        // Load saved settings
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.8f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.9f);
        
        qualityDropdown.value = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }
    
    private void SetupResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        
        Resolution[] resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionDropdown.options.Add(new Dropdown.OptionData(option));
            
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
```

### **Step 5: Basic Styling (60 minutes)**

10. **Button Styling**
    - Select button → Colors
    - Normal: #4A4A4A
    - Highlighted: #6A6A6A  
    - Pressed: #2A2A2A
    - Selected: #4A4A4A

11. **Text Styling**
    - Font: Try to find horror-style font
    - Title: Large, dramatic
    - Buttons: Clear, readable

### **Step 6: Scene Management (30 minutes)**

12. **Create Scene Transition**
```csharp
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    
    [Header("Transition")]
    public GameObject loadingPanel;
    public UnityEngine.UI.Slider progressBar;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingPanel.SetActive(true);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;
            yield return null;
        }
        
        loadingPanel.SetActive(false);
    }
}
```

## 🎯 Testing Your Menu

### **Quick Test Checklist**
- [ ] All buttons are clickable
- [ ] Settings panel opens/closes
- [ ] Audio sliders work (if audio setup)
- [ ] Quality settings apply
- [ ] Exit button works in build
- [ ] Text is readable
- [ ] Layout looks good in different resolutions

### **Build Test**
1. File → Build Settings
2. Add MainMenu scene to build
3. Build and test actual executable

## 📋 Next Steps After Basic Menu

1. **Add Audio** (background music, UI sounds)
2. **Improve Visual Design** (custom graphics, animations)
3. **Create Credits Scene** 
4. **Implement Save/Load System**
5. **Add Loading Screen Animations**
6. **Create In-Game Pause Menu**

## 🚨 Common Issues & Solutions

**Issue**: Buttons not responding
**Solution**: Check EventSystem exists in scene

**Issue**: Canvas too small/large  
**Solution**: Set Canvas Scaler to Scale With Screen Size

**Issue**: Text blurry
**Solution**: Use TextMeshPro instead of Legacy Text

**Issue**: Slider not working
**Solution**: Check Min/Max values and OnValueChanged events

---

**Priority**: Complete basic menu first, then polish
**Time Estimate**: 4-6 hours for basic functional menu
**Next**: Integrate with game scenes
