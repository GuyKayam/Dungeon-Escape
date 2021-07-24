using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] rooms;
    [SerializeField]
    GameObject roomPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(roomPrefab,rooms[0].transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public  void EnteredThroughPortal(int id)
    {
        Instantiate(roomPrefab);
    }
}
