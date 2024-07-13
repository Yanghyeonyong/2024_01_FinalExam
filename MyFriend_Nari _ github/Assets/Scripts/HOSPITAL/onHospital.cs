using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class onHospital : MonoBehaviour
{
    //�������� �̵��ϰ� �ప, ����� ���� �ؽ�Ʈ �� ����� ����ϰ� ���ִ� �Լ�

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

        // �����, �ప �ʱ�ȭ
        HowPain = 0;
        HowMedicine = 0;

        PainPrice = 0;
        MedicinePrice = 0;

        final_Price = 0;

        //��� �ʱ�ȭ
        hospital_text.text = "���Ḧ �����ðڽ��ϱ� ?\n(���Ḧ ���� ��� �ڵ����� �����, �ప�� �����˴ϴ�.)\n*�����ڱ��� �ּ� 10���� �̻��� ��츸 �����մϴ�.";
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
        //�����== 2+2*HowPain
        //�ప== HowMedicine
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
            hospital_text.text = "����� " + PainPrice.ToString() + "������ �ప " + MedicinePrice.ToString() + "���� ���ļ� " + final_Price.ToString() + "���� û���Ǿ����ϴ�.";
            if (Cold == true || Skin == true || Hungry == true)
            {
                hospital_text.text += "\n���ܵ� ������ ";
                if (Cold)
                {
                    hospital_text.text += "���� ";
                    Cold = false;
                }
                if (Skin)
                {
                    hospital_text.text += "�Ǻκ� ";
                    Skin = false;
                }
                if (Hungry)
                {
                    hospital_text.text += "������� ";
                    Hungry = false;
                }
                hospital_text.text += "�Դϴ�.";
            }
        }
        else
        {
            hospital_text.text = "�ܾ��� �����մϴ�.";
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
            Status.text = "������ �ǰ����¿� �̻��� �����ϴ�.";
        }
        if (Cold)
        {
            Status.text += "������ �๰�� ���� �긮�� ���� ���ϴ�.";
            if (Skin == true || Hungry == true)
            {
                Status.text += "\n";
            }
        }
        if (Skin)
        {
            Status.text += "������ �� �������⸦ ���� �ܽ��ϴ�.";
            if (Hungry == true)
            {
                Status.text += "\n";
            }
        }
        if (Hungry)
        {
            Status.text += "������ ����� �����ϴ�.";
        }
        onHomeText.SetActive(true);
        SelectPet.SetActive(false);
    }
}
