using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CommonFactory : AbstractFactory
{

    protected static Dictionary<string, Type> ObjectsByName;
    
    
    public override void IntializeFactory(Type objectType)
    {
        if (IsIntialized)
            return;

        var ObjectTypes = Assembly.GetAssembly(objectType).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(objectType));

        ObjectsByName = new Dictionary<string, Type>();

        foreach (var type in ObjectTypes)
        {
            var tempObject = Activator.CreateInstance(type) as GenerationObject;
            ObjectsByName.Add(tempObject.Name, type);

        }

    }
    public override GenerationObject GenerateObject(string ObjectTypeByName)
    {
        if (ObjectsByName.ContainsKey(ObjectTypeByName))
        {
            Type type = ObjectsByName[ObjectTypeByName];
            var genobject = Activator.CreateInstance(type) as GenerationObject;
            return genobject;

        }
        return null;
    }

    public override IEnumerable<GenerationObject> GetObjectsName()
    {
        throw new System.NotImplementedException();
    }


}
