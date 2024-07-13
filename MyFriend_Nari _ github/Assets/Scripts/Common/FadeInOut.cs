using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    //다음달로 이동 시 페이드인이 적용되도록 하는 함수
    //+상황이 발생할 경우 경고문 출력

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
                Warning.text += "<나리의 몸상태가 좋지 않아 보인다>\n";
            }
            if (h.Cold)
            {
                Warning.text += "나리가 콧물을 많이 흘리고 몸을 떨고 있다.";
                if (h.Skin == true || h.Hungry == true)
                {
                    Warning.text += "\n";
                }
            }
            if (h.Skin)
            {
                Warning.text += "나리가 몸이 간지러운 듯 긁는다.";
                if (h.Hungry == true)
                {
                    Warning.text += "\n";
                }
            }
            if (h.Hungry)
            {
                Warning.text += "나리가 기운이 없어보인다.";
            }

            if ((h.Cold || h.Skin || h.Hungry))
            {
                Warning.text += "\n";
            }
            if (a.haveFeed == 0 || a.havePad == 0)
            {
                Warning.text += "<집에 필요용품이 부족하다>\n";
            }
            if (a.haveFeed == 0)
            {
                Warning.text += "사료가 다 떨어졌다.";
                if (a.havePad == 0)
                {
                    Warning.text += "\n";
                }
            }
            if (a.havePad == 0)
            {
                Warning.text += "배변패드의 수량이 부족하다.";
            }
        }
        else
        {
            co.onHome = true;
        }
    }
}
