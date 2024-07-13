using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    //���� Ư���� ���� ������ �պ����� �̵��ϵ��� ���ִ� �Լ�

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
