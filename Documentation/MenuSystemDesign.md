# Menu System Design - ProjectS

## 🎮 Menu Flow Design

### **Menu Hierarchy**
```
Main Menu
├── New Game
├── Load Game  
├── Settings
│   ├── Graphics
│   ├── Audio
│   └── Controls
├── Credits
└── Exit Game

In-Game Menu (ESC)
├── Resume
├── Settings
├── Save Game
├── Main Menu
└── Exit Game
```

## 🎨 UI Design Specifications

### **Art Style**
- **Theme**: Dark, horror-inspired
- **Colors**: Dark grays, deep blues, blood red accents
- **Font**: Creepy/gothic style for titles, clean for body text
- **Background**: Forest silhouette with fog effect
- **Audio**: Atmospheric forest sounds, subtle horror ambience

### **Screen Layouts**

#### **Main Menu**
```
[Background: Dark forest scene]
                ProjectS
              [Studio Synapse]

              [ NEW GAME ]
              [ LOAD GAME ]
              [ SETTINGS ]
              [ CREDITS ]
              [ EXIT GAME ]

    [Version 0.1.0]        [Audio Toggle]
```

#### **Settings Menu**
```
              SETTINGS
    
    Graphics          Audio          Controls
    ├ Quality: High   ├ Master: 80%   ├ Forward: W
    ├ Resolution      ├ Music: 70%    ├ Back: S  
    ├ Fullscreen: ✓   ├ SFX: 90%      ├ Left: A
    ├ V-Sync: ✓       └ Voice: 80%    ├ Right: D
    └ Anti-alias                      └ Run: Shift

              [ APPLY ]  [ CANCEL ]
```

## 🔧 Technical Implementation

### **Required Scripts**
1. **MenuManager.cs** - Main menu controller
2. **SettingsManager.cs** - Settings persistence
3. **AudioManager.cs** - Audio control
4. **SceneTransition.cs** - Scene loading with effects
5. **SaveSystem.cs** - Save/Load functionality

### **Required Scenes**
- **MainMenu.unity** - Main menu scene
- **GameplayScene.unity** - Main game scene
- **LoadingScene.unity** - Loading transition

### **UI Components Needed**
- Canvas với Camera Overlay
- Button components với hover effects
- Slider cho audio settings
- Dropdown cho graphics settings
- Image components cho background
- Text components cho labels

## 📝 Implementation Steps

### **Phase 1: Basic Menu Structure**
1. Create MainMenu scene
2. Setup Canvas và UI layout
3. Create basic buttons (New Game, Exit)
4. Implement scene transition
5. Add basic styling

### **Phase 2: Settings System**
1. Create Settings submenu
2. Implement audio controls
3. Add graphics settings
4. Save/load settings to PlayerPrefs
5. Apply settings functionality

### **Phase 3: Polish & Effects**
1. Add background animations
2. Button hover/click effects
3. Sound effects for UI
4. Loading screen transitions
5. Menu music integration

## 🎵 Audio Requirements

### **Menu Music**
- Atmospheric, dark ambient track
- Loop seamlessly
- Volume controllable
- Fade in/out transitions

### **Sound Effects**
- Button hover sound (subtle)
- Button click sound
- Menu open/close sounds
- Error notification sound

## 📱 Assets Needed

### **Graphics**
- Background forest image (1920x1080)
- Button normal/hover/pressed states
- Logo/title graphic
- UI panels and frames
- Loading spinner/animation

### **Audio**
- Menu background music (.ogg format)
- UI sound effects (.wav format)
- Optional: Voice-over for title

## 🔄 State Management

### **Game States**
```csharp
public enum GameState
{
    MainMenu,
    InGame,
    Paused,
    Settings,
    Loading
}
```

### **Menu States**
```csharp
public enum MenuState
{
    Main,
    Settings,
    Graphics,
    Audio,
    Controls,
    Credits
}
```

## 💾 Save System Integration

### **Settings to Save**
- Graphics quality
- Resolution
- Audio volumes
- Key bindings
- Language preference

### **Game Data to Save**
- Player progress
- Current scene
- Inventory state
- Story flags

## 📋 Testing Checklist

### **Functionality Tests**
- [ ] All buttons responsive
- [ ] Scene transitions work
- [ ] Settings save/load properly
- [ ] Audio controls function
- [ ] Resolution changes work
- [ ] Game exits properly

### **UI/UX Tests**
- [ ] Text is readable
- [ ] Buttons have clear hover states
- [ ] Navigation is intuitive
- [ ] Loading times acceptable
- [ ] No UI overlapping issues

### **Horror Theme Tests**
- [ ] Atmosphere fits game concept
- [ ] Audio enhances mood
- [ ] Visual style consistent
- [ ] Immersion not broken

---

**Priority**: High - Core foundation for game
**Estimated Time**: 1-2 weeks
**Dependencies**: Unity project setup complete
**Next Task**: Player controller system
