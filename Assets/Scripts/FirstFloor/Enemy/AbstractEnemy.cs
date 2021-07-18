using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour,IHealth
{
    [SerializeField]
    int startHealth;
    protected int currentHealth;
    public int StartHealth { get => startHealth; set => startHealth = value; }
    public int CurrentHealth { get => currentHealth; set { if (value >= 0) { currentHealth = value; } } }

    [SerializeField]
    int touchDamage;


    public virtual void ChangeHealth(int changeInHP)
    {
        currentHealth += changeInHP;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
