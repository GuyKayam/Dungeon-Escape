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
        gameObject.GetComponent<IDeath>().OnDeath += InstantiateNewObject;
    }


    void InstantiateNewObject()
    {
        Instantiate(changeToThis, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);



    }
}
