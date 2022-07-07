using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class TutorialInfo
{
    public static bool isPlayed = false;
}

public class Tutorial : MonoBehaviour
{
   
    public UnityEngine.UI.Button startPanelBtn;
    public GameObject tutorialStartPanel;

    private void Awake()
    {
        Debug.Log("튜토리얼 열렸었나요? " + TutorialInfo.isPlayed);
        if(!TutorialInfo.isPlayed)
        {
            startPanelBtn.enabled = false;
            tutorialStartPanel.SetActive(true);
            OffTutorial();
        }
    }

    public bool CheckTutorial()
    {
        return TutorialInfo.isPlayed;
    }
    public void OffTutorial()
    {
        TutorialInfo.isPlayed = true;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void MakeToStartGame()
    {
        startPanelBtn.enabled = true;
    }
}
