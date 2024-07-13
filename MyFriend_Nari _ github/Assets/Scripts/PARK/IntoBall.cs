using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoBall : MonoBehaviour
{
    //입장하는 위치에 닿을 경우 펫의 위치가 공놀이하는 곳으로 이동하는 함수

    public Transform PETPOS;
    public GameObject Canvas;

    public GameObject con;
    Controller c;

    public GameObject PlayBall;

    public GameObject Camera;
    public Transform BallCameraPos;
    // Start is called before the first frame update

    CommonObject co;
    void Start()
    {
        c = con.GetComponent<Controller>();
        co = Canvas.GetComponent<CommonObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="PET") {
            other.transform.position = PETPOS.position;
            other.transform.rotation = PETPOS.rotation;
            co.onpark = false;

            c.Breath();

            PlayBall.SetActive(true);
            Camera.transform.SetParent(null);
            Camera.transform.SetParent(BallCameraPos);
            Camera.transform.localPosition = Vector3.zero;
            Camera.transform.localRotation = Quaternion.identity;
        }
    }
}
