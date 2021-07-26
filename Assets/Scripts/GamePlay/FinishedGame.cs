using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedGame : MonoBehaviour
{

    public float speed = 1f;

    bool didTrigger;
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform mainCamera;

    [SerializeField]
    GameObject winPanel;

    float startTime;
    Vector3 finalPos;

    PlayerMovementHandler playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
     playerMovementScript=   PlayerReference.instance.GetComponent<PlayerMovementHandler>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Camera.main.orthographic = false;
        didTrigger = true;
        startTime = Time.time;
        playerMovementScript.DisableMovement = true;

    }



    void Update()
    {
        if (didTrigger)
        {
            
            finalPos = new Vector3(target.position.x, target.position.y + 1, target.position.z - 1);

            mainCamera.position = Vector3.Lerp(mainCamera.position, finalPos, (Time.time-startTime)*speed);
            mainCamera.LookAt(target);

            if ((mainCamera.position - finalPos).magnitude <= 1)
            {
                FinishedLerping();
               
                
            }
        }




    }

   void FinishedLerping()
    {
        didTrigger = false;
        winPanel.SetActive(true);
    }
}
