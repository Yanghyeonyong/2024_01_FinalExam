using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CommonObject : MonoBehaviour
{
    //공통으로 사용되는 오브젝트들을 가져가서 사용하도록 하는 오브젝트 저장용 함수

    /////////////// 오브젝트

    //처음 오프닝
    public TMP_InputField plus_Money; //처음에 돈을 입력받을 필드
    public TextMeshProUGUI my_Money; // 돈의 값을 저장할 텍스트
    public Button check;// 확인 버튼
    public TextMeshProUGUI HowMonth;//몇 달인지 저장할 텍스트
    public GameObject Money; //Home화면 상단의 현재 자본과 날짜를 나타내는 UI의 부모객체
    public GameObject backgroundImage; // 처음 오프닝 이미지

    //집
    public Transform pet;//펫의 위치
    public Transform selectPos; //펫 클릭 시 이동할 카메라 위치
    public GameObject NextButton; //다음달로 이동하는 버튼

    public GameObject BackButton; //펫 클릭 후 처음 집의 상태로 돌아가는 버튼
    public GameObject UI; //펫 클릭시 나타날 UI
    public GameObject onSelect; // UI와 BackButtton의 부모객체

    public GameObject onHomeText; //집에서의 텍스트
    public TextMeshProUGUI Status; //상태에 대해 말해줄 텍스트


    //공원
    public GameObject PlayBall; //공놀이에 진입시 나타날 UI
    public Transform ExitPos; // 공놀이에서 나갈경우 펫과 카메라가 이동할 위치

    //병원
    public GameObject HospitalText; //병원에서 나타낼 Text의 부모객체
    public GameObject Exit; // 집으로 돌아갈 버튼
    public GameObject Diagnosis; //진료 결과를 받는 버튼
    public TextMeshProUGUI hospital_text;//병원에서 진료에 대해 말해줄 텍스트

    /////////////// 카메라
    public Camera cam;  //메인 카메라 카메라 화면
    public GameObject Camera; //메인 카메라 객체
    public Transform HomeView; //집에서의 카메라 위치
    public Transform ParkView; //공원에서의 카메라 위치
    public Transform HospitalView; //병원에서의 카메라 위치

    /////////////// 상태
    public bool move = false; //현재 움직이고 있는 상태인지 체크(집에서 뛰어놀기 중일 때)

    public bool onHome = true; //집에 있는지 체크

    public bool onpark = false; //공원으로 이동했는지 체크

    public bool onhospital = false;// 병원으로 이동했는지 체크

    public bool Cold = false;//감기에 걸렸는지 체크
    public bool Skin = false;//피부병에 걸렸는지 체크
    public bool Hungry = false;//영양실조에 걸렸는지 체크

    /////////////// 값
    public int my_Amount; //현재 내 수중에 있는 자본
    public int FriendlyPoint = 50;

    public int medicine = 0; //약값
    public int HowPain = 0; //병이 몇 종류 걸렸는지
    public int HowMedicine = 0; //걸린 병의 갯수에 따른 약의 갯수

    public int PainPrice = 0; //진료비
    public int MedicinePrice = 0; //약값

    public int final_Price = 0; //최종 병원 지불 
}
