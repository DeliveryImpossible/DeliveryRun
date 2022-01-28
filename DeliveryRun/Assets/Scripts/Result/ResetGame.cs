using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ResetGame : MonoBehaviour
{
    public void GameReset()
    { 
        InitSelectedMapInfo();
        InitPackedItem();
        InGameSave.ResetSave();
    }

    private void InitSelectedMapInfo()
    {
        NowGameMap.nowPlayingDifficulty = 0;
        NowGameMap.nowPlayingMap = 0;
    }

    private void InitPackedItem()
    {
        int[] itemsID = new int[3];

        for (int i = 0; i < 3; i++)
        {
            itemsID[i] = 0;
        }

        JsonData packedItemsData = JsonMapper.ToJson(itemsID);
        File.WriteAllText(FilePath.savePath + "/PackedItemID.json", packedItemsData.ToString());
    }
}
