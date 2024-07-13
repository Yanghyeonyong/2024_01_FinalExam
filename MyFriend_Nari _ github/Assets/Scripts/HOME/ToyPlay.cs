using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlay : MonoBehaviour
{
    //펫과 닿을 경우 오브젝트를 비활성화하게 해주는 함수
    public void OnTriggerEnter(Collider other) { 
    
        if(other.gameObject.tag =="PET")
        {
            this.gameObject.SetActive(false);
        }
    }
}
