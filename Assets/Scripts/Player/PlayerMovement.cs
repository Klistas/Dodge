using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput _input;

    private Rigidbody _rigidbody;

    public float Speed = 20f;
    public bool UseSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        // _input 에 값을 할당.
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = _input.X * Speed;
        float zSpeed = _input.Y * Speed;
          
        if(UseSpeed)
        {
            _rigidbody.velocity = new Vector3(-xSpeed, 0f, -zSpeed);
        }

        else
        {
             //// 각 방향에 따라 힘을 가함.
            _rigidbody.AddForce(-xSpeed, 0f, -zSpeed);

        }



    }
}
