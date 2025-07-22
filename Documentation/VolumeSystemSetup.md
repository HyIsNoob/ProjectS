# Hướng Dẫn Thiết Lập Hệ Thống Volume Mới

## 1. Cấu Trúc Script Đã Tạo

### MenuController.cs (Đã cập nhật)
- Hỗ trợ 3 loại volume: Master, Music, Sound
- Tương thích ngược với code cũ
- Có thêm phương thức reset về mặc định

### VolumeController.cs (Mới)
- Script chuyên dụng cho quản lý volume
- Linh hoạt, dễ mở rộng
- Tự động lưu/load settings

### AudioManager.cs (Mới)
- Quản lý tổng thể âm thanh của game
- Singleton pattern
- Hỗ trợ music, sound effects, UI sounds

## 2. Cách Thiết Lập Trong Unity

### Bước 1: Tạo Audio Mixer
1. Right-click trong Project → Create → Audio Mixer
2. Đặt tên "MainAudioMixer"
3. Tạo các Groups:
   - Master (có sẵn)
   - Music (con của Master)
   - Sound (con của Master)
4. Thêm các Exposed Parameters:
   - MasterVolume (cho Master group)
   - MusicVolume (cho Music group)
   - SoundVolume (cho Sound group)

### Bước 2: Setup UI Canvas
```
Canvas
├── VolumePanel
│   ├── MasterVolumeSection
│   │   ├── MasterVolumeLabel (Text)
│   │   ├── MasterVolumeSlider (Slider)
│   │   └── MasterVolumeValue (Text)
│   ├── MusicVolumeSection
│   │   ├── MusicVolumeLabel (Text)
│   │   ├── MusicVolumeSlider (Slider)
│   │   └── MusicVolumeValue (Text)
│   ├── SoundVolumeSection
│   │   ├── SoundVolumeLabel (Text)
│   │   ├── SoundVolumeSlider (Slider)
│   │   └── SoundVolumeValue (Text)
│   ├── ApplyButton (Button)
│   ├── ResetButton (Button)
│   └── ConfirmationPrompt (GameObject)
```

### Bước 3: Thiết Lập VolumeController
1. Thêm VolumeController script vào GameObject
2. Assign các UI elements:
   - masterVolume.volumeTextValue → MasterVolumeValue
   - masterVolume.volumeSlider → MasterVolumeSlider
   - masterVolume.mixerGroup → Master Group từ Audio Mixer
   - Tương tự cho Music và Sound
3. Assign confirmationPrompt GameObject

### Bước 4: Setup Button Events
- ApplyButton.onClick → VolumeController.ApplyAllSettings()
- ResetButton.onClick → VolumeController.ResetAllToDefaults()

## 3. Cách Sử Dụng Trong Code

### Từ Script Khác
```csharp
// Lấy reference đến VolumeController
VolumeController volumeController = FindObjectOfType<VolumeController>();

// Đặt volume
volumeController.SetMasterVolume(0.8f);
volumeController.SetMusicVolume(0.6f);
volumeController.SetSoundVolume(0.9f);

// Lấy giá trị volume hiện tại
float currentMaster = volumeController.GetMasterVolume();
```

### Từ AudioManager
```csharp
// Play music với volume setting
AudioManager.Instance.PlayMusic(backgroundMusic);

// Play sound effect với volume setting
AudioManager.Instance.PlaySound(buttonClickSound);
```

## 4. Mở Rộng Thêm Volume Types

Để thêm volume mới (ví dụ: Voice Volume):

1. Trong VolumeController.cs, thêm:
```csharp
public VolumeSettings voiceVolume = new VolumeSettings 
{ 
    playerPrefsKey = "VoiceVolume", 
    mixerParameter = "VoiceVolume",
    defaultValue = 1f 
};
```

2. Cập nhật InitializeAllVolumes():
```csharp
voiceVolume.Initialize();
```

3. Thêm public method:
```csharp
public void SetVoiceVolume(float volume)
{
    voiceVolume.SetVolume(volume);
}
```

4. Cập nhật ApplyAllSettings() và ResetAllToDefaults()

## 5. Lưu Ý Quan Trọng

### Audio Mixer Setup
- Đảm bảo các Exposed Parameters có tên chính xác
- Music và Sound groups phải là con của Master group
- Kiểm tra routing của AudioSources đến đúng groups

### UI Setup
- Slider range: 0 → 1
- Slider value được tự động sync với volume
- Text hiển thị phần trăm (0% → 100%)

### Performance
- Chỉ có 1 VolumeController trong scene
- Settings được tự động lưu vào PlayerPrefs
- Load settings khi Start()

## 6. Testing Checklist

- [ ] Master Volume ảnh hưởng tất cả âm thanh
- [ ] Music Volume chỉ ảnh hưởng nhạc nền
- [ ] Sound Volume chỉ ảnh hưởng sound effects
- [ ] UI hiển thị đúng giá trị phần trăm
- [ ] Settings được lưu sau khi Apply
- [ ] Settings được load khi khởi động lại
- [ ] Reset về default hoạt động đúng
- [ ] Confirmation message hiển thị sau Apply
