using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_8 : MonoBehaviour
{
    public Animator animRabbit;
    public Transform humanArea;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnterTrigger;

    private void OnEnable() 
    {
        originPos = transform.position;
    }

    public void OnBtnHumanDragBegin()
    {
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnHumanDrag()
    {
        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnHumanDragExit()
    {
        if (isEnterTrigger)
        {
            var level8Event = GameObject.Find("ImgRabbit").GetComponent<Level_8_Event>();
            if (level8Event && level8Event.isGameStart)
            {
                transform.DOMove(humanArea.position, 0.5f);
                transform.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => animRabbit.SetTrigger("RabbitCatchTrigger"));
                animRabbit.SetTrigger("RabbitCatchTrigger");
                return;
            }
        }
        transform.DOMove(originPos, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        isEnterTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        isEnterTrigger = false;
    }

    private void CheckGameWin()
    {

    }
}
