using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level_4 : MonoBehaviour
{
    public Animator animTrigger;
    public Transform btnPoint1;
    public Transform btnPoint2;
    public Transform pointTarget1;
    public Transform pointTarget2;
    public Transform pointArea1;
    public Transform pointArea2;

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
            transform.DOMove(pointTarget1.position, 2F).SetId("point1MoveTween").SetLoops(-1);
            transform.GetComponent<Image>().DOFade(1, 1F).SetId("point1FadeTween").SetLoops(-1, LoopType.Yoyo);
        }

        if (this.name == "BtnPoint2")
        {
            transform.DOMove(pointTarget2.position, 2F).SetId("point2MoveTween").SetLoops(-1);
            transform.GetComponent<Image>().DOFade(1, 1F).SetId("point2FadeTween").SetLoops(-1, LoopType.Yoyo);
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
            if (isPoint1Enter)
            {
                DOTween.Kill("point1MoveTween");
                DOTween.Kill("point1FadeTween");
                transform.GetComponent<Image>().DOFade(1, 0.1F);
                transform.DOMove(pointArea1.position, 1).OnComplete(() =>
                {
                    this.CheckGameWin();
                });
                return;
            };
            if (!isBackPos1) return;
            isBackPos1 = false;
            transform.DOMove(point1OldPos, 1F).OnComplete(() =>
            {
                DOTween.Play("point1MoveTween");
                DOTween.Play("point1FadeTween");
                isBackPos1 = true;
            });
        }

        if (this.name == "BtnPoint2")
        {
            if (isPoint2Enter)
            {
                DOTween.Kill("point2MoveTween");
                DOTween.Kill("point2FadeTween");
                transform.GetComponent<Image>().DOFade(1, 0.1F);
                transform.DOMove(pointArea2.position, 1).OnComplete(() => {
                    this.CheckGameWin();
                });
                return;
            };
            if (!isBackPos2) return;

            isBackPos2 = false;
            transform.DOMove(point2OldPos, 1F).OnComplete(() =>
            {
                DOTween.Play("point2MoveTween");
                DOTween.Play("point2FadeTween");
                isBackPos2 = true;
            });
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (this.name == "BtnPoint1")
        {
            if (collision.name == "Point1Area")
            {
                isPoint1Enter = true;
            }
        }

        if (this.name == "BtnPoint2")
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

    // 检查游戏是否完成
    private void CheckGameWin()
    {
        if (btnPoint1.position != pointArea1.position) return;
        if (btnPoint2.position != pointArea2.position) return;

        animTrigger.SetTrigger("Level4Trigger");
    }

}
