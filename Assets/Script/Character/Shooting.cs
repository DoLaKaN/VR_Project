using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimToClosestEnemy();
        
    }



    private void AimToClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        enemy ClosestEnemy = null;

       

        enemy[] allEnemies = GameObject.FindObjectsOfType<enemy>();

        foreach (enemy currentEnemy in allEnemies)
        {
            float distacneToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distacneToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distacneToEnemy;
                ClosestEnemy = currentEnemy;
            }
        }
        transform.LookAt(ClosestEnemy.transform.position);
    }


    private void shot()
    {

    }


}
