using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_11 : MonoBehaviour
{   

    public Level_11_DownEvent downEventClass;
    public Level_11_Event eventClass;
    public Transform targetArea;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnter;
    private bool isDrag;
    private bool isBack = true;     // 是否回到原位置
    private bool isScaleBack = true;    // 按钮大小是否恢复

    private void OnEnable() 
    {
        originPos = transform.position;    
    }

    private void OnDisable()
    {
        DOTween.KillAll();    
    }

    public void OnBtnClick()
    {
        if (isDrag || !isScaleBack) return;
        if (transform.position == targetArea.position) return;

        isScaleBack = false;
        transform.DOScale(new Vector3(1.1f, 1.1f, 1), 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() => isScaleBack = true);
    }

    public void OnBtnDragBegin()
    {
        isDrag = true;
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnDrag()
    {
        if (transform.position == targetArea.position) return;

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        isDrag = false;
        if (downEventClass.isStart && isEnter && isBack)
        {
            transform.DOMove(targetArea.position, 0.5f).OnComplete(() => eventClass.OnCheckGameWin());
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
