using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGameObject : MonoBehaviour
{
 
    [SerializeField]
    Transform target;
    [SerializeField]
    float rotationSpeed = 1;


    Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        Seek();
    }


    void Seek()
    {    //slide 

        direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
}
