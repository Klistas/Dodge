using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 0.001f;
    

    void Start()
    {
        
        Destroy(gameObject, 3f);
    }

   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Speed);
       
    }
}
