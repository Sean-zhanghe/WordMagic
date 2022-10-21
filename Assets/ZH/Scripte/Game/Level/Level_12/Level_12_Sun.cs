using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level_12_Sun : MonoBehaviour
{
    public Level_12 lv12;
    public Transform foolWord;
    public Transform targetArea;
    public Animator animSnow1;
    public Animator animSnow2;
    public Animator animSnow3;
    public Animator animSnow4;


    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnter;
    private bool isDrag;
    private bool isBack = true;     // 是否回到原位置

    private void OnEnable() 
    {
        originPos = transform.position;    
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }

    public void OnBtnSunClick()
    {
        if (isDrag) return;
        foolWord.DOScale(new Vector3(1, 0.9f, 1), 0.5f).SetLoops(2, LoopType.Yoyo);
    }

    public void OnBtnDragBegin()
    {
        isDrag = true;
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnDrag()
    {
        if (!lv12.isRainStop) return;

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        isDrag = false;
        if (isEnter && isBack)
        {
            transform.DOMove(targetArea.position, 0.5f).OnComplete(() => {
                transform.DOScale(new Vector3(1.6f, 1.6f, 1), 0.5f).OnComplete(() => {
                    transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.5f).OnComplete(() => {
                        animSnow1.SetTrigger("Snow1Trigger");
                        animSnow2.SetTrigger("Snow2Trigger");
                        animSnow3.SetTrigger("Snow3Trigger");
                        animSnow4.SetTrigger("Snow4Trigger");
                    });
                });
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
