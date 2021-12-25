using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectIndex : MonoBehaviour
{
    const int oneMapWidth = 30;
    const int mapSelectHeight = -15;

    public static int currentMap;
    private int totalMapCount;
    public GameObject buttonSet;

    private Button previousButton;
    private Button nextButton;

    private void Awake()
    {
        previousButton = buttonSet.transform.GetChild(0).gameObject.GetComponent<Button>();
        nextButton = buttonSet.transform.GetChild(1).gameObject.GetComponent<Button>();
    }

    public void SetIndexAtMapSelectPage(int mapIndex, int totalMapCount)
    {
        if (mapIndex == 0)
            currentMap = 1;
        else
            currentMap = mapIndex;
        this.totalMapCount = totalMapCount;
        AdjustViewMap();
    }

    public void ChangeMapByArrowButton(int change)
    {
        currentMap += change;
        GetComponent<MapLockUnLocked>().SetMapSelectPageLockUnlock();
        AdjustViewMap();
    }

    private void AdjustViewMap()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.transform.position = new Vector3((currentMap - 1) * oneMapWidth, 0, mapSelectHeight);

        if(currentMap == 1)
        {
            previousButton.interactable = false;
        }
        else if (currentMap == totalMapCount)
        {
            nextButton.interactable = false;
        }
        else
        {
            previousButton.interactable = true;
            nextButton.interactable = true;
        }
    }

    public int GetCurrentMap()
    {
        return currentMap;
    }
}
