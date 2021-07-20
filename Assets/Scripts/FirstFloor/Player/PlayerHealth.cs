using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BasicHealthSystem
{
    [SerializeField]
    int maxHealth = 7;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public event ChangedHealthHandler OnHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        StartHealth = maxHealth;
        CurrentHealth = StartHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ChangeHealth(int changeInHP)
    {
        OnHealthChanged?.Invoke(changeInHP);
        base.ChangeHealth(changeInHP);
    }
}
