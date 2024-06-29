using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRush : MonoBehaviour
{
    //public GameObject Player;
    public GameObject Target;
    public float DistanceBetweenPlayer = 0.1f;
    public float speed = 5;

    private float _distance;
    private float _ray;
    private Vector3 playerVector;
    private Vector3 targetVector;


    void Update()
    {
        if (Target == null) return;
        playerVector = this.transform.forward;
        targetVector = Target.transform.position - this.transform.position;
        _distance = _countDistance();
        _ray = _countRayBetweenObjects();

        Vector3 playerCurrentAngle = this.transform.rotation.eulerAngles;
        if (_countCrossProduct().z < 0)
        {
            _ray *= -1;
        }
        playerCurrentAngle.y += _ray;
        this.transform.rotation = Quaternion.Euler(playerCurrentAngle);

        if (_distance > DistanceBetweenPlayer)
        {

            
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private float _countDistance()
    {
        return Vector3.Distance(playerVector, targetVector);
    }
    private float _countDot()
    {
        return playerVector.x * targetVector.x + playerVector.z * targetVector.z;
    }
    private float _countRayBetweenObjects()
    {
        float dot = _countDot();
        float vector1 = Mathf.Sqrt(Mathf.Pow(playerVector.x, 2) + Mathf.Pow(playerVector.z, 2));
        float vector2 = Mathf.Sqrt(Mathf.Pow(targetVector.x, 2) + Mathf.Pow(targetVector.z, 2));
        float rayBetween = dot / (vector1 * vector2);

        return Mathf.Rad2Deg * Mathf.Acos(_clamp(rayBetween, -1.0f, 1.0f));
    }
    private float _clamp(float value, float min, float max)
    {
        if (max <= value)
        {
            return max;
        }
        else if (min >= value)
        {
            return min;
        }
        return value;
    }
    private Vector3 _countCrossProduct()
    {
        var x = playerVector.y * targetVector.z - playerVector.z * targetVector.y;
        var y = playerVector.z * targetVector.x - playerVector.x * targetVector.z;
        var z = playerVector.x * targetVector.y - playerVector.y * targetVector.x;
        return new Vector3(x, z, y);
    }
}
