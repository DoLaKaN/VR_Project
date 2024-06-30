using Script.Health;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectals : MonoBehaviour
{
    public int damage;
    public float speed;
    public float cooldown;
    public float LiveTime;
    public float size;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("kolizja");
        if (other.CompareTag("Enemy")){ 
            Debug.Log("trafiony");
            var Enemy = other.gameObject.GetComponent<EnemyHealthAttribute>();
            Enemy.DealDamage(damage);
    }
    }

    }

