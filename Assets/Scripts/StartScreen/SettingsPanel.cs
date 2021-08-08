using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SettingsPanel : MonoBehaviour
{

    #region Private Varibles
    bool isAudioPlaying = false;
    #endregion


    #region SerializeField
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    Text audioBtnText;

    [SerializeField]
    Slider soundVolumeSlider;
    #endregion


    #region Methods
    private void Awake()
    {
     if(SoundManager.Instance.IsPlayingMusic)
        {
            audioBtnText.text = "Sound ON";
        }
        else
        {
            audioBtnText.text = "Sound OFF";
        }
        soundVolumeSlider.value = SoundManager.Instance.MusicVolume;
    }


    public void ChangeAudioState()
    {
       if(SoundManager.Instance.ChangeMusicState())
        {
            audioBtnText.text = "Sound ON";
        }
        else
        {
            audioBtnText.text = "Sound OFF";
        }
    }


    public void ChangeVolumeCalled(Slider slider)
    {
        SoundManager.Instance.ChangeMusicVolume(slider.value);
    } 


   
    #endregion

}
