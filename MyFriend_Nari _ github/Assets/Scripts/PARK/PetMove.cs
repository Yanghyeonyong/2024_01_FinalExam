using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    //펫이 화살표 방향키에 따라서 이동할 수 있는 함수(공원 전용)
    public GameObject con;
    Controller c;

    public GameObject Canvas;

    public GameObject walkSound;
    private AudioSource walkAudio;

    private bool onSound = false;

    CommonObject co;

    void Start()
    {
        c = con.GetComponent<Controller>();
        co = Canvas.GetComponent<CommonObject>();

        walkAudio = walkSound.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (co.onpark == false)
        {
            walkAudio.Stop();
            onSound = false;
        }

        if (co.onpark == true)
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                c.Walking02();
                transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
                dir += Vector3.forward;
                if (onSound == false)
                {
                    walkAudio.Play();
                    onSound = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                c.Breath();



                walkAudio.Stop();
                onSound = false;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                c.Walking02();
                transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
                dir += Vector3.back;

                if (onSound == false)
                {
                    walkAudio.Play();
                    onSound = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                c.Breath();

                walkAudio.Stop();
                onSound = false;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                c.Walking02();
                transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
                dir += Vector3.right;

                if (onSound == false)
                {
                    walkAudio.Play();
                    onSound = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                c.Breath();

                walkAudio.Stop();
                onSound = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                c.Walking02();
                transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
                dir += Vector3.left;

                if (onSound == false)
                {
                    walkAudio.Play();
                    onSound = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                c.Breath();

                walkAudio.Stop();
                onSound = false;
            }

            dir = dir.normalized;
            if (dir.magnitude > 0.5f)
            {
                transform.LookAt(transform.position + dir);
            }
        }
    }

}
