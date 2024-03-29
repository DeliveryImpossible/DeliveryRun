﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialInfo
{
    public static int playnum = 0;
}

public class Tutorial : MonoBehaviour
{
   
    public GameObject startPanel;
    public GameObject tutorialStartPanel;
    public GameObject tutorialFirstPanel;

    private void Awake()
    {
        if(TutorialInfo.playnum == 0)
        {
            startPanel.SetActive(false);
            tutorialStartPanel.SetActive(true);
            tutorialFirstPanel.SetActive(true);
            OffTutorial();
        }
    }
    public void OffTutorial()
    {
        TutorialInfo.playnum = 1;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}
