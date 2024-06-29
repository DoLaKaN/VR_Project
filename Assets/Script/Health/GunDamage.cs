using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GunDamage : Damage
{
    public float GunCooldown = 5f;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform bulletSpawnPoint;
    public float gunSpeed;
    //public int damage = 5;

    private void Start()
    {
        enemyBullet.GetComponent<Damage>().DamageValue = base.DamageValue;
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        bulletTime = GunCooldown;

        GameObject bulletObj = Instantiate(enemyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * gunSpeed);
        Destroy(bulletObj, 5f );
   }

   
}
