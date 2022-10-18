using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameCanves;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.GameResultTriggerEvent += OnGameResultTriggerEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.GameResultTriggerEvent -= OnGameResultTriggerEvent;
    }

    public void OnAfterSceneLoadedEvent(string from, string to)
    {
        if (to.Contains("Level_"))
        {
            gameCanves.SetActive(true);
        }
        else
        {
            gameCanves.SetActive(false);
        }
    }

    public void OnGameResultTriggerEvent(int levelID, bool isWin)
    {
        if (isWin)
        {
            TransitionManager.Instance.Transition("Level_" + levelID, "Result");
        }
        else
        {
            TransitionManager.Instance.Transition("Level_" + levelID, "Level_" + levelID);
        }
    }
}
