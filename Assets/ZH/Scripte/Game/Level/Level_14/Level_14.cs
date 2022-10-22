using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_14 : MonoBehaviour
{
    public Animator animSister;
    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;
    public Transform targetArea;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnter;
    private bool isDrag;
    private bool isBack = true;     // 是否回到原位置
    private const float SMOOTH_TIME = 0.2F;

    private bool mNeedMove;
    private float mMoveSpeed = 0f;

    private void OnEnable() 
    {
        originPos = transform.position;
        m_ScrollRect.enabled = false;
    }

    private void Update()
    {
        if (mNeedMove)
        {
            if (m_Scrollbar.value > 0.99f)
            {
                m_Scrollbar.value = 1;
                mNeedMove = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, 1, ref mMoveSpeed, SMOOTH_TIME);
        }
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }

    public void OnBtnSisClick()
    {
        if (m_Scrollbar.value != 0) return;

        animSister.SetTrigger("SisterTrigger");
    }

    public void OnPointerUp()
    {
        Debug.Log(m_Scrollbar.value);
         if (m_Scrollbar.value != 0)
        {
            mNeedMove = true;
        }
        else
        {
            mNeedMove = false;
            m_ScrollRect.enabled = false;
            // animTrigger.SetTrigger("Level2Trigger");
        }
    }

    public void OnBtnDragBegin()
    {
        isDrag = true;
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnDrag()
    {

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        isDrag = false;
        if (isEnter && isBack)
        {
            transform.DOMove(targetArea.position, 0.5f).OnComplete(() => {
                m_ScrollRect.enabled = true;
            });
            return;
        }
        isBack = false;
        transform.DOMove(originPos, 0.5f).OnComplete(() => isBack = true);

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!isBack) return;
        isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        isEnter = false;
    }
}
