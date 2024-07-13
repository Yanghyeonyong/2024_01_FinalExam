using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BackToHome : MonoBehaviour
{
    // 2�� �浹�� ������� ������ �̵��ϴ� �Լ�(������ �Ա��� ��ġ�Ͽ� �ѹ��� ����� ��� �̵��ϵ��� ����)
    // �躯���� Ȥ�� ������ ì���� ���� ��� ��� ���

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
        Debug.Log("�浹");
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
                    Warning.text += "������ �������� �ʾ� ������ �϶��մϴ�.";
                    if (Canvas.GetComponent<onPark>().onTakeBag == false)
                    {
                        Warning.text += "\n";
                    }
                }
                if (Canvas.GetComponent<onPark>().onTakeBag == false)
                {
                    Warning.text += "�躯������ ì���� �ʾ� ������ �϶��մϴ�.";
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
