using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircularTimerController : MonoBehaviour
{
    public float limitTime;

    private Text timerText;
    private Image loadingBar;
    private InGameItems inGameItems;

    private void Awake()
    {
        timerText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        loadingBar = transform.GetChild(0).GetComponent<Image>();
        inGameItems = GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>();
    }
    void Start()
    {
        InGameSave.SetTime(limitTime);
        if( GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveIncreaseItem == true){
            inGameItems.UseIncreaseTimeItem();
            InGameBag usehaveIncreaseItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>(); 
            usehaveIncreaseItemInSlot.InGameRemoveIncreaseTime(); 
             GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveIncreaseItem = false;
        }
    }

    public void Update()
    {
        if (InGameSave.GetTime() > 1)
        {
            InGameSave.SetTime(-Time.deltaTime);
            timerText.text = (int)InGameSave.GetTime() / 60 + " : " + (int)InGameSave.GetTime() % 60;
        }
        else
        {
            //패배
            SceneManager.LoadScene("10_Result");
        }

        loadingBar.fillAmount = (InGameSave.GetTime() - 1) / limitTime;

    }
}
