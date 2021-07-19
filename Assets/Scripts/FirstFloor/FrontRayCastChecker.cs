using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontRayCastChecker : MonoBehaviour
{
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    float fieldOfViewDegrees=50;

    [SerializeField]
    float lookDistance=5;


    public void Update()
    {
        Debug.Log(CanSeePlayer());
    }

    protected bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = playerPrefab.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, lookDistance))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.green);
                Debug.Log(hit.transform.name);
            }
        }

        return false;
    }
}





