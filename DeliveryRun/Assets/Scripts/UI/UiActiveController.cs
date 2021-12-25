using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiActiveController : MonoBehaviour
{
    GameObject UI;
    // Start is called before the first frame update
    void Awake()
    {

        UI = GameObject.FindGameObjectWithTag("UI");
        UI.SetActive(false);
        
    }

    public void SwitchGameUI()
    {
        UI.SetActive(true);
    }
}
