using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiActiveController : MonoBehaviour
{
    public bool isStart;
    GameObject UI;
    GameObject targetManager;

    void Awake()
    {
        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        isStart = false;
        UI = GameObject.FindGameObjectWithTag("UI");
        UI.SetActive(false);
        
    }

    public void SwitchGameUI()
    {
        UI.SetActive(true);
        isStart = true;
        CheckDeliverZone checkDeliverZone = targetManager.GetComponent<CheckDeliverZone>();
        checkDeliverZone.MakeStorePos();
    }
}
