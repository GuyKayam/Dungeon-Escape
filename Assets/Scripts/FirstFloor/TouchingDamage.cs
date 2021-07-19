using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITouchDamage
{

    [SerializeField]
    int TouchDamage
    {
        get;
        set;
    }


    public void OnTriggerEnter(Collider other);

}


public class TouchingDamage : MonoBehaviour,ITouchDamage
{
    [SerializeField]
    private int touchDamage;
    public int TouchDamage
    {
        get { return touchDamage; }
        set { touchDamage = value; }
    }



    public void OnTriggerEnter(Collider other)
    {
        IHealth attribute = other.gameObject.GetComponent(typeof(IHealth)) as IHealth;
        if (attribute is IHealth)
        {
            attribute.ChangeHealth(touchDamage);

        }
    }
}









