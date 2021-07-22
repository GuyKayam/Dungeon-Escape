using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnteredThroughDoor : MonoBehaviour
{
    [SerializeField]
    UnityEvent EnteredTroughDoor;
    // Start is called before the first frame update
    void Start()
    {
        if (EnteredTroughDoor == null)
            EnteredTroughDoor = new UnityEvent();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
