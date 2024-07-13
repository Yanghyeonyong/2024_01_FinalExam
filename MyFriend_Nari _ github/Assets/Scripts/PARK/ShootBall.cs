using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    //공을 생성 시 발사하는 함수
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
            Debug.LogError("Rigidbody가 이 객체에 없습니다.");
        }
    }
}
