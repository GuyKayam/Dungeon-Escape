using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickupHandler : MonoBehaviour
{

    PlayerBombsHandler playerBombScript;
    // Start is called before the first frame update
    void Start()
    {
        playerBombScript= PlayerReference.instance.GetComponent<PlayerBombsHandler>();   
    }

     void OnTriggerEnter(Collider other)
    {
        playerBombScript.ChangeBombsAmount(1);
    }

}
