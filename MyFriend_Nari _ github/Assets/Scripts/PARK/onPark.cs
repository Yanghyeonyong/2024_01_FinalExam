using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPark : MonoBehaviour
{
    //�������� �̵��ϰ� �̷� ���� �߻��ϴ� �Ӽ��� �����ϴ� �Լ�

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
        GetComponent<Amount>().homeAudio.Stop();//���� ��������� �����
        GetComponent<Amount>().parkAudio.Play();//������ ��������� �����Ѵ�.
        GetComponent<Amount>().hospitalAudio.Stop();//������ ��������� �����.

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
