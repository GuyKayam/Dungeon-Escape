using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
 
    void ChangeHealth(int changeInHP);
}

public class HPSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
