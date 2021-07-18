using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomySteering : MonoBehaviour
{
    public enum AIState { Idle, Seek, Arrive, Pursuit, Evade }

    public Transform target;
    public float moveSpeed = 6;
    public float rotationSpeed = 1;
    private int minDistance = 2;
    private int safeDistance = 60;
    public AIState currentState;

    void Update()
    {
        switch (currentState)
        {
            case AIState.Idle:
                break;
            case AIState.Seek:
                Seek();
                break;
            case AIState.Arrive:
                Arrive();
                break;
            case AIState.Pursuit:
              //  Pursuit();
                break;
            case AIState.Evade:
                Evade();
                break;
        }
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

/*    void Pursuit()
    {
        int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<MoveScript>().instantVelocity;
        Vector3 targetFuturePosition = target.transform.position + (targetSpeed * iterationAhead);
        Vector3 direction = targetFuturePosition - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }*/

    void Evade()
    {
     /*   int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<MoveScript>().instantVelocity;
        Vector3 targetFuturePosition = target.position + (targetSpeed * iterationAhead);
        Vector3 direction = transform.position - targetFuturePosition;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude < safeDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }*/
    }
}


