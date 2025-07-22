# Unity Menu Setup Instructions - ProjectS

## 🎯 Step-by-Step Unity Implementation

### **Step 1: Create Main Menu Scene (10 minutes)**

1. **Create New Scene**
   ```
   File → New Scene → Basic (Built-in) → Save as "MainMenu.unity"
   Location: Assets/_ProjectS/Scenes/MainMenu.unity
   ```

2. **Delete Default Objects**
   - Delete "Main Camera" 
   - Delete "Directional Light"

### **Step 2: Setup Canvas (15 minutes)**

3. **Create UI Canvas**
   ```
   Right-click Hierarchy → UI → Canvas
   ```

4. **Configure Canvas**
   ```
   Canvas Component:
   - Render Mode: Screen Space - Overlay
   - Pixel Perfect: ✓
   
   Canvas Scaler Component:
   - UI Scale Mode: Scale With Screen Size
   - Reference Resolution: 1920 x 1080
   - Screen Match Mode: Match Width Or Height
   - Match: 0.5
   ```

5. **Add EventSystem** (should auto-create, if not):
   ```
   Right-click Hierarchy → UI → Event System
   ```

### **Step 3: Create Background (10 minutes)**

6. **Background Image**
   ```
   Right-click Canvas → UI → Image
   Name: "Background"
   
   Rect Transform:
   - Anchor: Stretch both (Alt + Shift + Click stretch icon)
   - Left, Top, Right, Bottom: 0
   
   Image Component:
   - Color: #1A1A1A (dark gray temporarily)
   ```

### **Step 4: Create Title (15 minutes)**

7. **Game Title**
   ```
   Right-click Canvas → UI → Text - TextMeshPro
   Name: "GameTitle"
   
   Rect Transform:
   - Anchor: Top Center
   - Pos X: 0, Pos Y: -150
   - Width: 800, Height: 120
   
   TextMeshPro Component:
   - Text: "ProjectS"
   - Font Size: 72
   - Color: White
   - Alignment: Center and Middle
   ```

8. **Studio Name**
   ```
   Right-click Canvas → UI → Text - TextMeshPro
   Name: "StudioName"
   
   Rect Transform:
   - Anchor: Top Center  
   - Pos X: 0, Pos Y: -220
   - Width: 400, Height: 40
   
   TextMeshPro Component:
   - Text: "Studio Synapse"
   - Font Size: 24
   - Color: #CCCCCC
   - Alignment: Center and Middle
   ```

### **Step 5: Create Button Container (10 minutes)**

9. **Button Container**
   ```
   Right-click Canvas → Create Empty
   Name: "ButtonContainer"
   
   Rect Transform:
   - Anchor: Middle Center
   - Pos X: 0, Pos Y: -50
   - Width: 300, Height: 400
   
   Add Component: Vertical Layout Group
   - Spacing: 20
   - Child Alignment: Middle Center
   - Child Controls Size: Width ✓, Height ✓
   - Child Force Expand: Width ✓, Height ✗
   ```

### **Step 6: Create Menu Buttons (30 minutes)**

10. **New Game Button**
    ```
    Right-click ButtonContainer → UI → Button - TextMeshPro
    Name: "NewGameButton"
    
    Button Component:
    - Interactable: ✓
    - Transition: Color Tint
    - Target Graphic: Button Image
    - Normal Color: #4A4A4A
    - Highlighted Color: #6A6A6A
    - Pressed Color: #2A2A2A
    - Selected Color: #4A4A4A
    
    Layout Element Component (Add this):
    - Preferred Height: 60
    
    Text (child object):
    - Text: "NEW GAME"
    - Font Size: 24
    - Color: White
    ```

11. **Repeat for other buttons:**
    - LoadGameButton: "LOAD GAME"
    - SettingsButton: "SETTINGS"  
    - CreditsButton: "CREDITS"
    - ExitButton: "EXIT GAME"

### **Step 7: Create Settings Panel (45 minutes)**

12. **Settings Panel**
    ```
    Right-click Canvas → UI → Panel
    Name: "SettingsPanel"
    
    Rect Transform:
    - Anchor: Stretch
    - Margins: 200 on all sides
    
    Image Component:
    - Color: #2A2A2A (semi-transparent)
    - Set Alpha to 200
    
    Set Active: ✗ (unchecked)
    ```

