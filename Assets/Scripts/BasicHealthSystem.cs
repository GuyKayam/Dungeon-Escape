using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicHealthSystem :MonoBehaviour,IHealth
{
    [SerializeField]
    int startHealth;
    int currentHealth;

    public event ChangedHealthHandler OnHealthReachedZero;

    public int StartHealth { get => startHealth; set => startHealth = value; }
    public int CurrentHealth { get => currentHealth; set { if (value >= 0) { currentHealth = value; } } }



    void Awake()
    {
        CurrentHealth = StartHealth;
    }

    public void ChangeHealth(int changeInHP)
    {
        currentHealth -= changeInHP;
        if (currentHealth <= 0)
        {
            OnHealthReachedZero?.Invoke();
        }
    }


}
