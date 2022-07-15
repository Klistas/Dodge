
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

    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
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
