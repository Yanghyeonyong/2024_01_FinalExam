using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSound : MonoBehaviour
{
    //UI ��ư Ŭ���� ���带 ���� �Լ�

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
