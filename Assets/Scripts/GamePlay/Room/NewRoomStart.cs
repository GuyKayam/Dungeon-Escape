using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class NewRoomStart : MonoBehaviour
{
    GameObject room;

    Transform doorsParent;
    Transform enemiesParent;

    [SerializeField]
    List<BasicDeath> enemies;

    [SerializeField]
     List<EnteredThroughDoor> doors;

    [SerializeField]
    CheckRoomClear checkRoomClearScript;
    [SerializeField]
    RoomCleared roomClearedScript;

    public List<BasicDeath> Enemies
    {
        get { return enemies; }
    }


    // Start is called before the first frame update
    void Start()
    {
        room = transform.parent.gameObject;
        if (room.transform.childCount > 0)
        {
            enemiesParent = room.transform.GetChild(2);
            doorsParent = room.transform.GetChild(3);

        }
        GetEnemiesInRoom(enemiesParent);
        GetDoorsInRoom(doorsParent);
        roomClearedScript.GetDoorsAndCacheRef(doorsParent);
        if (!DoesRoomHaveEnemies())
        {
            checkRoomClearScript.FinishRoomNow();
           
        }
 
        checkRoomClearScript.SubscribeToDeathEvents(enemies);

    }


    void GenerateDoors()
    {

    }

    [ContextMenu("Get All Enemies In Room")]
    void GetDoorsInRoom(Transform parent)
    {
        doors = parent.GetComponentsInChildren<EnteredThroughDoor>().Where(t => t.gameObject.activeSelf == true).ToList();
    }


    [ContextMenu("Get All Enemies In Room")]
    void GetEnemiesInRoom(Transform parent)
    {
        enemies = parent.GetComponentsInChildren<BasicDeath>().Where(t=> t.gameObject.activeSelf==true).ToList();
     
    }

    bool DoesRoomHaveEnemies()
    {
        if (enemies.Count == 0)
        {
            return false;
        }
        else
            return true;
    }




}
