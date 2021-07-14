using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHandler : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float destroyTimer=5;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, destroyTimer);

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
}
