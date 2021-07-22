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
    GameObject testEnemy;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateDoors()
    {

    }

    [ContextMenu("Get All Enemies In Room")]
    void GetEnemiesInRoom()
    {
        enemies = enemiesParent.GetComponentsInChildren<BasicDeath>().Where(t=> t.gameObject.activeSelf==true).ToList();
        if (enemies.Count==0)
        {
            checkRoomClearScript.FinishRoomNow();
        }
    }

    
}
