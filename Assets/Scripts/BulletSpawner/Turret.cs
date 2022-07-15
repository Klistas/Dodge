
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float TurretRotationSpeed = 15f;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 2f;
    private float spawnRate;
    private float elapsedTime;
    public bool isDetect;
    public Transform Target;
    float dotValue = 0f;
    public float angleRange = 60f;
    public float distance = 20f;

    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
    void Update()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        Vector3 direction = Target.position - transform.position;
        if (direction.magnitude < distance)
        {
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue)
            {
               
                isDetect = true;
            }
            else
            {
                isDetect = false;
            }
        }
        else
        {
            isDetect = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Transform Target = other.transform;
          
                elapsedTime += Time.deltaTime;
                transform.LookAt(Target);
                if (elapsedTime >= spawnRate)
                {
                    GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    elapsedTime = 0;
                    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                }
            
        }
    }
  
}


 

