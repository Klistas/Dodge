using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    // ������Ƽ�� bool Ÿ���� ������ �����
  

    public float X { get; private set; }

    public float Y { get; private set; }
    
    void Update()
    {

        // �������� ������ �⺻ ������ �ʱ�ȭ.
        X = Y = 0f;


        // ������������ �Է°��� ����.
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

      
        //Up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        //Down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        //Left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);   
        //Right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

       
       



     }
}
