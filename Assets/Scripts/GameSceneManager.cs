using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : AutoCleanUpSingleton<GameSceneManager>
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    void Awake()
    {
        base.Awake();
        FinishedFloor.OnFinishedFloor += MoveToNextFloor;
    }

    private void OnDestroy()
    {
        FinishedFloor.OnFinishedFloor -= MoveToNextFloor;

    }

    void MoveToNextFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToWelcomeScreen()
    {
        SceneManager.LoadScene(0);

    }

    public void ExitToDesktop()
    {
        Application.Quit();

    }

     public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public  void ResumeGame()
    {
        Time.timeScale = 1;
    }



}
