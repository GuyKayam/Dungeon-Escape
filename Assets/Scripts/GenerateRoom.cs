using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
    [SerializeField]
    TerrainFactory terrainFactoryScript;

    [SerializeField]
    AbstractFactory[] abstactFactory;
    // Start is called before the first frame update
    void Start()
    {
        terrainFactoryScript.IntializeFactory(typeof(Terrain));
        terrainFactoryScript.GenerateObject("Rock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        //create terrain
        //create enemies
    }

    
}
