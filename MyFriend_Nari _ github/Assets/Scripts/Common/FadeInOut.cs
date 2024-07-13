using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    //�����޷� �̵� �� ���̵����� ����ǵ��� �ϴ� �Լ�
    //+��Ȳ�� �߻��� ��� ��� ���

    public int finalMonth = 11;
    CommonObject co;

    void Start()
    {
        co = GetComponent<CommonObject>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public Image fadeImage;

    float fadeIn = 0;
    IEnumerator FadeInCoroutine()
    {
        co.onHome = false;
        fadeImage.gameObject.SetActive(true);

        fadeIn = 0;

        while (fadeIn < 1.0f)
        {
            fadeIn = fadeIn + 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeIn);
        }
        fadeImage.gameObject.SetActive(false);

        if (int.Parse(GetComponent<Amount>().HowMonth.text) < finalMonth)
        {
            ShowWarning();
        }
        else
        {
            GetComponent<Amount>().Ending();
        }
    }

    public GameObject onWarningText;
    public TextMeshProUGUI Warning;
    public GameObject nextButton;
    public void ShowWarning()
    {
        Warning.text = "";
        onHospital h = GetComponent<onHospital>();
        Amount a = GetComponent<Amount>();
        if (h.Cold || h.Skin || h.Hungry || a.haveFeed == 0 || a.havePad == 0)
        {
            nextButton.SetActive(false);
            onWarningText.SetActive(true);
            if ((h.Cold || h.Skin || h.Hungry))
            {
                Warning.text += "<������ �����°� ���� �ʾ� ���δ�>\n";
            }
            if (h.Cold)
            {
                Warning.text += "������ �๰�� ���� �긮�� ���� ���� �ִ�.";
                if (h.Skin == true || h.Hungry == true)
                {
                    Warning.text += "\n";
                }
            }
            if (h.Skin)
            {
                Warning.text += "������ ���� �������� �� �ܴ´�.";
                if (h.Hungry == true)
                {
                    Warning.text += "\n";
                }
            }
            if (h.Hungry)
            {
                Warning.text += "������ ����� ����δ�.";
            }

            if ((h.Cold || h.Skin || h.Hungry))
            {
                Warning.text += "\n";
            }
            if (a.haveFeed == 0 || a.havePad == 0)
            {
                Warning.text += "<���� �ʿ��ǰ�� �����ϴ�>\n";
            }
            if (a.haveFeed == 0)
            {
                Warning.text += "��ᰡ �� ��������.";
                if (a.havePad == 0)
                {
                    Warning.text += "\n";
                }
            }
            if (a.havePad == 0)
            {
                Warning.text += "�躯�е��� ������ �����ϴ�.";
            }
        }
        else
        {
            co.onHome = true;
        }
    }
}
