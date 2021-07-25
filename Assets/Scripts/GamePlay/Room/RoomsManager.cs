using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{

   
    GameObject[] rooms;
    [SerializeField]
    GameObject roomManagerPrefab;

    [SerializeField]
    Transform roomsParent;

    [SerializeField]
    GameObject minimapIndicator;

    Vector2 playerDoorPositionMargin;

    int newRoomId;
    int currentRoomId;
    // Start is called before the first frame update
    void Start()
    {
        rooms = new GameObject[roomsParent.childCount];
        GetRooms();
        EnteredThroughDoor.OnRoomMove += EnteredThroughPortal;
        Instantiate(roomManagerPrefab, rooms[0].transform);
        currentRoomId = 0;
    }
    private void OnDestroy()
    {
        EnteredThroughDoor.OnRoomMove -= EnteredThroughPortal;

    }

    void GetRooms()
    {
        for (int i = 0; i < roomsParent.childCount; i++)
        {
            rooms[i] = roomsParent.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public  void EnteredThroughPortal(DoorPositioning doorPosition)
    {
        EnableNewRoom(doorPosition);
        InstnatiateNewRoomManager();
        MoveObjectsToNewRoom(doorPosition);
        SetMiniMapIndicator();
        
        
        //PlayerReference.instance.transform.position =
      //  Instantiate(roomManagerPrefab);
    }

    void EnableNewRoom(DoorPositioning doorPos)
    {
        switch (doorPos)
        {
            case DoorPositioning.Top:
                newRoomId = currentRoomId + 1;
                playerDoorPositionMargin =new Vector2(0,-4);
                break;
            case DoorPositioning.Bottom:
                newRoomId = currentRoomId - 1;
                playerDoorPositionMargin = new Vector2(0, +4);

                break;
            case DoorPositioning.Left:
                newRoomId = currentRoomId - 3;
                playerDoorPositionMargin = new Vector2(7, 0);

                break;
            case DoorPositioning.Right:
                newRoomId = currentRoomId + 3;
                playerDoorPositionMargin = new Vector2(-7, 0);
                
                break;
        }
        rooms[newRoomId].SetActive(true);
        currentRoomId = newRoomId;
    }

   void InstnatiateNewRoomManager()
    {
        Instantiate(roomManagerPrefab, rooms[currentRoomId].transform);

    }

    void MoveObjectsToNewRoom(DoorPositioning pos)
    {
        Vector3 newPostion = rooms[newRoomId].transform.position;
        float cameraYPos = Camera.main.transform.position.y;
        float playerYpos = PlayerReference.instance.transform.position.y;
        float minimapIndicatorYpos = minimapIndicator.transform.position.y;
        PlayerReference.instance.transform.position =new Vector3(newPostion.x+ playerDoorPositionMargin.x, playerYpos,newPostion.z+ playerDoorPositionMargin.y);
        Camera.main.transform.position = new Vector3(newPostion.x, cameraYPos,newPostion.z);
        minimapIndicator.transform.position = new Vector3(newPostion.x, minimapIndicatorYpos, newPostion.z);
    }

    void SetMiniMapIndicator()
    {
        
    }
}
