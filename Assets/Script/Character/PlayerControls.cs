using System.Collections;
using System.Collections.Generic;
using Script.Character;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public PlayerStats stats;
    public GameObject gun;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float directionX= Input.GetAxis("Horizontal") * stats.speed * Time.deltaTime;
        float directionY= Input.GetAxis("Vertical")* stats.speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x+ directionX, 0.75f , transform.position.z + directionY);

        AimToClosestEnemy();
        
    }

    public void AimToClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject ClosestEnemy = null;

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {

            Debug.Log(currentEnemy);
            float distacneToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distacneToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distacneToEnemy;
                ClosestEnemy = currentEnemy;
            }
            this.transform.LookAt(ClosestEnemy.transform.position);
            gun.transform.LookAt (ClosestEnemy.transform.position);
        }
        
    }

}
