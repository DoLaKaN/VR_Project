using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int DamageValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var enemyHeatlh = other.gameObject.GetComponent<HealthAttribute>();
            enemyHeatlh.TakeDamage(DamageValue);
            Destroy(gameObject);
        }

    }

}
