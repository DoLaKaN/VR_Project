using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectals Projectal;
    //public Projectals Projectal1;
    public GameObject GunPosition;
    private float time;

    void Update()
    {
        Fire();
        //Debug.Log("damage " + Projectal.damage);
    }
    
    void Fire()
    {
        time += Time.deltaTime;
        //Debug.Log("time: " + time);
        //Debug.Log("cd: " + Projectal.cooldown);
        

        if (time >= Projectal.cooldown)
        {
            time = 0;
            GameObject bullet = Instantiate(Projectal.gameObject, GunPosition.transform.position, GunPosition.transform.rotation) as GameObject;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = bullet.transform.forward * Projectal.speed;
            Destroy(bullet, Projectal.LiveTime);

        }



    }
    
}
