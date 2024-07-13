using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBall : MonoBehaviour
{
    public GameObject Pet;

    public GameObject firstPos;
    public Transform BiteBallPos;
    public GameObject S_Ball;

    public GameObject SoccerBall;//ÇÁ¸®ÆÕ
    public GameObject Ball;//ÇÁ¸®ÆÕ
    public Transform Generate_Ball_Pos;
    public bool Catch = false;

    public GameObject Shoot;

    public GameObject secondPos;

    public GameObject con;
    Controller c;

    public GameObject runSound;
    private AudioSource runAudio;

    private bool onSound = false;

    void Start()
    {
        c = con.GetComponent<Controller>();

        runAudio = runSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (S_Ball != null && Catch == false)
        {
            if (onSound == false)
            {
                runAudio.Play();
                onSound = true;
            }

            c.Running();
            Pet.transform.LookAt(S_Ball.transform);

            float currentY = Pet.transform.position.y;
            Pet.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
            Vector3 newPosition = Pet.transform.position;
            newPosition.y = currentY;
            Pet.transform.position = newPosition;
        }
        if (Catch == true)
        {
            Pet.transform.LookAt(firstPos.transform);         
            float currentY = Pet.transform.position.y;
            Vector3 newPosition = Vector3.Lerp(
                new Vector3(Pet.transform.position.x, 0, Pet.transform.position.z),
                new Vector3(firstPos.transform.position.x, 0, firstPos.transform.position.z),
                0.002f
            );
            newPosition.y = currentY;
            Pet.transform.position = newPosition; 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            GameObject sc = Instantiate(SoccerBall, BiteBallPos.position, BiteBallPos.rotation);
            sc.transform.SetParent(BiteBallPos);
            Catch = true;
            S_Ball = sc;
        }

        if (other.gameObject.tag == "CatchBall")
        {
            if (Catch == true)
            {
                Destroy(S_Ball);
                Catch = false;
                Pet.transform.rotation = firstPos.transform.rotation;
                Shoot.SetActive(true);
                c.Breath();

                runAudio.Stop();
                onSound = false;
            }
        }
    }

    public void CreateBall()
    {
        int rand = Random.Range(-10, 11);
        S_Ball = Instantiate(Ball, Generate_Ball_Pos.position, Generate_Ball_Pos.rotation);
        S_Ball.transform.localRotation = Quaternion.Euler(S_Ball.transform.localRotation.eulerAngles.x, S_Ball.transform.localRotation.eulerAngles.y+rand, S_Ball.transform.localRotation.eulerAngles.z);
        Shoot.SetActive(false);
    }
}
