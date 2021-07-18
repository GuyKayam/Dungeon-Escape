using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TouchingDamage : MonoBehaviour
{

    [SerializeField]
     int touchDamage;

    public int TouchDamage
    {
        get { return touchDamage; }
        set { touchDamage = value; }
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      IHealth attribute = other.gameObject.GetComponent(typeof(IHealth)) as IHealth;
        if (attribute is IHealth)
        {
            attribute.ChangeHealth(touchDamage);

        }


    }

}
