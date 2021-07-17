using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHandler : BulletLogic
{
    [SerializeField]
    Player playerScript;

    protected override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerScript.ChangeHealth(-1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