13. **Settings Title**
    ```
    Right-click SettingsPanel → UI → Text - TextMeshPro
    Name: "SettingsTitle"
    Text: "SETTINGS"
    Font Size: 48
    Position: Top center of panel
    ```

14. **Audio Section**
    ```
    Create UI elements in SettingsPanel:
    
    Master Volume:
    - Text: "Master Volume"
    - Slider: Min 0, Max 1, Value 0.8
    
    Music Volume:
    - Text: "Music Volume"  
    - Slider: Min 0, Max 1, Value 0.7
    
    SFX Volume:
    - Text: "SFX Volume"
    - Slider: Min 0, Max 1, Value 0.9
    ```

15. **Graphics Section**
    ```
    Quality:
    - Text: "Quality"
    - Dropdown: "Low, Medium, High, Ultra"
    
    Fullscreen:
    - Text: "Fullscreen"
    - Toggle: Default On
    ```

16. **Settings Buttons**
    ```
    Back Button: "BACK"
    Apply Button: "APPLY"
    ```

### **Step 8: Create Credits Panel (20 minutes)**

17. **Credits Panel**
    ```
    Right-click Canvas → UI → Panel
    Name: "CreditsPanel"
    Similar setup to SettingsPanel
    Set Active: ✗
    
    Add Text:
    "ProjectS - Horror 3D Game
    
    Studio Synapse
    
    Team:
    Nguyễn Khang Hy - Project Lead (UIT)
    Nguyễn Gia Khánh - Game Designer (IUH)  
    Lưu Trí Kiệt - 3D Artist (HUIT)
    Nguyễn Việt Hoàng - Audio & AI (TDT)
    
    Unity 2022.3 LTS
    
    Thank you for playing!"
    ```

### **Step 9: Add Scripts (30 minutes)**

18. **Create Managers**
    ```
    Create Empty GameObject: "MenuManager"
    Add Script: MenuManager.cs (copy from Unity_Scripts/Menu/)
    
    Create Empty GameObject: "AudioManager"  
    Add Script: AudioManager.cs
    
    Add SettingsManager.cs to SettingsPanel
    ```

19. **Wire up References**
    ```
    In MenuManager script:
    - Drag panels to Panel slots
    - Drag buttons to Button slots
    - Configure all references
    ```

### **Step 10: Add Button Effects (15 minutes)**

20. **Enhanced Buttons**
    ```
    For each button:
    - Add MenuButtonEffects.cs script
    - Configure hover/press effects
    - Set colors and scales
    ```

### **Step 11: Testing (15 minutes)**

21. **Test All Functionality**
    ```
    ✓ Buttons respond to clicks
    ✓ Settings panel opens/closes
    ✓ Credits panel opens/closes  
    ✓ Sliders work
    ✓ Dropdown works
    ✓ Exit button works in editor
    ```

## 🎨 Visual Polish (Optional)

### **Add Custom Colors**
```
Background: Dark forest green #0F1419
Buttons: Dark gray #2D3748
Hover: Lighter gray #4A5568
Text: White #FFFFFF
Accent: Horror red #E53E3E
```

### **Font Improvements**
- Import horror/gothic font from Google Fonts
- Apply to title and buttons
- Keep body text readable

### **Background Image**
- Find dark forest silhouette image
- Apply as Background sprite
- Adjust opacity for readability

## 🔧 Build Settings

22. **Add Scene to Build**
    ```
    File → Build Settings
    Add Open Scenes
    MainMenu should be Scene 0
    ```

## 🧪 Final Testing Checklist

- [ ] All buttons clickable and responsive
- [ ] Settings save and load properly
- [ ] Audio sliders affect volume (when audio added)
- [ ] Resolution dropdown works
- [ ] Fullscreen toggle works
- [ ] Exit button closes application in build
- [ ] UI scales properly on different resolutions
- [ ] No console errors
- [ ] Navigation flows smoothly

---

**Total Time Estimate: 3-4 hours**
**Next Steps: Add audio files and implement scene transitions**
