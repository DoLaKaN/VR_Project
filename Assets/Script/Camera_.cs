using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_ : MonoBehaviour
{
    public Transform CameraTarget;

    
    void FixedUpdate()
    {
        if (CameraTarget == null) return;
        this.transform.position = new Vector3(CameraTarget.transform.position.x, 25 , CameraTarget.position.z-20);
    }
}
