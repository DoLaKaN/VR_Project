using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        //AimToClosestEnemy();
    }


    /*
    private void AimToClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject ClosestEnemy = null;

       

        GameObject [] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject currentEnemy in allEnemies)
                {


                    Debug.Log(currentEnemy);
                    float distacneToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                    if(distacneToEnemy < distanceToClosestEnemy)
                    {
                        distanceToClosestEnemy = distacneToEnemy;
                        ClosestEnemy = currentEnemy;
                    }
            this.transform.LookAt(ClosestEnemy.transform.position);
        } 
    }


    private void shot()
    {

    }

    */
}
