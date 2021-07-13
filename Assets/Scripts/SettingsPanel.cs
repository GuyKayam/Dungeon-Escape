using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SettingsPanel : MonoBehaviour
{
    bool isAudioPlaying=false;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Text audioBtnText;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeAudioState()
    {
        if (isAudioPlaying)
        {
            isAudioPlaying = false;
            audioSource.Pause();
            audioBtnText.text = "Sound OFF";
        }
        else
        {
            isAudioPlaying = true;
            audioSource.PlayDelayed(0.5f);
            audioBtnText.text = "Sound ON";

        }
    }





    public void ChangeVolume(Slider slider)
    {
        audioSource.volume = slider.value;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
