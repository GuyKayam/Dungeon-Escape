using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{

    [SerializeField]
    float playerSpeed = 4;

    Rigidbody playerRigidBody;

    bool disableMovement;


    public bool DisableMovement
    {
        get { return disableMovement; }
        set { disableMovement = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void OnMoveInput(float vertical, float horizontal)
    {
        if (!disableMovement)
        {
            playerRigidBody.velocity = new Vector3(vertical * playerSpeed, 0, horizontal * playerSpeed);
        }
        else
        {
            playerRigidBody.velocity = new Vector3(0, 0, 0);

        }
    }
}
