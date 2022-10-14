using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public LevelDataList_SO levelData;
    public Text textResult;
    public GameObject btnNext;

    private int curLevel;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent(string from, string to)
    {
        if (!from.Contains("Level_")) return;

        curLevel = int.Parse(from.Split('_')[1]);
        LevelDetail levelDetail = levelData.GetLevelDetail(curLevel);

        if (curLevel >= levelData.levelDetailList.Count)
        {
            btnNext.SetActive(false);
        }
        else
        {
            btnNext.SetActive(true);
        }

        textResult.GetComponent<RectTransform>().sizeDelta = new Vector3(50, levelDetail.levelWin.Length * textResult.fontSize);
        textResult.text = levelDetail.levelWin;
        textResult.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 3);
        textResult.DOFade(1, 3);
    }

    public void OnBtnNextClick()
    {
        if (curLevel >= levelData.levelDetailList.Count) return;

        TransitionManager.Instance.Transition("Result", "Level_" + (curLevel + 1));
    }
}
