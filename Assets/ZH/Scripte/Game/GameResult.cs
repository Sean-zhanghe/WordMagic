using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public LevelDataList_SO levelData;
    public Text textResult;

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

        int levelID = int.Parse(from.Split('_')[1]);
        LevelDetail levelDetail = levelData.GetLevelDetail(levelID);

        textResult.GetComponent<RectTransform>().sizeDelta = new Vector3(levelDetail.levelWin.Length * textResult.fontSize, 50);
        textResult.text = levelDetail.levelWin;
        textResult.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 3);
        textResult.DOFade(1, 3);
    }
}
