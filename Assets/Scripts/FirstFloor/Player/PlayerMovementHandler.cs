using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{

    [SerializeField]
    float playerSpeed = 4;

    Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void OnMoveInput(float vertical, float horizontal)
    {
        playerRigidBody.velocity = new Vector3(vertical * playerSpeed, horizontal * playerSpeed, 0);
    }
}
