using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level_13 : MonoBehaviour
{
    public Transform nest;
    public Animator animBird;
    public string birdTrigger;
    public string birdFly;

    private const int FLY_COUNT = 3;
    private int clickCount = 0;

    public void OnBtnFruit()
    {
        nest.DOMove(new Vector3(nest.position.x - 10, nest.position.y, nest.position.z), 0.2f).OnComplete(() => {
            nest.DOMove(new Vector3(nest.position.x + 20, nest.position.y, nest.position.z), 0.2f).OnComplete(() => {
                nest.DOMove(new Vector3(nest.position.x - 10, nest.position.y, nest.position.z), 0.2f);
            });
        }).SetLoops(5);
    }

    public void OnBtnBirdClick()
    {
        if (clickCount >= FLY_COUNT)
        {
            animBird.SetTrigger(birdFly);
            return;    
        }
        clickCount++;
        animBird.SetTrigger(birdTrigger);
    }

}
