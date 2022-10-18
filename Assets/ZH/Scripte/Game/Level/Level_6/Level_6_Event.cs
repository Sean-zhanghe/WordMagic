using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_Event : MonoBehaviour
{
    public void OnAnimationFinish()
    {
        var level6 = GameObject.Find("BtnGod").GetComponent<Level_6>();
        level6.Stop();
        Invoke("OnLevel6Win", 1);
    }

    public void OnLevel6Win()
    {
        EventHandler.CallGameResultTriggerEvent(6, true);
    }
}
