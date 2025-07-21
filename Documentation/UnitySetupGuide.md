# Unity Project Setup Guide - ProjectS

## 🚀 Quick Start (After Installing Unity)

### 1. Create New Project
1. Mở Unity Hub
2. Click "New Project"
3. Chọn template "3D (URP)" - Universal Render Pipeline
4. Project Name: `ProjectS`
5. Location: `d:\fileluu\Synapse\ProjectS\UnityProject`
6. Click "Create Project"

### 2. Setup Project Structure
Trong Unity Project window, tạo các thư mục:

```
Assets/
├── _ProjectS/
│   ├── Art/
│   │   ├── Materials/
│   │   ├── Models/
│   │   ├── Textures/
│   │   └── Animations/
│   ├── Audio/
│   │   ├── Music/
│   │   ├── SFX/
│   │   └── Voice/
│   ├── Prefabs/
│   │   ├── Characters/
│   │   ├── Environment/
│   │   └── UI/
│   ├── Scenes/
│   ├── Scripts/
│   │   ├── Player/
│   │   ├── Enemy/
│   │   ├── Managers/
│   │   └── UI/
│   └── UI/
└── ThirdParty/
    └── (Downloaded assets)
```

### 3. Initial Scene Setup
1. Tạo scene mới: `MainGame.unity` trong `Assets/_ProjectS/Scenes/`
2. Delete default Main Camera và Directional Light
3. Tạo empty GameObject tên "GameManager"
4. Tạo empty GameObject tên "Player"
5. Tạo empty GameObject tên "Environment"

### 4. Basic Terrain
1. Window → Terrain → Create Terrain
2. Đặt terrain dưới Environment GameObject
3. Scale terrain phù hợp (khoảng 100x100)
4. Dùng terrain tools để tạo đồi núi cơ bản

### 5. Lighting Setup
1. Window → Rendering → Lighting
2. Environment tab:
   - Skybox Material: Default-Skybox
   - Environment Lighting: Gradient
   - Ambient Color: Màu xanh đậm cho forest
3. Tạo Directional Light cho sun
4. Setup day/night cycle sau

### 6. Player Setup
1. Tạo Capsule làm player placeholder
2. Add Rigidbody component
3. Add Character Controller component
4. Position ở giữa terrain

### 7. Camera Setup
1. Tạo Main Camera
2. Position phía sau và trên player
3. Rotate để nhìn xuống player
4. Add camera follow script sau

### 8. Package Dependencies
Cài các packages cần thiết:
- Window → Package Manager
- Install:
  - Universal RP
  - ProBuilder (cho level design)
  - Cinemachine (cho camera)
  - Input System (cho controls)

## 📝 First Scripts to Create

### Player Controller (BasicPlayerMovement.cs)
```csharp
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    
    private CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        // Basic movement code sẽ implement sau
    }
}
```

### Game Manager (GameManager.cs)
```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game State")]
    public bool isDay = true;
    public float dayDuration = 300f; // 5 minutes
    
    void Awake()
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
    
    // Day/night cycle sẽ implement sau
}
```

## ⚙️ Unity Settings Recommendations

### Project Settings
1. Edit → Project Settings
2. Player:
   - Company Name: "Synapse"
   - Product Name: "ProjectS"
   - Version: "0.1.0"
3. Quality:
   - Set default quality to "High"
4. Input System:
   - Use new Input System

### Graphics Settings
1. Edit → Project Settings → Graphics
2. Scriptable Render Pipeline: URP Asset
3. URP Settings:
   - Rendering → HDR: Enabled
   - Post-processing: Enabled

## 🎯 Next Steps After Setup
1. Test basic scene runs without errors
2. Implement basic player movement
3. Add simple forest environment
4. Create first Watcher prototype
5. Setup version control with Git

---
**Estimated Setup Time**: 2-3 hours for beginners
