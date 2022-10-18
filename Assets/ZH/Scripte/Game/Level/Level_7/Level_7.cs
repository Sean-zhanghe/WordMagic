using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_7 : MonoBehaviour
{
    public Animator animLion1;
    public Animator animLion2;
    public Transform lionArea1;
    public Transform lionArea2;
    public Transform btnLion1;
    public Transform btnLion2;

    private Vector3 offsetPos;
    private Vector3 originLion1Pos;
    private Vector3 originLion2Pos;
    private bool isEnterLion1;
    private bool isEnterLion2;
    private bool isDrag;


    private void OnEnable() {
        if (this.name == "BtnLion1")
        {
            originLion1Pos = transform.position;
        }

        if (this.name == "BtnLion2")
        {
            originLion2Pos = transform.position;
        }
    }

    public void OnBtnLionDragBegin()
    {
        isDrag = true;
        offsetPos = transform.position - Input.mousePosition;
        transform.GetComponent<Animator>().enabled = false;
    }

    public void OnBtnLionDrag()
    {
        if (this.name == "BtnLion1" && transform.position == lionArea1.position) return;
        if (this.name == "BtnLion2" && transform.position == lionArea2.position) return;

        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnLionDragExit()
    {
        isDrag = false;
        if (this.name == "BtnLion1")
        {
            if (isEnterLion1)
            {
                transform.DOMove(lionArea1.position, 0.5f);
                transform.GetComponent<Image>().DOFade(0.5f, 0.5f).OnComplete(() => this.CheckGameWin());
                return;
            }
            transform.DOMove(originLion1Pos, 0.1F).OnComplete(() => transform.GetComponent<Animator>().enabled = true);
        }

        if (this.name == "BtnLion2")
        {
            if (isEnterLion2)
            {
                transform.DOMove(lionArea2.position, 0.5f);
                transform.GetComponent<Image>().DOFade(0.5f, 0.5f).OnComplete(() => this.CheckGameWin());
                return;
            }
            transform.DOMove(originLion2Pos, 0.1F).OnComplete(() => transform.GetComponent<Animator>().enabled = true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "BtnLion1")
        {
            if (other.name == "LionArea1")
            {
                isEnterLion1 = true;
            }
        }

        if (this.name == "BtnLion2")
        {
            if (other.name == "LionArea2")
            {
                isEnterLion2 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
         if (this.name == "BtnLion1")
        {
            if (other.name == "LionArea1")
            {
                isEnterLion1 = false;
            }
        }

        if (this.name == "BtnLion2")
        {
            if (other.name == "LionArea2")
            {
                isEnterLion2 = false;
            }
        }
    }

    public void CheckGameWin()
    {
        if (btnLion1.position != lionArea1.position) return;
        if (btnLion2.position != lionArea2.position) return;
        

        EventHandler.CallGameResultTriggerEvent(7, true);
    }

    public void OnBtnLion1Click()
    {
        if (isDrag) return;
        animLion1.SetTrigger("Lion1Trigger");
    }

    public void OnBtnLion2Click()
    {
        if (isDrag) return;
        animLion2.SetTrigger("Lion2Trigger");
    }
}
