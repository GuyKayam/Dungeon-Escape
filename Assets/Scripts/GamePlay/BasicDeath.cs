using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[RequireComponent(typeof(BasicHealthSystem))]
public class BasicDeath : MonoBehaviour,IDeath
{
    public event OnDeathHandler OnDeath;

    [SerializeField]
    bool shouldDestroyParent;

    public void Death()
    {
       
        OnDeath?.Invoke();
        if (shouldDestroyParent)
        if (shouldDestroyParent)
        {
        Destroy(gameObject.transform.parent.gameObject);
            return;
        }
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<IHealth>().OnHealthReachedZero += Death;

    }

    void OnDestroy()
    {
        gameObject.GetComponent<IHealth>().OnHealthReachedZero -= Death;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
