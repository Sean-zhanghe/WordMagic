using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_12_Event : MonoBehaviour
{
    public Animator animFool;
    public void OnPlayFoolAnim()
    {
        animFool.SetTrigger("FoolTrigger");
    }

    public void OnGameWin()
    {
        EventHandler.CallGameResultTriggerEvent(12, true);
    }
}
