using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_10 : MonoBehaviour
{
    public Animator animWord;
    public Animator animSolders;
    public Transform wordTarget;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnterUp;
    private bool isDrag;
    private bool isFinish;

    private void OnEnable() 
    {
        originPos = transform.position;
    }

    public void OnBtnSoliderClick()
    {
        if (isFinish) return;
        animSolders.SetTrigger("Level10SoliderTrigger");
    }

    public void OnBtnWordClick()
    {
        if (isDrag) return;
        transform.DOMove(wordTarget.position, 1f).SetLoops(2, LoopType.Yoyo);
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
        Vector3 dragExitPos = transform.position;
        transform.DOMove(originPos, 0.5f).OnComplete(() => {
            Debug.Log(isEnterUp);
            Debug.Log("drag exit pos:  " + dragExitPos.y);
            Debug.Log("origin pos:  " + originPos.y);
            if (isEnterUp && dragExitPos.y < originPos.y)
            {
                isFinish = true;
                animWord.enabled = true;
                animWord.SetTrigger("Level10Trigger");
            }
        });
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!isEnterUp && other.name == "UpArea")
        {
            isEnterUp = true;
        }
    }
}
