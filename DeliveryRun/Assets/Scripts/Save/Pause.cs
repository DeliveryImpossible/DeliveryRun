using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseBox;
    public void ScenePause()
    {
        pauseBox.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        pauseBox.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void NavigateToStartScene()
    {
        pauseBox.SetActive(false);
        SceneManager.LoadScene(ScenesNameConst.startScene);
    }
}
