using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_11_DownEvent : MonoBehaviour
{
    public bool isStart;

    private const float MOVE_DIS = 50f;
    private Vector3 offsetPos;
    private Vector3 originPos;

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
        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnDragExit()
    {
        Vector3 dragExitPos = transform.position;
        float dis = (dragExitPos - originPos).magnitude;
        if (dis > MOVE_DIS)
        {
            transform.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => {
                isStart = true;
                gameObject.SetActive(false);
            });
        }
        else
        {
            transform.DOMove(originPos, 0.5f);
        }
    }
}
