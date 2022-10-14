using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public LevelDataList_SO levelData;
    public RectTransform panelText;
    public Text textTitle;

    // Start is called before the first frame update
    void OnEnable()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int levelID = int.Parse(activeScene.name.Split('_')[1]);
        LevelDetail levelDetail = levelData.GetLevelDetail(levelID);

        // 初始化界面
        panelText.sizeDelta = Vector2.zero;
        textTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(textTitle.fontSize * levelDetail.levelTitle.Length, 50);

        panelText.DOSizeDelta(new Vector2(textTitle.fontSize * levelDetail.levelTitle.Length, 50), 1.5f);
        textTitle.text = levelDetail.levelTitle;
        textTitle.DOFade(1, 3);
    }
}
