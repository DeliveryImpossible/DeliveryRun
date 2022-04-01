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
        InGameSave.AddTime(limitTime);
        if( GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveIncreaseItem == true){
            inGameItems.UseIncreaseTimeItem();
            InGameBag usehaveIncreaseItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>(); 
            usehaveIncreaseItemInSlot.InGameRemoveIncreaseTime(); 
             GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveIncreaseItem = false;
        }
    }

    public void Update()
    {   
        InGameSave.AddTime(-Time.deltaTime);

        if((int)InGameSave.GetTime() % 60 < 10){
            timerText.text = (int)InGameSave.GetTime() / 60 + " : 0" + (int)InGameSave.GetTime() % 60;
        }else{
            timerText.text = (int)InGameSave.GetTime() / 60 + " : " + (int)InGameSave.GetTime() % 60;
        }

        if(InGameSave.GetTime() > limitTime){
            loadingBar.color = Color.blue;
        }
        else if (InGameSave.GetTime() >= 1)
        {
            loadingBar.color = Color.red;
        }
        else
        {
            SceneManager.LoadScene(ScenesNameConst.resultScene);
        }

        loadingBar.fillAmount = (InGameSave.GetTime() - 1) / limitTime;
    }
}
