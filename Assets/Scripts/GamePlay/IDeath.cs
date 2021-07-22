using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDeathHandler();


interface IDeath
{
    public void Death();
    event OnDeathHandler OnDeath;
}