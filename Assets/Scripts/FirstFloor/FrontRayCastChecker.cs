using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
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

    float zPos;
    LineRenderer lineRenderer;
    [SerializeField]
     Material mat2;

    AudioSource audioSource;
    float soundActivationDelay=5;
    float lastTimeSoundPlayed;
    public void Start()
    {
        zPos = transform.position.z;
         lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material = mat2;
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        CanSeePlayer();
        ShowRayRange();
    }

    protected bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = playerPrefab.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, lookDistance,mask))
            {
                PlayAudioSourceSound();
                Debug.DrawRay(transform.position, rayDirection, Color.green); 
            }
        }

        return false;
    }
    public void ShowRayRange()
    {

        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(-3, 0.5f,lookDistance+ zPos)) ;
        pos.Add(new Vector3(3, 0.5f, lookDistance + zPos));
        pos.Add(new Vector3(0, 0.5f, zPos)); ;
        lineRenderer.SetPositions(pos.ToArray());
    }

    void PlayAudioSourceSound()
    {


            if (Time.time >= lastTimeSoundPlayed + soundActivationDelay)
            {
                audioSource.Play();
                lastTimeSoundPlayed = Time.time;

            }
        


    }

}





