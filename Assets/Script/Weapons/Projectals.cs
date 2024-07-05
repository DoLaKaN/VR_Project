using Script.Character;
using Script.Health;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Projectals : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Enemy"))
        {
            var Enemy = other.gameObject.GetComponent<EnemyHealthAttribute>();
            Enemy.DealDamage(playerStats.damage);
            /*
            if (playerStats.penetration >= 1)
            {
                Enemy.DealDamage(playerStats.damage);
                playerStats.penetration -= 1;
            }
            if (playerStats.penetration <= 0)
            {
                Enemy.DealDamage(playerStats.damage);
                Destroy(this.gameObject);
            }
            */
        }
    }

}

