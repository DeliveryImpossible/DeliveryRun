using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseBox;
    private ButtonSceneChange buttonSceneChange;
    private void Start()
    {
        buttonSceneChange = GameObject.FindGameObjectWithTag("Manager").GetComponent<ButtonSceneChange>();
    }

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
        buttonSceneChange.MainMenu();
    }
}
