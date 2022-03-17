using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapInfo
{
    public int totalMapCount = 3;
    public bool[] unlockedMap;
    public Star[] earnedStarByMap;
    public int initalMap = 0;

    public MapInfo()
    {
        unlockedMap = new bool[totalMapCount];
        earnedStarByMap = new Star[totalMapCount];
        
        for(int i = 0; i < totalMapCount; i++)
        {
            unlockedMap[i] = false;
            earnedStarByMap[i] = new Star(new int[]{ 0,0,0 });
        }

        unlockedMap[0] = true;
    }

    public void SetMapInfo(MapInfo mapInfo)
    {
        unlockedMap = mapInfo.unlockedMap;
        earnedStarByMap = mapInfo.earnedStarByMap;
        for(int i = 0; i < totalMapCount; i++)
        {
            if (unlockedMap[i])
                initalMap = i + 1;
            else
                break;
        }
    }

}

[System.Serializable]
public class Star
{
    public int[] starCountArr;
    public Star(int[] starCountArr)
    {
        this.starCountArr = starCountArr;
    }
}
