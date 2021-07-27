using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : MonoBehaviour
{
    [SerializeField]
     Transform target;
    [SerializeField]
    float moveSpeed = 6;
    [SerializeField]
    float rotationSpeed = 1;
    [SerializeField]
    private int minDistance = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }

    void Seek()
    {    //slide 

        int neighborCount = 0;
        Vector3 force = new Vector3(0, 0, 0);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.GetComponent<EnemySeek>() != null)
            {
                force.x += collider.transform.position.x - transform.position.x;
                force.z += collider.transform.position.z - transform.position.z;
                neighborCount++;
            }
        }
        if (neighborCount != 0)
        {
            force.x /= neighborCount;
            force.z /= neighborCount;

            force = Vector3.Scale(force, new Vector3(-1, -1, -1));
        }

        force.Normalize();
        force = Vector3.Scale(force, new Vector3(2, 2, 2));



        Vector3 direction = target.position - transform.position;
        direction = direction + force;

        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }
}
