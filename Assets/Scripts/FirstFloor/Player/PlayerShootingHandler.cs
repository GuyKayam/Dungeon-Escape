using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingHandler : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletVelocity=10;
    [SerializeField]
    float fireDelay=1f;
    [SerializeField]
    float attackDamage;

    float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(this.GetComponent<Collider>(), bullet.GetComponent<Collider>());
    }

    public void OnShootInput(float vertical, float horizontal)
    {
        if ((vertical!=0 || horizontal!=0) && Time.time >= lastFireTime + fireDelay)
        {

            Shoot(vertical, horizontal);
        }
    }


    void Shoot(float vertical, float horizontal)
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(vertical * bulletVelocity, horizontal * bulletVelocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
