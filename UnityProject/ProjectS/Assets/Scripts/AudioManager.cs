using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip clickBtnSounds;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
