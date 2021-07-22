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

        Vector3 direction = target.position - transform.position;

        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }
}
