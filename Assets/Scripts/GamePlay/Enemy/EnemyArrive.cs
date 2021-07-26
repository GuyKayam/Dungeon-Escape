using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrive : MonoBehaviour
{

    [SerializeField]
    Transform target;
    [SerializeField]
    float moveSpeed = 6;
    [SerializeField]
    float rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Arrive();
    }

    void Arrive()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;
        float decelerationFactor = distance / 5;
        float speed = moveSpeed * decelerationFactor;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        Vector3 moveVector = direction.normalized * Time.deltaTime * speed;
        transform.position += moveVector;
    }

}
