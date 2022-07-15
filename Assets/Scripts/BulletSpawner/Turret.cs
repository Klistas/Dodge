using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    public Transform Target;
    private float elapsedTime;
    public bool isDetected;
    float dotValue = 0f;
    float crossValue = 0f;
    public float angleRange = 60f;
    public float distance = 20f;
    public float rot;
    public float Speed = 100f;
    Vector3 forVec;

    private void Start()
    {
        forVec = transform.forward;
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
            dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
            Vector3 direction = Target.position - transform.position;
            Vector3 crossVec = Vector3.Cross(direction.normalized, forVec);

            if (direction.magnitude < distance)
            {
                if (Vector3.Dot(direction.normalized, forVec) > 0.5 && crossVec.y > 0)
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


 

