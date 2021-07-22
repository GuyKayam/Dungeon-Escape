using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletLogic : MonoBehaviour
{
    [SerializeField]
    private float destroyTimer=4;

    [SerializeField]
    private int bulletDamage;

    public int BulletDamage
    {
        get { return bulletDamage; }
        set { bulletDamage = value; }
    }

    public float DestroyTimer
    {
        get { return destroyTimer; }
        set { destroyTimer = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }


    protected abstract void OnTriggerEnter(Collider other);



}
