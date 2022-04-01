using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool IsPause = false;
    public GameObject PauseButton;

    public void ScenePause()
    {
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
    }
    
    public void NavigateToStartScene()
    {
        SceneManager.LoadScene(ScenesNameConst.startScene);
    }
}
