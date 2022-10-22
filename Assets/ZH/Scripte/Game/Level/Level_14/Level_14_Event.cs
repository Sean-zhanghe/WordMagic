using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_14_Event : MonoBehaviour
{
    public Animator animFamily;
    public Transform family;
    public Transform btnBro;
    public Transform btnSis;

    public void OnSisterDown()
    {
        btnBro.SetParent(family);
        btnSis.SetParent(family);
        animFamily.SetTrigger("familyTrigger");
    }

    public void OnGameWin()
    {
        EventHandler.CallGameResultTriggerEvent(14, true);
    }
}
