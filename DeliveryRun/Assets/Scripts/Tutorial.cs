using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public static bool showTutorial;
    public GameObject startPanel;
    public GameObject tutorialStartPanel;
    public GameObject tutorialFirstPanel;

    private void Awake()
    {
        if(showTutorial)
        {
            startPanel.SetActive(false);
            tutorialStartPanel.SetActive(true);
            tutorialFirstPanel.SetActive(true);
        }  
    }
    public void StartTutorial()
    {
        showTutorial = true;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void EndTutorial()
    {
        showTutorial = false;
    }
}
