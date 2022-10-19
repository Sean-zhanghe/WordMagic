using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_9_Event : MonoBehaviour
{
    
    public void OnLevel9Win()
    {
        EventHandler.CallGameResultTriggerEvent(9, true);
    }
}
