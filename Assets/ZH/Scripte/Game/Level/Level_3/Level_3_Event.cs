using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Event : MonoBehaviour
{
    public void OnLevel3Win()
    {
        EventHandler.CallGameResultTriggerEvent(3, true);
    }
}
