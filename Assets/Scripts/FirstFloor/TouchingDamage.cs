using System.Collections;
using System.Collections.Generic;
using UnityEngine;




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
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            IHealth attribute = other.gameObject.GetComponent(typeof(IHealth)) as IHealth;
            if (attribute is IHealth)
            {
                attribute.ChangeHealth(touchDamage);

            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        IHealth attribute = collision.gameObject.GetComponent(typeof(IHealth)) as IHealth;
            if (attribute is IHealth)
            {
                attribute.ChangeHealth(touchDamage);

            }
        
    }
}









