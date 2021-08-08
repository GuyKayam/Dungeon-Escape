using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : AutoCleanUpSingleton<SoundManager>
{
    #region Private Varibles
    bool shouldPlayMusic;
    bool shouldPlaySoundEffects;
    float musicVolume;
    AudioSource audioSource;
    #endregion

    #region Properties

    public bool IsPlayingMusic
    {
        get { return shouldPlayMusic; }
        set { shouldPlayMusic = value; }
    }

   

    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }



    #endregion

    #region Methods
    private void Awake()
    {
        base.Awake();
        audioSource = this.GetComponent<AudioSource>();
        if (audioSource == null)
        {
#if UNITY_EDITOR
            Debug.Log("No Audio Source Found!");
#endif
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("musicmusicVolume");
            audioSource.volume = musicVolume;

            if (PlayerPrefs.GetInt("shouldPlayMusic") == 1)
            {
                IsPlayingMusic = true;
                PlayMusic();
            }
            else
            {
                IsPlayingMusic = false;
            }
        }


    }

    public void ChangeMusicVolume(float musicVolumeValue)
    {
        if (audioSource != null && (musicVolumeValue >= 0))
        {
            musicVolume = musicVolumeValue;
            audioSource.volume = musicVolume;

        }
        PlayerPrefs.SetFloat("musicmusicVolume", musicVolume);

    }

    void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Changes the main music to state to Play or Pause, while saving the choice in playerprefs, returns true if playing,false if paused
    /// </summary>
    public bool ChangeMusicState()
    {
        if (audioSource != null)
        {
            if (IsPlayingMusic)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }

        }
        IsPlayingMusic = !IsPlayingMusic;
        PlayerPrefs.SetInt("shouldPlayMusic", shouldPlayMusic ? 1 : 0);
        return IsPlayingMusic;
    } 
    #endregion
}
