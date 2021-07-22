using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDectruct : MonoBehaviour
{

    [SerializeField]
     int destroyTimer = 4;


    public int DestroyTimer
    {
        get { return destroyTimer; }
        set { destroyTimer = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
