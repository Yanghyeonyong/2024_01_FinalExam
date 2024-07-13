using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BackToHome : MonoBehaviour
{
    // 2번 충돌할 경우펫이 집으로 이동하는 함수(공원의 입구에 설치하여 한바퀴 돌고올 경우 이동하도록 만듦)
    // 배변봉투 혹은 목줄을 챙기지 않을 경우 경고문 출력

    public GameObject Canvas;
    public GameObject Camera;
    public bool check = false;
    public Transform HomePos;
    public Transform HomeCameraPos;

    public GameObject con;
    Controller c;

    public GameObject Money;
    public GameObject NextButton;

    public GameObject onWarningText;
    public TextMeshProUGUI Warning;

    CommonObject co;
    void Start()
    {
        c = con.GetComponent<Controller>();
        co = Canvas.GetComponent<CommonObject>();
    }

    public GameObject Leash;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.gameObject.tag == "PET")
        {
            if (check == false)
            {
                check = true;
            }
            else if (check == true)
            {
                other.transform.position = HomePos.position;
                other.transform.rotation = HomePos.rotation;
                co.onpark = false;
                co.onHome = true;
                c.Breath();

                Camera.transform.SetParent(null);
                Camera.transform.SetParent(HomeCameraPos);
                Camera.transform.localPosition = Vector3.zero;
                Camera.transform.localRotation = Quaternion.identity;
                check = false;

                Money.SetActive(true);
                NextButton.SetActive(true);

                if (Canvas.GetComponent<onPark>().onLeash == false || Canvas.GetComponent<onPark>().onTakeBag == false)
                {
                    Warning.text = "";
                    onWarningText.SetActive(true);
                    NextButton.SetActive(false);
                    co.onHome = false;
                }
                if (Canvas.GetComponent<onPark>().onLeash == false)
                {
                    Warning.text += "목죽을 착용하지 않아 평판이 하락합니다.";
                    if (Canvas.GetComponent<onPark>().onTakeBag == false)
                    {
                        Warning.text += "\n";
                    }
                }
                if (Canvas.GetComponent<onPark>().onTakeBag == false)
                {
                    Warning.text += "배변봉투를 챙기지 않아 평판이 하락합니다.";
                }
                Canvas.GetComponent<onPark>().onLeash = false;
                Canvas.GetComponent<onPark>().onTakeBag = false;

                Leash.SetActive(false);

                Canvas.GetComponent<Amount>().homeAudio.Play();
                Canvas.GetComponent<Amount>().parkAudio.Stop();
                Canvas.GetComponent<Amount>().hospitalAudio.Stop();
            }
        }
    }
}
