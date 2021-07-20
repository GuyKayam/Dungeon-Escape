using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathChangeObject : MonoBehaviour
{
    [SerializeField]
    GameObject changeToThis;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<IHealth>().OnHealthReachedZero += ChangeObject;
    }


    void ChangeObject()
    {

        Instantiate(changeToThis, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);



    }
}
