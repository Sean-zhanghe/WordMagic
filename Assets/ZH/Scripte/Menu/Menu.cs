using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnBtnBackClick()
    {
        Scene activeScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //SceneManager.GetActiveScene();

        if (activeScene.name == "LevelScene")
            TransitionManager.Instance.Transition(activeScene.name, "Menu");
        else
            TransitionManager.Instance.Transition(activeScene.name, "LevelScene");
    }

    public void OnBtnStartGameClick()
    {
        TransitionManager.Instance.Transition("Menu", "LevelScene");
    }

    public void OnBtnQuitClick()
    {
        Application.Quit();
    }
}
