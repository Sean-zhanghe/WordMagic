using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_12 : MonoBehaviour
{
    public Transform imgRain; 
    public Transform[] moutains;
    public Transform[] rains;
    public Transform[] rainAreas;
    public bool isStart;
    public bool isRainStop;

    public void OnCheckGameStart()
    {
        for (int i = 0; i < moutains.Length; i++)
        {
            if (moutains[i].rotation.eulerAngles.z != 90) return;
        }
        isStart = true;
    }

    public void OnCheckRain()
    {
        for (int i = 0; i < rains.Length; i++)
        {
            if (rains[i].position != rainAreas[i].position) return;
        }
        isRainStop = true;
        imgRain.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => {
            imgRain.gameObject.SetActive(false);
        });
    }
}
