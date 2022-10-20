using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_10_Event : MonoBehaviour
{
    public Animator animWall;
    public Collider2D solider1;
    public Collider2D solider2;
    public Collider2D solider3;

    public void OnLevel10Win()
    {
        EventHandler.CallGameResultTriggerEvent(10, true);
    }

    public void OnWallAnim()
    {
        animWall.SetTrigger("Level10WallTrigger");
    }

    public void OnSolider1Drop()
    {
        solider1.enabled = false;
    }

    public void OnSolider2Drop()
    {
        solider2.enabled = false;
    }

    public void OnSolider3Drop()
    {
        solider3.enabled = false;
    }
}
