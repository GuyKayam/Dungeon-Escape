using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Terrain
{
    public override string Name => "Fire";
    [SerializeField]
    int size;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            ChangeHealth(collision.gameObject.GetComponent<PlayerBulletHandler>().BulletDamage);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            ChangeHealth(other.gameObject.GetComponent<PlayerBulletHandler>().BulletDamage);
        }
    }




    public override void ChangeHealth(int changeInHP)
    {
        currentHealth -= changeInHP;
        if (currentHealth <= 0)
        {
            if (size > 1)
            {
                CreateSmallerFire(size);
                Destroy(gameObject);
            }
        
        }

    }

    void CreateSmallerFire(int size)
    {
        GameObject smallerFire;
        switch (size)
        {
            case 3:
                smallerFire = (GameObject)Resources.Load("Prefabs/Terrain/MediumFire");
                break;
            case 2:
                smallerFire = (GameObject)Resources.Load("Prefabs/Terrain/DeadFire");
                break;
            default:
                smallerFire = (GameObject)Resources.Load("Prefabs/Terrain/DeadFire");
                break;
        }

        GameObject SmallFire = (GameObject)Instantiate(smallerFire, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
