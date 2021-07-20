using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITouchDamage
{

    [SerializeField]
    int TouchDamage
    {
        get;
        set;
    }


    public void OnTriggerEnter(Collider other);

}
