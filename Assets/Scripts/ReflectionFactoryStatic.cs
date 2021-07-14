using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReflectionFactoryStatic : MonoBehaviour
{
    public abstract void Process();
    public bool isIntialized { get; set; } = false;

    public abstract void IntializeFactory();
}


