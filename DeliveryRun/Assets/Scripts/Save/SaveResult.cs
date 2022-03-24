using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveResult : MonoBehaviour
{
    MapInfoLoad mapInfoLoad;

    private void Awake()
    {
        mapInfoLoad = GetComponent<MapInfoLoad>();
    }

    public void ConnectResultSave(int map, int difficult, int star)
    {
        mapInfoLoad.CountLoad();
        MapInfo mapInfo = mapInfoLoad.GetMapInfo();

        if (difficult == DifficultSet.Difficulty.difficultyLevelMax && map < mapInfo.totalMapCount )
        {
            mapInfo.unlockedMap[map] = true;
        }
        if(mapInfo.earnedStarByMap[map-1].starCountArr[difficult-1] < star)
        {
            mapInfo.earnedStarByMap[map - 1].starCountArr[difficult - 1] = star;
        }

        mapInfoLoad.SaveMapInfo(mapInfo);
    }
}
