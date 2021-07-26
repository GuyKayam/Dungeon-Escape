using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStraightIfCloseEnough : MonoBehaviour
{
    Transform target;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    private int maxDistance = 10;
    [SerializeField]
    float fireDelay=0.8f;
    [SerializeField]
    float bulletVelocity = 5;
    float distance;
    float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerReference.instance.transform;
    }
    // Update is called once per frame
    void Update()
    {
       
        Shoot();
    }


    void Shoot()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance<maxDistance)
        {
            if (Time.time >= (lastFireTime + fireDelay))
            {
                lastFireTime = Time.time;
                GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(0, 0, bulletVelocity);
            }
        }

    }




}
