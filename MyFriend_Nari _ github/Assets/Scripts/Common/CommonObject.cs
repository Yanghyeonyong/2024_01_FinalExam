using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CommonObject : MonoBehaviour
{
    //�������� ���Ǵ� ������Ʈ���� �������� ����ϵ��� �ϴ� ������Ʈ ����� �Լ�

    /////////////// ������Ʈ

    //ó�� ������
    public TMP_InputField plus_Money; //ó���� ���� �Է¹��� �ʵ�
    public TextMeshProUGUI my_Money; // ���� ���� ������ �ؽ�Ʈ
    public Button check;// Ȯ�� ��ư
    public TextMeshProUGUI HowMonth;//�� ������ ������ �ؽ�Ʈ
    public GameObject Money; //Homeȭ�� ����� ���� �ں��� ��¥�� ��Ÿ���� UI�� �θ�ü
    public GameObject backgroundImage; // ó�� ������ �̹���

    //��
    public Transform pet;//���� ��ġ
    public Transform selectPos; //�� Ŭ�� �� �̵��� ī�޶� ��ġ
    public GameObject NextButton; //�����޷� �̵��ϴ� ��ư

    public GameObject BackButton; //�� Ŭ�� �� ó�� ���� ���·� ���ư��� ��ư
    public GameObject UI; //�� Ŭ���� ��Ÿ�� UI
    public GameObject onSelect; // UI�� BackButtton�� �θ�ü

    public GameObject onHomeText; //�������� �ؽ�Ʈ
    public TextMeshProUGUI Status; //���¿� ���� ������ �ؽ�Ʈ


    //����
    public GameObject PlayBall; //�����̿� ���Խ� ��Ÿ�� UI
    public Transform ExitPos; // �����̿��� ������� ��� ī�޶� �̵��� ��ġ

    //����
    public GameObject HospitalText; //�������� ��Ÿ�� Text�� �θ�ü
    public GameObject Exit; // ������ ���ư� ��ư
    public GameObject Diagnosis; //���� ����� �޴� ��ư
    public TextMeshProUGUI hospital_text;//�������� ���ῡ ���� ������ �ؽ�Ʈ

    /////////////// ī�޶�
    public Camera cam;  //���� ī�޶� ī�޶� ȭ��
    public GameObject Camera; //���� ī�޶� ��ü
    public Transform HomeView; //�������� ī�޶� ��ġ
    public Transform ParkView; //���������� ī�޶� ��ġ
    public Transform HospitalView; //���������� ī�޶� ��ġ

    /////////////// ����
    public bool move = false; //���� �����̰� �ִ� �������� üũ(������ �پ��� ���� ��)

    public bool onHome = true; //���� �ִ��� üũ

    public bool onpark = false; //�������� �̵��ߴ��� üũ

    public bool onhospital = false;// �������� �̵��ߴ��� üũ

    public bool Cold = false;//���⿡ �ɷȴ��� üũ
    public bool Skin = false;//�Ǻκ��� �ɷȴ��� üũ
    public bool Hungry = false;//��������� �ɷȴ��� üũ

    /////////////// ��
    public int my_Amount; //���� �� ���߿� �ִ� �ں�
    public int FriendlyPoint = 50;

    public int medicine = 0; //�ప
    public int HowPain = 0; //���� �� ���� �ɷȴ���
    public int HowMedicine = 0; //�ɸ� ���� ������ ���� ���� ����

    public int PainPrice = 0; //�����
    public int MedicinePrice = 0; //�ప

    public int final_Price = 0; //���� ���� ���� 
}
