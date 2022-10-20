using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_11_Event : MonoBehaviour
{

    public Animator animCoins;
    public Transform[] mouths;
    public Transform[] mouthArea;

    public void OnLevel11Win()
    {
        EventHandler.CallGameResultTriggerEvent(11, true);
    }
    
    public void OnCheckGameWin()
    {
        for (int i = 0; i < mouths.Length; i++)
        {
            if (mouths[i].position != mouthArea[i].position) return;
        }
        animCoins.SetTrigger("Level11Trigger");
    }
}
