using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataList_SO", menuName = "Data/LevelDataList_SO")]
public class LevelDataList_SO : ScriptableObject
{
    public List<LevelDetail> levelDetailList;

    public LevelDetail GetLevelDetail(int levelID)
    {
        return levelDetailList.Find(i => i.levelID == levelID);
        
    }
}

[Serializable]
public class LevelDetail 
{
    public int levelID;
    public Sprite levelSprite;
    public string levelTitle;
    public string levelWin;
}
