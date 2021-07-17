using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHandler : BulletLogic
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, DestroyTimer);

    }


    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

        // Update is called once per frame
        void Update()
    {
        //
    }

    protected override void OnTriggerEnter(Collider other)
    {
    }
}