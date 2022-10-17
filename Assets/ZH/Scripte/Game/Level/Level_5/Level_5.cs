using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_5 : MonoBehaviour
{
    public Animator animTrigger;
    public Transform mouthArea;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnterTrigger;

    private void OnEnable()
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEnterTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnterTrigger = false;
    }

    public void OnBtnMouthDragBegin()
    {
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnMouthDrag()
    {
        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnMouthDragExit()
    {
        if (isEnterTrigger)
        {
            transform.DOMove(mouthArea.position, 1F).OnComplete(() => animTrigger.SetTrigger("Level5Trigger"));
            return;
        };
        transform.DOMove(originPos, 0.5F);
    }


}
