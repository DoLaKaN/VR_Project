using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var enemyHeatlh = other.gameObject.GetComponent<HealthAttribute>();
            enemyHeatlh.TakeDamage(DamageValue);
        }

    }

}