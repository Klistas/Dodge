using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Target;
    private float elapsedTime;
    public bool isDetected;
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
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue)
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
            if (isDetected)
            {
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
  
}


 

