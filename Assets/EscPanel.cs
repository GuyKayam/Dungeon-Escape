using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscPanel : MonoBehaviour
{
    [SerializeField]
    GameObject escPanel;

    bool isTurnedOn=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void hehe()
    {
        Debug.Log("");
    }


    public void ReturnToGame()
    {
        escPanel.SetActive(false);
        GameSceneManager.Instance.ResumeGame();
    }

    public void ReturnToWelcomeScreen()
    {
        GameSceneManager.Instance.ReturnToWelcomeScreen();
    }


    public void ExitToDesktop()
    {
        GameSceneManager.Instance.ExitToDesktop();
    }

   public void ChangeEscPanelState()
    {
         isTurnedOn = !isTurnedOn;
        if (isTurnedOn)
        {
            GameSceneManager.Instance.ResumeGame();
            escPanel.SetActive(false);
            return;
        }
        GameSceneManager.Instance.PauseGame();
        escPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
