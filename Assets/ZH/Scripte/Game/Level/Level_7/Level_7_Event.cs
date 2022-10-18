using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_7_Event : MonoBehaviour
{
    public Animator animDoor;

    public void OnDoorDestroy()
    {
        animDoor.SetTrigger("DoorTrigger");
    }

    public void OnLevel7Fail()
    {
        EventHandler.CallGameResultTriggerEvent(7);
    }
}
