using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject quitBox;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) { 
            if (!quitBox.activeInHierarchy)
            {
                quitBox.SetActive(true);
                /*언어가 영어라면 바꾸기*/
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        quitBox.SetActive(false);
    }
}
