using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelUI : MonoBehaviour
{
    public LevelDataList_SO levelData;

    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;
    public GameObject m_ItemPage;
    public GameObject m_BtnPage;

    private Transform bottomPanel;

    private float mTargetValue;

    private bool mNeedMove = false;

    private const float SMOOTH_TIME = 0.2F;
    private const int PAGA_ITEM_COUNT = 6;

    private float mMoveSpeed = 0f;

    private int mPageCount = 0;
    private int mCurPage = 0;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        mPageCount = Mathf.CeilToInt((float)levelData.levelDetailList.Count / m_ItemPage.transform.childCount);

        Transform contentPanel = this.transform.Find("ContentPanel");
        bottomPanel = GameObject.Find("BottomPanel").transform;

        List<LevelDetail> tempList = levelData.levelDetailList.OrderBy(i => i.levelID).ToList();

        for (int i = 0; i < mPageCount; i++)
        {
            // 初始化页签按钮
            GameObject btn = Instantiate(m_BtnPage, bottomPanel);
            btn.name = "btnPage_" + i.ToString();
            Button btnPage = btn.GetComponent<Button>();
            Text pageText = btnPage.GetComponentInChildren<Text>();
            pageText.text = (i + 1).ToString();
            btnPage.onClick.AddListener(delegate () {
                this.OnBtnPageClick(btn);
            });


            // 初始化关卡
            GameObject page = Instantiate(m_ItemPage, contentPanel);
            page.name = page.name + "_" + i.ToString();

            for (int j = 1; j < 7; j++)
            {
                int index = i * 6 + j;
                Transform level = page.transform.Find("BtnLevel_" + j);
                if (index > tempList.Count)
                {
                    level?.gameObject.SetActive(false);
                    continue;
                }
                level?.gameObject.SetActive(true);
                Text levelText = level.GetComponentInChildren<Text>();
                levelText.text = tempList[index - 1].levelID.ToString();
                Button btnLevel = level.GetComponent<Button>();
                btnLevel.onClick.AddListener(delegate ()
                {
                    this.OnLevelBtnClick(level.gameObject);
                });
            }
        }
        RefreshBtnPage();
    }

    void Update()
    {
        if (mNeedMove)
        {
            if (Mathf.Abs(m_Scrollbar.value - mTargetValue) < 0.01f)
            {
                m_Scrollbar.value = mTargetValue;
                mNeedMove = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);
        }
    }

    public void OnLevelBtnClick(GameObject sender)
    {
        int index = int.Parse(sender.name.Split('_')[1]);
        int level = mCurPage * PAGA_ITEM_COUNT + index;
        TransitionManager.Instance.Transition("LevelScene", "Level_" + level);
    }

    public void OnPointerUp()
    {
        // 判断当前位于哪个区间，设置自动滑动至的位置
        float pageScale = 1f / mPageCount;
        for (int i = 0; i < mPageCount; i++)
        {
            if (m_Scrollbar.value <= (i + 1) * pageScale )
            {
                mTargetValue = i * 1f / (mPageCount - 1);
                mCurPage = i;
                break;
            }
        }
        mNeedMove = true;
        RefreshBtnPage();
    }

    public void OnBtnPageClick(GameObject sender)
    {
        int index = int.Parse(sender.name.Split('_')[1]);
        mTargetValue = index * 1f / (mPageCount - 1);
        mCurPage = index;
        mNeedMove = true;
    }

    public void RefreshBtnPage()
    {
        for (int i = 0; i < bottomPanel.childCount; i++)
        {
            if (i == mCurPage)
            {
                Transform btn = bottomPanel.GetChild(i);
                btn.GetComponent<Button>().Select();
            }
        }
    }

}

