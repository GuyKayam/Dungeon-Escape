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
    float fireDelay=0f;
    [SerializeField]
    float attackDamage;

    float lastFireTime;

    Vector2 shootingDirection;
    bool isBtnDown = false;

    // Start is called before the first frame update
    void Start()
    {    }

    public void OnBtnDown(float vertical, float horizontal)
    {
        if (vertical!=0 || horizontal!=0)
        {
            shootingDirection = new Vector2(vertical, horizontal);
            isBtnDown = true;
        }
    }

    public void OnBtnUp()
    {

        isBtnDown = false;
    }


    void Shoot(Vector2 shotDierction)
    {
      if(Time.time >= (lastFireTime + fireDelay))
        {
            Debug.Log("Time="+ Time.time);
            Debug.Log("last shot" + lastFireTime + fireDelay);

            lastFireTime = Time.time;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(shotDierction.x * bulletVelocity, shotDierction.y * bulletVelocity, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isBtnDown)
        {
            Shoot(shootingDirection);
        }
    }
}
