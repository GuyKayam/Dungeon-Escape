using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameSceneManager : AutoCleanUpSingleton<GameSceneManager>
    {
        // Declare any public variables that you want to be able 
        // to access throughout your scene
        [SerializeField]
        public PlayerReference player;
        void Awake()
        {
        base.Awake();
        }

    }
