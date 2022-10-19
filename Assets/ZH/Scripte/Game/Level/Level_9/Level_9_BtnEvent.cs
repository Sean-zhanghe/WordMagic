using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_9_BtnEvent : MonoBehaviour
{
    public Level_9 lv9;
    public Transform targetArea;
    public Transform panelFrog;
    public bool isDrag;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnterArea;

    private void OnEnable() 
    {
        originPos = transform.position;
    }

    public void OnBtnDragBegin()
    {
        isDrag = true;
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnDrag()
    {
        if (!lv9.isStart) return;
        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        isDrag = false;
        if (isEnterArea)
        {
            transform.DOMove(targetArea.position, 0.5f).OnComplete(() => lv9.CheckGameWin());
            transform.SetParent(panelFrog);
            return;
        }
        transform.DOMove(originPos, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name != targetArea.name) return;
        isEnterArea = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.name != targetArea.name) return;
        isEnterArea = false;
    }

}
