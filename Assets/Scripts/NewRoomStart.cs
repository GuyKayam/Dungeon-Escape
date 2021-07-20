using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class NewRoomStart : MonoBehaviour
{

    [SerializeField]
    GameObject enemiesParent;

    [SerializeField]
    List<BasicDeath> enemies;



    public List<BasicDeath> Enemies
    {
        get { return enemies; }
    }


    // Start is called before the first frame update
    void Start()
    {
        GetEnemiesInRoom();
        GetComponent<CheckRoomClear>().SubscribeToDeathEvents(enemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [ContextMenu("Get All Enemies In Room")]
    void GetEnemiesInRoom()
    {
        enemies = enemiesParent.GetComponentsInChildren<BasicDeath>().ToList();
    }


}
