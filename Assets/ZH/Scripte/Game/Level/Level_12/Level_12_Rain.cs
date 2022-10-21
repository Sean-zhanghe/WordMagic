using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level_12_Rain : MonoBehaviour
{
    public Level_12 lv12;
    public Transform targetArea;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnter;
    private bool isBack = true;     // 是否回到原位置

    private void OnEnable() 
    {
        originPos = transform.position;    
    }

    private void OnDisable()
    {
        DOTween.KillAll();    
    }

    public void OnBtnDragBegin()
    {
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnDrag()
    {
        if (!lv12.isStart) return;

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        if (isEnter && isBack)
        {
            transform.DOMove(targetArea.position, 0.5f).OnComplete(() => lv12.OnCheckRain());
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
