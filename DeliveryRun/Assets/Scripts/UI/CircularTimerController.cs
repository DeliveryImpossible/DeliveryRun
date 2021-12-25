using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircularTimerController : MonoBehaviour
{
    public static float limitTime = 80f;
    public Text timerText; 
    public Image loadingBar;
    public GameObject inGamePlayer;
    public GameObject gameOver;
    private float time;
   
    void Start()
    {
        time = limitTime;
        if(InGameItems.haveIncreaseItem == true){ 
            InGameItems.UseIncreaseTimeItem();
            InGameBag usehaveIncreaseItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>(); 
            usehaveIncreaseItemInSlot.inGameRemoveIncreaseTime(); 
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
