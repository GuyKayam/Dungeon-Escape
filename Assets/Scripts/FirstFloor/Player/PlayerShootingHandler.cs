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

    Vector2 shootingDirection;
    bool isBtnDown = false;

    // Start is called before the first frame update
    void Start()
    {    }

    public void OnBtnDown(float vertical, float horizontal)
    {
        if ((vertical!=0 || horizontal!=0) && Time.time >= lastFireTime + fireDelay)
        {
            Debug.Log("Pressing");
            shootingDirection = new Vector2(vertical, horizontal);
            isBtnDown = true;
        }
    }

    public void OnBtnUp()
    {
        Debug.Log("NotPRessing");

        isBtnDown = false;
    }


    void Shoot(Vector2 shotDierction)
    {
      
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(shotDierction.x * bulletVelocity, shotDierction.y * bulletVelocity, 0);
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
