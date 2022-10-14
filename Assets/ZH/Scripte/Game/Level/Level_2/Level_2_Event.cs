using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_Event : MonoBehaviour
{
    public void OnLevel2Win()
    {
        EventHandler.CallGameResultTriggerEvent(2, true);
    }
}
