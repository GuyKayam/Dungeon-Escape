using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ChangedHealthHandler(int change);
public delegate void HealthReachedZero();



interface IHealth
{
    [SerializeField]
    int StartHealth
    {
        get;
        set;
    }

    int CurrentHealth
    {
        get;
        set;
    }


    public void ChangeHealth(int changeInHP);
    event HealthReachedZero OnHealthReachedZero;
    event ChangedHealthHandler OnHealthChanged;

}


