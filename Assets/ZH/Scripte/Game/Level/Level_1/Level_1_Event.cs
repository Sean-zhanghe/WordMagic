using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Event : MonoBehaviour
{
    public void OnLevel1Win()
    {
        EventHandler.CallGameResultTriggerEvent(1, true);
    }
}
