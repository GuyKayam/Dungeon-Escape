using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject[] panels;
    int currentPanelOpen = 0;

    SettingsPanel settingsScript;

    // Start is called before the first frame update
    void Start()
    {
         settingsScript = panels[1].GetComponent<SettingsPanel>();
    }
    public void CloseButtonPressed()
    {
        Application.Quit();
    }

    public void OpenScreen(int panelIndex)
    {
        panels[currentPanelOpen].SetActive(false);
        currentPanelOpen = panelIndex;
        panels[panelIndex].SetActive(true);

    }

    public void SwitchSoundState()
    {
        settingsScript.ChangeAudioState();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstFloor");

    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
