using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Target;
    private float elapsedTime;
    public bool isDetected;
    public float distance = 20f;
    public float Speed = 100f;
    public float rot;
    Vector3 forwardVec;

    private void Start()
    {
        forwardVec = transform.forward;
    }

    void Update()
    {
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
        else
        {
            rot += Time.deltaTime * Speed;
            transform.rotation = Quaternion.Euler(0f, rot, 0f);
        }

        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 direction = Target.position - transform.position;
            Vector3 crossVec = Vector3.Cross(direction.normalized, forwardVec);

            if (direction.magnitude < distance)
            {
                if (Vector3.Dot(direction.normalized, forwardVec) > 0.5 && crossVec.y < 0)
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
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDetected = false;
          
        }
    }

}


 

