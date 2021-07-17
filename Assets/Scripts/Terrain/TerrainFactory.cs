using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainFactory : CommonFactory
{
    [SerializeField]
    GameObject[] terrainObjects;  
    public override GenerationObject GenerateObjects(string ObjectTypeByName)
    {
        foreach(ObjectsByName)




        if (ObjectsByName.ContainsKey(ObjectTypeByName))
        {
            Debug.Log(ObjectTypeByName);
            return null;
        }
        return null;
    }


}


