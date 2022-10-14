using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_1 : MonoBehaviour
{
    public Animator animTrigger;
    public Transform transformPanel;
    public Button btnTrigger;

    private Vector3 originPos;
    private bool isDrag;

    private void OnEnable()
    {
        originPos = transformPanel.position;
    }

    private void Update()
    {
        if (isDrag)
        {
            transformPanel.position = Input.mousePosition;
        }
    }

    public void OnBtnTriggerClick()
    {
        animTrigger.SetTrigger("Level1Trigger");
    }

    public void OnBtnMoveDragBegin()
    {
        isDrag = true;
    }

    public void OnBtnMoveDragExit()
    {
        isDrag = false;
        transformPanel.DOMove(originPos, 0.5F);
    }
}
