using Script.Health;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Blades : MonoBehaviour
{
    public GameObject player;
    public GameObject blades;
    public int damage;
    public float duration;
    public float rotationSpeed;
    public float radius = 5;

    private float time = 0;

    private float angle=0f;

    void Update()
    {
        if (player != null)
        {
            Orbital();
        }
    }

    void Orbital()
    {
        transform.RotateAroundLocal(Vector3.up, 10f * Time.deltaTime);

        angle += rotationSpeed * Time.deltaTime;
        if(angle >= 360)
        {
            angle -= 360f;
        }

        float x = player.transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float z = player.transform.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        //Debug.Log("Z: "+z);
        //Debug.Log("X: "+x);
        transform.position = new Vector3 (x, transform.position.y , z);
    }

    private void LiveTime()
    {
        time += Time.deltaTime;
        
        if (time >= duration)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            var Enemy = other.gameObject.GetComponent<EnemyHealthAttribute>();
            Enemy.DealDamage(damage);
        }


    }

}
