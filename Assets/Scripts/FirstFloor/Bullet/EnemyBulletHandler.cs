using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHandler : BulletLogic
{
    [SerializeField]
    PlayerStats playerScript;

    protected override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
         //   playerScript.ChangeHealth(1);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    
}
