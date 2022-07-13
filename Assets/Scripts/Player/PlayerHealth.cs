using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _lapTime;
    public bool IsPlayerDie;
    void Update()
    {
        _lapTime += Time.deltaTime;
        if (IsPlayerDie == true)
        Time.timeScale = 0.0f;
    }
    
    public void Die()
    {
        IsPlayerDie = true;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Die();
           
            

        }
    }
}
