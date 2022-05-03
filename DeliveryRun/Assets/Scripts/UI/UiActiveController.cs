using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiActiveController : MonoBehaviour
{
    public bool isStart;
    GameObject UI;
    
    GameObject targetManager;
    Tutorial tutorial;

    void Awake()
    {
        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        isStart = false;
        tutorial = GetComponent<Tutorial>();
        UI = GameObject.FindGameObjectWithTag("UI");
        UI.SetActive(false);
        
    }

    public void SwitchGameUI()
    {
        if (tutorial.CheckTutorial() == 0)
        {
            tutorial.tutorialSecondPanel.SetActive(true);
        }
        /****
         * 김예진 2022 01 23
         * 계속 화면 각도 오류가 나는데 마땅히 둘 곳을 못찾겠어서 여기에 씀
         ****/
        RotateCam rotateCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RotateCam>();
        rotateCam.SetAimY();


        UI.SetActive(true);
        isStart = true;
        CheckDeliverZone checkDeliverZone = targetManager.GetComponent<CheckDeliverZone>();
        checkDeliverZone.MakeStorePos();
    }
}
