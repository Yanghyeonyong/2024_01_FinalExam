using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSound : MonoBehaviour
{
    //UI 버튼 클릭시 사운드를 내는 함수

    public GameObject uiSound;
    private AudioSource uiAudio;
    // Start is called before the first frame update
    void Start()
    {
        uiAudio = uiSound.GetComponent<AudioSource>();
    }
    public void ClickSound() 
    { 
        uiAudio.Play();  
    }
}
