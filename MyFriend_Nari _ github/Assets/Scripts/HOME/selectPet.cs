using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class selectPet : MonoBehaviour
{
    //쓰다듬기, 뛰어놀기, 사료주기, 간식주기, 펫 클릭을 통한 UI 생성에 관한 함수
    private Camera cam;
    private GameObject Camera;

    private bool move = false;
    private Vector3 pos; //처음 클릭한 위치
    private Transform pet;
    private Transform selectPos;

    private Transform HomeView;

    private GameObject BackButton;
    private GameObject NextButton;

    private GameObject UI;

    private GameObject onSelect;

    public GameObject con;
    Controller c;

    private GameObject Money;

    private bool onHome = true;

    private GameObject HospitalText;

    public GameObject runSound;
    private AudioSource runAudio;

    private CommonObject co;
    void Start()
    {
        c = con.GetComponent<Controller>();
        //////////       
        co = GetComponent<CommonObject>();

        cam = co.cam;
        Camera=co.Camera;
        move=co.move;
        pet= co.pet;
        selectPos= co.selectPos;
        HomeView = co.HomeView;
        BackButton = co.BackButton;
        NextButton = co.NextButton;
        UI = co.UI;
        onSelect = co.onSelect;
        Money = co.Money;
        onHome=co.onHome;
        HospitalText = co.HospitalText;
        /////////////
        runAudio = runSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (onHome)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.tag == "PET")
                    {
                        pos = selectPos.transform.position;
                        Debug.Log(hit.transform.gameObject);
                        move = true;
                    }
                }
            }

            if (move)
            {
                Camera.transform.position = Vector3.Lerp(Camera.transform.position, pos, 0.01f);
                Camera.transform.LookAt(pet);

                if (Vector3.Distance(Camera.transform.position, pos) < 0.1f)
                {
                    c.Sitting();
                    move = false;

                    onSelect.SetActive(true);
                    UI.SetActive(true);
                    BackButton.SetActive(true);
                    NextButton.SetActive(false);
                }
                pet.GetComponent<AudioSource>().Play();
            }
        }

        if (onHome_Running)
        {
            if (Input.GetMouseButtonDown(1)) 
            {
                c.Running();
                SetTargetPosition();
                runAudio.Play();
            }

            if (isMoving)
            {
                MoveObject();
            }
        }
    }

    public void BackToOriginPos()
    {
        Camera.transform.SetParent(null);
        Camera.transform.position = HomeView.transform.position;
        Camera.transform.rotation = Quaternion.Euler(new Vector3(30, 0, 0));

        onSelect.SetActive(false);
        c.Breath();
        NextButton.SetActive(true);
        onHome = true;
        UI.SetActive(true);
        Money.SetActive(true);
        if (co.onpark || co.onhospital)
        {
            Money.SetActive(true);
            pet.transform.position = new Vector3(-2.09f, 0.517f, -5.29f);
            pet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            co.onpark = false;
            co.onhospital = false;
            HospitalText.SetActive(false);

            GetComponent<Amount>().homeAudio.Play();
            GetComponent<Amount>().parkAudio.Stop();
            GetComponent<Amount>().hospitalAudio.Stop();
        }
        if(onHome_Running)
        {
            pet.transform.position = new Vector3(-2.09f, 0.517f, -5.29f);
            pet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        detailPlay.SetActive(false);
        Play.SetActive(true);
        onHome_Running = false;

        if (GetComponent<Amount>().haveToy >= 1)
        {
            toy.SetActive(true);
            toy.transform.position = new Vector3(-1.2f, 0f, -5.24f);
        }
    }

    public GameObject feed;
    public GameObject onWarningText;
    public TextMeshProUGUI Warning;
    public void EatFeed()
    {
        if (GetComponent<Amount>().haveFeed >= 1)
        {
            feed.SetActive(true);
            c.Eating();
            StartCoroutine(StartEat());
            GetComponent<Amount>().haveFeed--;
        }
        else
        {
            Warning.text = "";
            onWarningText.SetActive(true);
            Warning.text = "사료의 양이 부족합니다.";
            NextButton.SetActive(false);
            onHome = false;
        }
    }
    public Transform EatCamera;
    public bool todaysEat = false;
    IEnumerator StartEat()
    {
        Camera.transform.SetParent(EatCamera);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;
        NextButton.SetActive(false);
        onHome = false;
        yield return new WaitForSeconds(5f);
        onHome = true;
        c.Breath();
        feed.SetActive(false);
        NextButton.SetActive(true);
        BackToOriginPos();
        todaysEat = true;
    }
    public void ExitWarning()
    {
        onWarningText.SetActive(false);
        BackToOriginPos();
        onHome = true;
    }

    public GameObject snack;
    public void EatSnack()
    {
        if (GetComponent<Amount>().haveSnack >= 1)
        {
            snack.SetActive(true);
            c.Eating();
            StartCoroutine(StartSnack());
            GetComponent<Amount>().haveSnack--;
        }
        else
        {
            onHome = false;
            onSelect.SetActive(false);
            Warning.text = "";
            onWarningText.SetActive(true);
            Warning.text = "간식의 갯수가 부족합니다.";
            NextButton.SetActive(false);
        }
    }
    IEnumerator StartSnack()
    {
        GetComponent<Amount>().FriendlyPoint += 10;
        onSelect.SetActive(false);
        Camera.transform.SetParent(EatCamera);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;
        NextButton.SetActive(false);
        onHome = false;
        yield return new WaitForSeconds(5f);
        onHome = true;
        c.Breath();
        snack.SetActive(false);
        NextButton.SetActive(true);
        BackToOriginPos();
    }
    public GameObject Hand;
    public void Stroke()//쓰다듬다.
    {
        GetComponent<Amount>().FriendlyPoint += 10;
        Vector3 newPosition = Hand.transform.localPosition;
        newPosition.x = 0;
        Hand.transform.localPosition = newPosition;
        StartCoroutine(StartStroke());
    }

    IEnumerator StartStroke()
    {
        Money.SetActive(false);
        onSelect.SetActive(false);
        c.WigglingTail();
        yield return new WaitForSeconds(0.3f);
        onHome = false;
        Hand.SetActive(true);
        yield return new WaitForSeconds(3f);
        onHome = true;
        Hand.SetActive(false);
        c.Breath();
        NextButton.SetActive(true);
        BackToOriginPos();
    }

    public GameObject Play;
    public GameObject detailPlay;
    public void onPlay()
    {
        Play.SetActive(false);
        detailPlay.SetActive(true);
        c.Breath();
    }
    public bool onHome_Running = false;
    public Transform TopView;
    public void Running()
    {
        Camera.transform.SetParent(TopView);
        Camera.transform.localPosition = Vector3.zero;
        Camera.transform.localRotation = Quaternion.identity;
        GetComponent<Amount>().FriendlyPoint += 10;
        if (GetComponent<Amount>().haveToy >= 1)
        {
            GetComponent<Amount>().FriendlyPoint += 5;
        }
        onHome = false;
        UI.SetActive(false);
        Money.SetActive(false);
        onHome_Running = true;
    }

    public float speed = 4.0f; // 이동 속도
    private Vector3 targetPosition; // 목표 지점
    private bool isMoving = false; // 이동 중 여부
    void SetTargetPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
            isMoving = true;
            if (GetComponent<Amount>().haveToy >= 1)
            {
                toy.SetActive(true);
                toy.transform.position = targetPosition;
            }
        }
    }
    public GameObject toy;
    void MoveObject()
    {
        float step = speed * Time.deltaTime;
        Vector3 targetPositionXZ = new Vector3(targetPosition.x, pet.transform.position.y, targetPosition.z);
        pet.transform.position = Vector3.MoveTowards(pet.transform.position, targetPositionXZ, step);

        pet.LookAt(targetPositionXZ);
        if (Vector3.Distance(pet.transform.position, targetPositionXZ) < 0.001f)
        {
            c.Breath();
            isMoving = false;
            pet.LookAt(null);

            runAudio.Stop();
        }
    }
}
