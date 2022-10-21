using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_13_Event : MonoBehaviour
{
    public GameObject[] Birds;

    public void SetBirdInvisible()
    {
        gameObject.SetActive(false);
        this.CheckGameWin();
    }

    public void CheckGameWin()
    {
        for (int i = 0; i < Birds.Length; i++)
        {
            if (Birds[i].activeSelf) return;
        }
        Invoke("OnGameWin", 1);
    }

    private void OnGameWin()
    {
        EventHandler.CallGameResultTriggerEvent(13, true);
    }
}
