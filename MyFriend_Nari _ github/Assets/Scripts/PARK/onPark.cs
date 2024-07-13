using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPark : MonoBehaviour
{
    //공원으로 이동하고 이로 인해 발생하는 속성을 설정하는 함수

    private GameObject Camera;
    private Transform ParkView;
    private GameObject btnUI;
    private GameObject Back;
    private GameObject Pet;

    private bool onpark = false;

    private GameObject Money;

    private GameObject PlayBall;
    private Transform ExitPos;

    public GameObject Controller;
    Controller c;

    private CommonObject co;

    void Start()
    {
        c = Controller.GetComponent<Controller>();

        /////////
        co = GetComponent<CommonObject>();
        Camera = co.Camera;
        ParkView = co.ParkView;
        btnUI = co.UI;
        Back = co.BackButton;
        Pet= co.pet.gameObject;
        onpark = co.onpark;
        Money = co.Money;
        PlayBall = co.PlayBall;
        ExitPos = co.ExitPos;
        ////////
    }

    public void GoToPark()
    {
        GetComponent<Amount>().homeAudio.Stop();//집의 배경음악을 멈춘다
        GetComponent<Amount>().parkAudio.Play();//공원의 배경음악을 실행한다.
        GetComponent<Amount>().hospitalAudio.Stop();//병원의 배경음악을 멈춘다.

        GetComponent<Amount>().FriendlyPoint += 10;
        c.Breath();

        Camera.transform.SetParent(ParkView.transform);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;

        btnUI.SetActive(false);
        Pet.transform.position = new Vector3(200, 0.517f, -8);
        Pet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        co.onpark = true;

        Money.SetActive(false);
        Back.SetActive(false);

        co.onHome = false;

        if (onLeash == false)
        {
            this.GetComponent<Amount>().myRepute--;
        }
        if (onTakeBag == false)
        {
            this.GetComponent<Amount>().myRepute--;
        }
    }

    public void ExitBall()
    {
        Camera.transform.SetParent(ParkView.transform);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;

        PlayBall.SetActive(false);

        Pet.transform.position = ExitPos.position;
        Pet.transform.rotation = ExitPos.rotation;
        co.onpark = true;
    }

    public GameObject Leash;
    public bool onLeash = false;
    public void WearLeash()
    {
        Leash.SetActive(true);
        onLeash = true;
    }
    public bool onTakeBag = false;
    public void TakeBag()
    {
        onTakeBag = true;
    }
}
