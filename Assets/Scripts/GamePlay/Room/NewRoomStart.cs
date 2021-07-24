using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class NewRoomStart : MonoBehaviour
{
    [SerializeField]
    GameObject doorPrefab;

    [SerializeField]
    GameObject enemiesParent;

    [SerializeField]
    List<BasicDeath> enemies;

    [SerializeField]
    List<GameObject> doors;

    [SerializeField]
    CheckRoomClear checkRoomClearScript;

    public List<BasicDeath> Enemies
    {
        get { return enemies; }
    }


    // Start is called before the first frame update
    void Start()
    {
        GetEnemiesInRoom();
        checkRoomClearScript.SubscribeToDeathEvents(enemies);
    }


    void GenerateDoors()
    {

    }

    [ContextMenu("Get All Enemies In Room")]
    void GetDoorsInRoom()
    {
/*        doors = enemiesParent.GetComponentsInChildren<BasicDeath>().Where(t => t.gameObject.activeSelf == true).ToList();
        if (enemies.Count == 0)
        {
            checkRoomClearScript.FinishRoomNow();
        }*/
    }


    [ContextMenu("Get All Enemies In Room")]
    void GetEnemiesInRoom()
    {
        enemies = enemiesParent.GetComponentsInChildren<BasicDeath>().Where(t=> t.gameObject.activeSelf==true).ToList();
       
        //if we have no enemies, we end the room immediately (opening doors and portals)
        if (enemies.Count==0)
        {
            checkRoomClearScript.FinishRoomNow();
        }
      
    }




}
