using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DoorPositioning
{
    Top,
    Bottom,
    Left,
    Right
}
public class EnteredThroughDoor : MonoBehaviour
{


    [SerializeField]
    DoorPositioning direction;

    public  delegate void PassedThroughDoor(DoorPositioning pos);
    public static event PassedThroughDoor OnRoomMove;


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
            OnRoomMove?.Invoke(direction);
        }

    }


}
