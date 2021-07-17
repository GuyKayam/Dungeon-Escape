using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GenerationObject :MonoBehaviour
{
    public abstract string Name { get; }

}

public abstract class AbstractFactory : MonoBehaviour
{

    public bool IsIntialized { get; set; } = false;

    public abstract void IntializeFactory(Type type);
    public abstract GenerationObject GenerateObjects(string ObjectTypeByName);
    public abstract IEnumerable<GenerationObject> GetObjectsName();

}


