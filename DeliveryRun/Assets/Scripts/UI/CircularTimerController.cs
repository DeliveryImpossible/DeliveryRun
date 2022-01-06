using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircularTimerController : MonoBehaviour
{
    public static float limitTime = 80f;
    private Text timerText;
    private Image loadingBar;
    private float time;
    private InGameItems inGameItems;

    private void Awake()
    {
        timerText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        loadingBar = transform.GetChild(0).GetComponent<Image>();
        inGameItems = GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>();
    }
    void Start()
    {
        time = limitTime;
        if(InGameItems.haveIncreaseItem == true){
            inGameItems.UseIncreaseTimeItem();
            InGameBag usehaveIncreaseItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>(); 
            usehaveIncreaseItemInSlot.InGameRemoveIncreaseTime(); 
            InGameItems.haveIncreaseItem = false;
        }
    }

    public void Update()
    {
        if (limitTime > 1)
        {
            limitTime -= Time.deltaTime;
            timerText.text = (int)limitTime / 60 + " : " + (int)limitTime % 60;
        }
        else
        {
            InGameSave.SetTime(limitTime);
            SceneManager.LoadScene("10_Result");
        }

        loadingBar.fillAmount = (limitTime - 1) / time;

    }

    public float ReturnTime(){
        return limitTime;
    }
}
