using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Controller : MonoBehaviour
{
    //���� �ִϸ��̼��� �����ϵ��� ���ִ� �Լ�
    public Animator animator;

    public void Breath()//������(����)
    {
        animator.SetInteger("AnimationID", 0);
    }
    public void WigglingTail()//(���� ����)(����)
    {
        animator.SetInteger("AnimationID", 1);
    }
    public void Walking01()//�ȱ�(������)
    {
        animator.SetInteger("AnimationID", 2);
    }
    public void Walking02()//�ȱ�(������)
    {
        animator.SetInteger("AnimationID", 3);
    }
    public void Running()//�޸���
    {
        animator.SetInteger("AnimationID", 4);
    }
    public void Eating()//�Ա�
    {
        animator.SetInteger("AnimationID", 5);
    }
    public void Angry()//�����ڼ�
    {
        animator.SetInteger("AnimationID", 6);
    }

    public void Sitting()
    {
        animator.SetInteger("AnimationID", 7);
    }
}
