using Script.Character;
using Script.Exp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] typeOfWeapon;
    public Projectals projectal;
    public PlayerStats playerStats;
    public GameObject[] gunsPositions;

    private float time;

    void Update()
    {
        Fire();
    }

    void Fire()
    {

        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            time += Time.deltaTime;

            if (time >= playerStats.cooldown)
            {
                time = 0;
                for (int x = 0; x < gunsPositions.Length; x++)
                {
                    GameObject bullet = Instantiate(projectal.gameObject, gunsPositions[x].transform.position, gunsPositions[x].transform.rotation) as GameObject;
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.velocity = bullet.transform.forward * playerStats.projectalSpeed;
                    Destroy(bullet, playerStats.LiveTime);
                }

            }
        }
    }

}
