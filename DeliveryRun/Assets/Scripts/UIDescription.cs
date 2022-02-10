using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDescription : MonoBehaviour
{
    public GameObject firstPanelfirstText;
    public GameObject firstPanelsecondText;
    public GameObject firstPanelfirstButton;
    public GameObject firstPanelsecondButton;

    public GameObject secondPanelfirstText;
    public GameObject secondPanelsecondText;
    public GameObject secondPanelfirstButton;
    public GameObject secondPanelsecondButton;

    public void navigateToSecondAtFirstPanel()
    {
        firstPanelfirstButton.SetActive(false);  
        firstPanelfirstText.SetActive(false);
        firstPanelsecondButton.SetActive(true);
        firstPanelsecondText.SetActive(true);
    }

    public void navigateToSecondAtSecondPanel()
    {
        secondPanelfirstButton.SetActive(false);
        secondPanelfirstText.SetActive(false);
        secondPanelsecondButton.SetActive(true);
        secondPanelsecondText.SetActive(true);
    }
}
