using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnteredThroughDoor : MonoBehaviour
{
    [SerializeField]
    UnityEvent enteredThroughDoor;
    // Start is called before the first frame update
    void Start()
    {
        if (enteredThroughDoor == null)
            enteredThroughDoor = new UnityEvent();

    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
