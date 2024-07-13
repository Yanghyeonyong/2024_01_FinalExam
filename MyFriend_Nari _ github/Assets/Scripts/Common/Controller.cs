using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Controller : MonoBehaviour
{
    //펫의 애니메이션을 제어하도록 해주는 함수
    public Animator animator;

    public void Breath()//숨쉬기(서서)
    {
        animator.SetInteger("AnimationID", 0);
    }
    public void WigglingTail()//(꼬리 흔들기)(서서)
    {
        animator.SetInteger("AnimationID", 1);
    }
    public void Walking01()//걷기(느리게)
    {
        animator.SetInteger("AnimationID", 2);
    }
    public void Walking02()//걷기(빠르게)
    {
        animator.SetInteger("AnimationID", 3);
    }
    public void Running()//달리기
    {
        animator.SetInteger("AnimationID", 4);
    }
    public void Eating()//먹기
    {
        animator.SetInteger("AnimationID", 5);
    }
    public void Angry()//전투자세
    {
        animator.SetInteger("AnimationID", 6);
    }

    public void Sitting()
    {
        animator.SetInteger("AnimationID", 7);
    }
}
