using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float _elapsedTime;
    public GameObject BulletPrefab;
    public Transform Player;
    public float _randomTime;

    void Start()
    {
        
    }
  
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        _randomTime = Random.Range(1.0f, 3.0f);
        if (_elapsedTime >= _randomTime)
        {
            _elapsedTime = 0.0f;
          
            Vector3 spawenPosition = transform.position + new Vector3(0f, 0f, 2f);
            GameObject bullet = Instantiate(BulletPrefab, transform);

            bullet.transform.LookAt(Player);
        }
    }
}
    
