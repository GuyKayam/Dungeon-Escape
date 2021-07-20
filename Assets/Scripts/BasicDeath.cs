using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BasicHealthSystem))]
public class BasicDeath : MonoBehaviour,IDeath
{
    public event OnDeathHandler OnDeath;


    public void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<IHealth>().OnHealthReachedZero += Death;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
