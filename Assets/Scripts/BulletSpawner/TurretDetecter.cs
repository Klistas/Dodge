using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TurretDetecter : MonoBehaviour
{
    public bool isDetect;
    public Transform Target;
    float dotValue = 0f;
    public float angleRange = 60f;
    public float distance = 20f;
    // 벡터 내적으로 적 침입 판별
    void Update()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        Vector3 direction = Target.position - transform.position;
        if (direction.magnitude < distance) // magnitude a^2 + b^2;
        {
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue)
            {
                Debug.Log("적 침입!");
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
    Color NoneDetectColor = new Color(0f, 0f, 1f, 0.2f);
    Color DetectColor = new Color(1f, 0f, 0f, 0.2f);
    private void OnDrawGizmos()
    {
        Handles.color = isDetect ? DetectColor : NoneDetectColor;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, distance);
    }
  
}