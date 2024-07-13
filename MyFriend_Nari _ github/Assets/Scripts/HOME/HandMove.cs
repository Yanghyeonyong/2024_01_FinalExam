using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    //손이 특정한 범위 내에서 왕복으로 이동하도록 해주는 함수

    public float speed = 0.5f;
    private float minX = -0.15f;
    private float maxX = 0.15f;
    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.localPosition += Vector3.right * speed * Time.deltaTime;
            if (transform.localPosition.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.localPosition += Vector3.left * speed * Time.deltaTime;
            if (transform.localPosition.x <= minX)
            {
                movingRight = true;
            }
        }
    }
}
