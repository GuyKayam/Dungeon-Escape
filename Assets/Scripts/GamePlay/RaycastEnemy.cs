using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RaycastEnemy : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    bool isLookingDown;

    [SerializeField]
    float fieldOfViewDegrees=50;

    [SerializeField]
    float lookDistance=5;
    #endregion

    #region Line Renderer Animations
    [SerializeField]
    Texture[] animationTextures;

    [SerializeField]
    float fps = 30f;

    float oneDivideByFps;
    int animationStep;
    float fpsCounter;
    #endregion

    #region Privates
    float zPos;
    float xPos;
    RaycastHit hit;
    LineRenderer lineRenderer;

    AudioSource audioSource;
    float soundActivationDelay=5;
    float lastTimeSoundPlayed;
    #endregion

    #region Logic
    public void Start()
    {
        oneDivideByFps = 1f / fps;
        zPos = transform.position.z;
        if (isLookingDown)
        {
            zPos = -1 * zPos;
        }


        lineRenderer = gameObject.GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
       if(CanSeePlayer())
        {
            PlayAudioSourceSound();
        }
        ShowRayRange();

        HandleLineAnimation();
    }

    protected bool CanSeePlayer()
    {
        
        Vector3 rayDirection = playerPrefab.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, lookDistance,mask))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.green);
                return true;
            }
        }
        return false;
    }
    public void ShowRayRange()
    {
        List<Vector3> pos = new List<Vector3>();

        pos.Add(new Vector3(transform.position.x - 2.4f, 0.5f,lookDistance+ zPos)) ;
        pos.Add(new Vector3(transform.position.x + 2.4f, 0.5f, lookDistance + zPos));
        pos.Add(new Vector3(transform.position.x, 0.5f, zPos)); ;
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

    void HandleLineAnimation()
    {
        fpsCounter += Time.deltaTime;
        if (fpsCounter >= oneDivideByFps)
        {
            animationStep++;
            if (animationStep == animationTextures.Length)
                animationStep = 0;

            lineRenderer.material.mainTexture =animationTextures[animationStep];

            fpsCounter = 0f;
        }

    }

}
#endregion




