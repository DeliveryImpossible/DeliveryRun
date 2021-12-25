using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLockUnLocked : MonoBehaviour
{
    public GameObject difficultySet;
    private int currentMap;

    private MapInfo mapInfo;
    private MapSelectIndex mapSelectIndex;

    public void UpdateMapStatus()
    {
        mapInfo = GetComponent<MapInfoLoad>().GetMapInfo();
        mapSelectIndex = GetComponent<MapSelectIndex>();
        mapSelectIndex.SetIndexAtMapSelectPage(mapInfo.initalMap, mapInfo.totalMapCount);

        SetMapSelectPageLockUnlock();
    }

    public void SetMapSelectPageLockUnlock()
    {
        ResetMapSelectPage();
        currentMap = mapSelectIndex.GetCurrentMap();

        if (mapInfo.unlockedMap[currentMap - 1])
        {
            int[] starCountArr = mapInfo.earnedStarByMap[currentMap-1].starCountArr;

            for (int i = 0; i < 3; i++)
            {
                Transform starSet = difficultySet.transform.GetChild(i).GetChild(1);
                for (int j = 0; j < starCountArr[i]; j++)
                {
                    GameObject onStar = starSet.GetChild(j).gameObject;
                    onStar.SetActive(true);
                    GameObject offStar = starSet.GetChild(j + 3).gameObject;
                    offStar.SetActive(false);
                }

                Button difficultyCircle = difficultySet.transform.GetChild(i).GetComponent<Button>();
                difficultyCircle.interactable = true;

                GameObject lockedSticker = difficultySet.transform.GetChild(i).GetChild(2).gameObject;
                lockedSticker.SetActive(false);

                if (starCountArr[i] == 0)
                    break;
            }

        }

    }

    public void ResetMapSelectPage()
    {
        for (int i = 0; i < 3; i++)
        {
            Transform starSet = difficultySet.transform.GetChild(i).GetChild(1);
            for (int j = 0; j < 3; j++)
            {
                GameObject onStar = starSet.GetChild(j).gameObject;
                onStar.SetActive(false);
            }
            for (int j = 3; j < 6; j++)
            {
                GameObject offStar = starSet.GetChild(j).gameObject;
                offStar.SetActive(true);
            }

            Button difficultyCircle = difficultySet.transform.GetChild(i).GetComponent<Button>();
            difficultyCircle.interactable = false;

            GameObject lockedSticker = difficultySet.transform.GetChild(i).GetChild(2).gameObject;
            lockedSticker.SetActive(true);
        }
    }
}
