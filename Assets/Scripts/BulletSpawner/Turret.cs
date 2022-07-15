
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float TurretRotationSpeed = 15f;
    private float elapsedTime;
    public bool isDetected;
    public Transform Target;
    float dotValue = 0f;
    float crossValue = 0f;
    public float angleRange = 60f;
    public float distance = 20f;

  
    void Update()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        crossValue = Mathf.Sin(Mathf.Deg2Rad * (angleRange / 2));
        Vector3 direction = Target.position - transform.position;
        if (direction.magnitude < distance)
        {
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue && Vector3.Cross(direction.normalized,transform.forward) < crossValue)
            {
               
                isDetected = true;
            }
            else
            {
                isDetected = false;
            }
        }
        else
        {
            isDetected = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Target = other.transform;
          
                elapsedTime += Time.deltaTime;
                transform.LookAt(Target);
                if (elapsedTime >= 0.5f)
                {
                    GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    elapsedTime = 0;
                }
            
        }
    }
  
}


 

