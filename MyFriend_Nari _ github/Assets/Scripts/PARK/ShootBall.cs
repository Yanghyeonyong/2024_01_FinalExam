using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    //���� ���� �� �߻��ϴ� �Լ�
    public float force;

    void Start()
    {
        force = Random.Range(400f, 600f);
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(transform.forward * force);
        }
        else
        {
            Debug.LogError("Rigidbody�� �� ��ü�� �����ϴ�.");
        }
    }
}
