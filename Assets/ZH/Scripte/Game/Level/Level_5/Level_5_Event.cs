using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_5_Event : MonoBehaviour
{
    public void OnLevel5Win()
    {
        EventHandler.CallGameResultTriggerEvent(5, true);
    }
}
