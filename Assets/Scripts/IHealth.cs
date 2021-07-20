using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ChangedHealthHandler();

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
    event ChangedHealthHandler OnHealthReachedZero;

}


