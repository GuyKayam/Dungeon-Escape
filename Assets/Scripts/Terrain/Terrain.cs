using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Terrain : GenerationObject
{
    /*    [SerializeField]
       public GameObject prefab;*/
    public override string Name => "Terrain";

    [SerializeField]
    int startHealth = 5;
    protected int currentHealth;

    public int StartHealth { get => startHealth; set => startHealth = value; }
    public int CurrentHealth { get => currentHealth; set { if (value >= 0) { currentHealth = value; } } }

    void Start()
    {
        currentHealth = startHealth;
    }


    public virtual void ChangeHealth(int changeInHP)
    {
        currentHealth -= changeInHP;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}



