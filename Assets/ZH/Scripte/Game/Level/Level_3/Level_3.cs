using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level_3 : MonoBehaviour
{
    public Animator animRain;
    public Animator animTrigger;
    public Transform btnMove;

    private Vector3 originPos;
    private Vector3 offsetPos;
    private bool isEnterTrigger;

    private void OnEnable()
    {
        originPos = btnMove.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEnterTrigger = true;
        btnMove.DOMove(transform.position, 1);
        btnMove.GetComponent<Image>().DOFade(0, 1).OnComplete(() => animTrigger.SetTrigger("Level3Trigger"));
    }

    public void OnBtnCloueClick()
    {
        animRain.SetTrigger("Level_3_1");
    }

    public void OnBtnMoveDragBegin()
    {
        offsetPos = btnMove.position - Input.mousePosition;
    }

    public void OnBtnMoveDrag()
    {
        btnMove.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnMoveDragExit()
    {
        if (isEnterTrigger) return;

        btnMove.DOMove(originPos, 0.5F);
    }
}
