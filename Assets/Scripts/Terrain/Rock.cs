using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Terrain
{
    public override string Name => "Rock";

    [SerializeField]
    int size;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            ChangeHealth(collision.gameObject.GetComponent<PlayerBulletHandler>().BulletDamage);
        }
    }

    public override void ChangeHealth(int changeInHP)
    {
        currentHealth -= changeInHP;
        if (currentHealth <= 0)
        {
            if (size > 1)
            {
                CreateSmallerRock(size);
            }
            Destroy(gameObject);
        }

    }

    void CreateSmallerRock(int size)
    {
        GameObject smallerRock;
        switch (size)
        {
            case 3:
                smallerRock = (GameObject)Resources.Load("Prefabs/Terrain/RockSize2");
                break;
            case 2:
                smallerRock = (GameObject)Resources.Load("Prefabs/Terrain/RockSize1");
                break;
            default:
                smallerRock = (GameObject)Resources.Load("Prefabs/Terrain/RockSize1");
                break;
        }
     
        GameObject SmallRock = (GameObject)Instantiate(smallerRock, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);
    }
}
