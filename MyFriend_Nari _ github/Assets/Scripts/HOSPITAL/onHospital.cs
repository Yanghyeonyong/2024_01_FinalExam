using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class onHospital : MonoBehaviour
{
    //병원으로 이동하고 약값, 진료비에 대한 텍스트 및 계산을 출력하게 해주는 함수

    private GameObject Camera;
    private Transform HospitalView;
    private bool onhospital = false;

    private GameObject btnUI;
    private GameObject Back;

    private GameObject Money;

    private GameObject Exit;

    private GameObject HospitalText;

    private GameObject Diagnosis;

    public bool Cold = false;
    public bool Skin = false;
    public bool Hungry = false;

    private int medicine = 0;
    private int HowPain = 0;
    private int HowMedicine = 0;

    private int PainPrice = 0;
    private int MedicinePrice = 0;

    private int final_Price = 0;
    private TextMeshProUGUI hospital_text;

    public int myMoney = 0;

    CommonObject co;

    void Start()
    {

        //////////
        co = GetComponent<CommonObject>();
        Camera = co.Camera;
        HospitalView = co.HospitalView;
        onhospital = co.onhospital;
        btnUI = co.UI;
        Back = co.BackButton;
        Money = co.Money;
        Exit = co.Exit;
        HospitalText = co.HospitalText;
        Diagnosis = co.Diagnosis;
        Cold = co.Cold;
        Skin = co.Skin;
        Hungry = co.Hungry;
        medicine = co.medicine;
        HowPain = co.HowPain;
        HowMedicine = co.HowMedicine;
        PainPrice = co.PainPrice;
        MedicinePrice = co.MedicinePrice;
        final_Price = co.final_Price;
        hospital_text = co.hospital_text;
        /////////
    }

    public void GoToHospital()
    {
        GetComponent<Amount>().homeAudio.Stop();
        GetComponent<Amount>().parkAudio.Stop();
        GetComponent<Amount>().hospitalAudio.Play();

        Diagnosis.SetActive(true);

        Camera.transform.SetParent(HospitalView.transform);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;

        btnUI.SetActive(false);

        co.onhospital = true;

        Money.SetActive(false);
        Back.SetActive(false);

        co.onHome = false;

        HospitalText.SetActive(true);

        // 진료비, 약값 초기화
        HowPain = 0;
        HowMedicine = 0;

        PainPrice = 0;
        MedicinePrice = 0;

        final_Price = 0;

        //대사 초기화
        hospital_text.text = "진료를 받으시겠습니까 ?\n(진료를 받을 경우 자동으로 진료비, 약값이 차감됩니다.)\n*소지자금이 최소 10만원 이상일 경우만 가능합니다.";
    }

    public void HospitalPay()
    {
        HowPain = 0;
        HowMedicine = 0;
        Diagnosis.SetActive(false);
        if (Cold)
        {
            HowPain++;
            HowMedicine++;
        }
        if (Skin)
        {
            HowPain++;
            HowMedicine++;
        }
        if (Hungry)
        {
            HowPain++;
            HowMedicine++;
        }
        //진료비== 2+2*HowPain
        //약값== HowMedicine
        PainPrice = 2 + 2 * HowPain;
        MedicinePrice = HowMedicine;
        final_Price = PainPrice + MedicinePrice;
        myMoney = int.Parse(co.my_Money.text);
        if (myMoney >= (PainPrice + MedicinePrice))
        {
            GetComponent<Amount>().buyAudio.Play();

            GetComponent<Amount>().spendMoney += PainPrice + MedicinePrice;
            myMoney = myMoney - PainPrice - MedicinePrice;
            co.my_Money.text = myMoney + "";
            hospital_text.text = "진료비 " + PainPrice.ToString() + "만원에 약값 " + MedicinePrice.ToString() + "만원 합쳐서 " + final_Price.ToString() + "만원 청구되었습니다.";
            if (Cold == true || Skin == true || Hungry == true)
            {
                hospital_text.text += "\n진단된 병명은 ";
                if (Cold)
                {
                    hospital_text.text += "감기 ";
                    Cold = false;
                }
                if (Skin)
                {
                    hospital_text.text += "피부병 ";
                    Skin = false;
                }
                if (Hungry)
                {
                    hospital_text.text += "영양실조 ";
                    Hungry = false;
                }
                hospital_text.text += "입니다.";
            }
        }
        else
        {
            hospital_text.text = "잔액이 부족합니다.";
        }
    }

    public GameObject onHomeText;
    public TextMeshProUGUI Status;
    public GameObject SelectPet;
    public void ShowHealth()
    {
        Status.text = "";
        if (Cold == false && Skin == false && Hungry == false)
        {
            Status.text = "나리의 건강상태에 이상이 없습니다.";
        }
        if (Cold)
        {
            Status.text += "나리가 콧물을 많이 흘리고 몸을 떱니다.";
            if (Skin == true || Hungry == true)
            {
                Status.text += "\n";
            }
        }
        if (Skin)
        {
            Status.text += "나리가 몸 여기저기를 마구 긁습니다.";
            if (Hungry == true)
            {
                Status.text += "\n";
            }
        }
        if (Hungry)
        {
            Status.text += "나리가 기운이 없습니다.";
        }
        onHomeText.SetActive(true);
        SelectPet.SetActive(false);
    }
}
