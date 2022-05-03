using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDescription : MonoBehaviour
{
    public GameObject firstPanelfirstText;
    public GameObject firstPanelsecondText;
    public GameObject firstPanelfirstButton;
    public GameObject firstPanelsecondButton;

    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject secondPanelfirstText;
    public GameObject secondPanelsecondText;

    public void navigateToSecondText()
    {
        firstPanelfirstButton.SetActive(false);  
        firstPanelfirstText.SetActive(false);
        firstPanelsecondButton.SetActive(true);
        firstPanelsecondText.SetActive(true);
    }
    public void navigateToSecondAtSecondPanel()
    {
        secondPanelfirstText.SetActive(false);
        secondPanelsecondText.SetActive(true);
    }

    public void navigateToSecondPanel()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }
}
