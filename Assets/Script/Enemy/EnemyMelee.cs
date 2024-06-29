using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        this.transform.LookAt(Target);
    }
}
