using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlay : MonoBehaviour
{
    //��� ���� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� ���ִ� �Լ�
    public void OnTriggerEnter(Collider other) { 
    
        if(other.gameObject.tag =="PET")
        {
            this.gameObject.SetActive(false);
        }
    }
}
