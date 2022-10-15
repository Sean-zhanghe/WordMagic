using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level_4_Event : MonoBehaviour
{
    public Transform btnPoint1;
    public Transform btnPoint2;
    public Transform pointTarget1;
    public Transform pointTarget2;

    private Vector3 offsetPos;
    private Vector3 point1OldPos;
    private Vector3 point2OldPos;
    private bool isBackPos1 = true;
    private bool isBackPos2 = true;
    private bool isPoint1Enter;
    private bool isPoint2Enter;


    private void OnEnable()
    {
        if (this.name == "BtnPoint1")
        {
            btnPoint1.DOMove(pointTarget1.position, 2F).SetId("point1MoveTween").SetLoops(-1);
            btnPoint1.GetComponent<Image>().DOFade(1, 1F).SetId("point1FadeTween").SetLoops(-1, LoopType.Yoyo);
        }

        if (this.name == "BtnPoint2")
        {
            btnPoint2.DOMove(pointTarget2.position, 2F).SetId("point2MoveTween").SetLoops(-1);
            btnPoint2.GetComponent<Image>().DOFade(1, 1F).SetId("point2FadeTween").SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void OnBtnPointDragBegin()
    {
        offsetPos = transform.position - Input.mousePosition;
        if (transform.name == "BtnPoint1")
        {
            DOTween.Pause("point1MoveTween");
            DOTween.Pause("point1FadeTween");
            point1OldPos = transform.position;
        }

        if (transform.name == "BtnPoint2")
        {
            DOTween.Pause("point2MoveTween");
            DOTween.Pause("point2FadeTween");
            point2OldPos = transform.position;
        }
    }

    public void OnBtnPointDrag()
    {
        if (this.name == "BtnPoint1" && !isBackPos1) return;
        if (this.name == "BtnPoint2" && !isBackPos2) return;

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnPointDragExit()
    {
        if (this.name == "BtnPoint1")
        {
            if (isPoint1Enter) return;
            if (!isBackPos1) return;

            isBackPos1 = false;
            transform.DOMove(point1OldPos, 1F).OnComplete(() => { 
                DOTween.Play("point1MoveTween");
                DOTween.Play("point1FadeTween");
                isBackPos1 = true;
            });
        }

        if (this.name == "BtnPoint2")
        {
            if (isPoint2Enter) return;
            if (!isBackPos2) return;

            isBackPos2 = false;
            transform.DOMove(point2OldPos, 1F).OnComplete(() => {
                DOTween.Play("point2MoveTween");
                DOTween.Play("point2FadeTween");
                isBackPos2 = true;
            });
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1111111111111111");
        Debug.Log(this.name);
        Debug.Log(collision.name);

        if (this.name == "BtnPoint1")
        {
            if (collision.name == "Point1Area")
            {
                isPoint1Enter = true;

            }
        }

        if (this.name == "BtnPoint1")
        {
            if (collision.name == "Point2Area")
            {
                isPoint2Enter = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.name == "BtnPoint1")
        {
            if (collision.name == "Point1Area")
            {
                isPoint1Enter = false;
            }
        }

        if (this.name == "BtnPoint2")
        {
            if (collision.name == "Point2Area")
            {
                isPoint2Enter = false;
            }
        }
    }

}
