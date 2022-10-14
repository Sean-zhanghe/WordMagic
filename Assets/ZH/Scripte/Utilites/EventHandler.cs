using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : Singleton<EventHandler>
{
    public static Action<string, string> BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent(string from, string to)
    {
        BeforeSceneUnloadEvent?.Invoke(from, to);
    }

    public static Action<string, string> AfterSceneLoadedEvent;
    public static void CallAfterSceneLoadedEvent(string from, string to)
    {
        AfterSceneLoadedEvent?.Invoke(from, to);
    }

    public static Action<int, bool> GameResultTriggerEvent;
    public static void CallGameResultTriggerEvent(int levelID, bool isWin = false)
    {
        GameResultTriggerEvent?.Invoke(levelID, isWin);
    }
}
