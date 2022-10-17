using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_Event : MonoBehaviour
{
    public void OnLevel4Win()
    {
        EventHandler.CallGameResultTriggerEvent(4, true);
    }

}
