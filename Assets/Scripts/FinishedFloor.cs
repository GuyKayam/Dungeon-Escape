using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedFloor : MonoBehaviour
{
    public delegate void FinishedFloorTouch();
    public static event FinishedFloorTouch OnFinishedFloor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnFinishedFloor?.Invoke();

        }
    }
}
