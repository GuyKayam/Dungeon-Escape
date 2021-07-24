using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCleanUpSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    _instance = new GameObject("Intstance of" + typeof(T)).AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    // Start is called before the first frame update
    protected void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject); //prevents duplicates
    }

    // Update is called once per frame
    void Update()
    {

    }
}
