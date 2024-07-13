using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Amount : MonoBehaviour
{
    //오프닝, 돈 계산, 상황 발생에 대한 변수 생성, 상점 열기/닫기, 물품 구매, 평판 보기, 엔딩을 보여주는 함수

    private TMP_InputField plus_Money;
    private TextMeshProUGUI my_Money;
    private Button check;

    private int my_Amount;

    private Transform Camera;
    private Transform CameraHomePosition;


    private GameObject NextButton;


    private GameObject backgroundImage;


    public int FriendlyPoint=50;


    public TextMeshProUGUI HowMonth;

    private bool firstClick=false;



    public GameObject nextSound;
    private AudioSource nextAudio;

    public GameObject buySound;
    public AudioSource buyAudio;



    public GameObject homeSound;
    public AudioSource homeAudio;

    public GameObject parkSound;
    public AudioSource parkAudio;

    public GameObject hospitalSound;
    public AudioSource hospitalAudio;


    private CommonObject co;

    void Start()
    {
        /////////
        co = GetComponent<CommonObject>();
        plus_Money = co.plus_Money;
        my_Money = co.my_Money;
        check= co.check;
        my_Amount = co.my_Amount;
        Camera = co.Camera.transform;
        CameraHomePosition = co.HomeView;
        NextButton = co.NextButton;
        backgroundImage = co.backgroundImage;
        FriendlyPoint = co.FriendlyPoint;
        HowMonth = co.HowMonth;
        ////////
        nextAudio = nextSound.GetComponent<AudioSource>();
        buyAudio = buySound.GetComponent<AudioSource>();


        homeAudio = homeSound.GetComponent<AudioSource>();
        parkAudio = parkSound.GetComponent<AudioSource>();
        hospitalAudio = hospitalSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (firstClick == false) {
            if (Input.GetMouseButtonDown(0))
            {
                firstClick = true;
                StartCoroutine(CreateOpening());
            }
        }
    }
    public GameObject canvas;
    public GameObject clickText;
    IEnumerator CreateOpening()
    {
        clickText.SetActive(false); 
        CanvasGroup cg = canvas.GetComponent<CanvasGroup>();
        //cg.alpha = 0;
        while ((cg.alpha < 1.0f))
        {
            cg.alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public GameObject opening;
    public void CheckMoney()
    {
        my_Amount = int.Parse(plus_Money.text);
        my_Money.text = int.Parse(plus_Money.text) + "";

        plus_Money.gameObject.SetActive(false);
        check.gameObject.SetActive(false);

        Camera.transform.position = CameraHomePosition.transform.position;
        Camera.transform.rotation = CameraHomePosition.rotation;
        NextButton.gameObject.SetActive(true);

        backgroundImage.SetActive(false);

        HowMonth.text= int.Parse(HowMonth.text)+1 + "";
        home.SetActive(true);
        opening.SetActive(false);
    }

    private int dontFeed = 0;
    private int howHungry = 0;
    private int howSkin = 0;
    private int howCold = 0;
    public int spendMoney = 0;
    public void NextDay()
    {
        nextAudio.Play();

        if (GetComponent<FadeInOut>().finalMonth > int.Parse(HowMonth.text) + 1)
        {
            int money = (int)(int.Parse(my_Money.text) + my_Amount * myRepute * 0.01);
            //my_Money.text = int.Parse(my_Money.text) + my_Amount + "";
            my_Money.text = money + "";
        }
        if (GetComponent<onHospital>().Hungry == true)
        {
            FriendlyPoint -= 5;
            howHungry++;
        }
        if (GetComponent<onHospital>().Skin == true)
        {
            FriendlyPoint -= 5;
            howSkin++;
        }
        if (GetComponent<onHospital>().Cold == true)
        {
            FriendlyPoint -= 5;
            howCold++;
        }
        if (GetComponent<selectPet>().todaysEat == false)
        {
            GetComponent<onHospital>().Hungry = true;
            FriendlyPoint -= 20;

            dontFeed++;
        }
        else
        {
            GetComponent<selectPet>().todaysEat = false;
        }

        if (havePad > 0)
        {
            havePad--;
        }
        else if (havePad == 0) 
        {
            FriendlyPoint -= 10;
        }
        if (FriendlyPoint < 0)
        {
            FriendlyPoint = 0;
        }
        if(FriendlyPoint > 100) 
        {
            FriendlyPoint = 100;       
        }

        if (GetComponent<onHospital>().Skin == false) 
        {
            int skin_random = Random.Range(1, 101);
            Debug.Log("피부병 : " + skin_random + " 친밀도 : " + FriendlyPoint);
            if (skin_random > FriendlyPoint)
            {
                GetComponent<onHospital>().Skin = true;
            }
        }
        if (GetComponent<onHospital>().Cold == false) 
        {
            int cold_random = Random.Range(1, 101);
            Debug.Log("감기 : " + cold_random + " 친밀도 : " + FriendlyPoint);
            if (cold_random > FriendlyPoint)
            {
                GetComponent<onHospital>().Cold = true;
            }
        }
        HowMonth.text = int.Parse(HowMonth.text) + 1 + "";
    }

    public GameObject store;
    public void OpenStore()
    {
        store.SetActive(true);

        co.onHome = false;
    }
    public void CloseStore()
    {
        store.SetActive(false);
        co.onHome = true;
    }


    public int haveFeed = 0;
    public void BuyFeed()
    {
        int money = int.Parse(my_Money.text);
        if (money >= 1)
        {
            money -= 1;
            my_Money.text = money + "";
            haveFeed++;

            spendMoney += 1;
            buyAudio.Play();
        }
    }

    public int haveSnack = 0;

    public void BuySnack()
    {
        int money = int.Parse(my_Money.text);
        if (money >= 2)
        {
            money -= 2;
            my_Money.text = money + "";
            haveSnack++;

            spendMoney += 2;

            buyAudio.Play();
        }
    }

    public int haveToy = 0;

    public GameObject buyToyButton;
    public void BuyToy()
    {
        int money = int.Parse(my_Money.text);
        if (money >= 1)
        {
            money -= 1;
            my_Money.text = money + "";
            haveToy++;

            spendMoney += 1;
            buyToyButton.SetActive(false);
            buyAudio.Play();
        }
        GetComponent<selectPet>().toy.SetActive(true);
    }

    public int havePad = 0;
    public void BuyPad()
    {
        int money = int.Parse(my_Money.text);
        if (money >= 1)
        {
            money -= 1;
            my_Money.text = money + "";
            havePad++;

            spendMoney += 1;
            buyAudio.Play();
        }
    }


    public GameObject onHomeText;
    public TextMeshProUGUI Status;
    public int myRepute = 100;

    public GameObject SelectPet;
    public void ShowMyRepute()
    {
        Status.text = "당신의 평판은 " + myRepute + "입니다. ";
        onHomeText.SetActive(true);
        SelectPet.SetActive(false);
    }
    public void ExitStatus()
    {
        onHomeText.SetActive(false);
        GetComponent<selectPet>().BackToOriginPos();
    }


    public GameObject ending;
    public GameObject home;
    public TextMeshProUGUI endingScore;
    public void Ending() { 
        NextButton.SetActive(false);
        home.SetActive(false);
        ending.SetActive(true);
        endingScore.text = FriendlyPoint + "\n" + myRepute + "\n" + dontFeed +
            "\n\n" + howHungry + "\n" + howSkin + "\n" + howCold +
            "\n\n" + spendMoney + "\n" + my_Money.text;          
    }
}
