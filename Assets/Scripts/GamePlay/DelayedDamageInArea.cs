using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DelayedDamageInArea : MonoBehaviour
{
    [SerializeField]
    int delay;
    [SerializeField]
    float blowRadius;
    [SerializeField]
    int explosionDamage=40;
    [SerializeField]
    int selfDamageToPlayer=2;
    [SerializeField]
    bool shouldShowParticlesAfter;

    [SerializeField]
    GameObject particlesAfterDamage;
    [SerializeField]
    bool shouldSelfDestruct;



    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(passiveMe(delay));
        
    }
   
 
 IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(delay);
        BombExplosion();
    }



    void BombExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blowRadius);
        foreach (var collider in colliders)
        {
            IHealth attribute = collider.gameObject.GetComponent(typeof(IHealth)) as IHealth;

                if (attribute is IHealth)
                {
                    if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        attribute.ChangeHealth(2);
                    continue;
                    }
                    attribute.ChangeHealth(explosionDamage);

                }


            if (shouldShowParticlesAfter)
            {
                Instantiate(particlesAfterDamage, transform.position,transform.rotation);
            }
            if (shouldSelfDestruct)
            {
                Destroy(gameObject);
            }
         
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
