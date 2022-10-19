using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_8_Event : MonoBehaviour
{
    public Transform btnHuman;
    public Transform humanArea;
    public Animator animRabbit;
    public bool isGameStart;

    public void OnCheckGameState()
    {
        isGameStart = true;
        Invoke("OnCheckGameWin", 3f);
    }

    public void OnCheckGameWin()
    {
        if (btnHuman.position == humanArea.position) return;
        isGameStart = false;
        animRabbit.SetTrigger("RabbitRunTrigger");
    }

    public void OnLevel8Fail()
    {
        EventHandler.CallGameResultTriggerEvent(8);
    }

    public void OnLEVEL8Win()
    {
        EventHandler.CallGameResultTriggerEvent(8, true);
    }
}
