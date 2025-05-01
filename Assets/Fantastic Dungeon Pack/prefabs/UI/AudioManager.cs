using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource uiSource;

    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip clickSound;
    public AudioClip pauseSound;
    public AudioClip winSound;
    public AudioClip ambienceLoop;

    public static AudioManager Instance;

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

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayUISFX(AudioClip clip)
    {
        if (clip != null)
        {
            uiSource.Stop();
            uiSource.clip = clip;
            uiSource.loop = false;
            uiSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.loop = true;
        sfxSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

    public void StopAmbience()
    {
        if (sfxSource.isPlaying)
            sfxSource.Stop();
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
    }

    public void ResumeMusic()
    {
        if (musicSource.clip != null)
            musicSource.UnPause();
    }
}
