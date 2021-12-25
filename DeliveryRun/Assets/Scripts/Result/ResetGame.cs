using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ResetGame : MonoBehaviour
{
    public static bool isCoin;

    //###코인아이템 있는지 확인하는 변수 이미 있을 것 같은데??
    //##이 아이템 적용 코드 위치도 바꾸고 싶다
    public void IsCoinItem()
    {
        isCoin = false;
        int[] items = GameObject.FindGameObjectWithTag("Manager").GetComponent<GetPackedItems>().GetPackedItemIDs();
        for (int i = 0; i < 3; i++)
        {
            if (items[i] == 2)
            {
                isCoin = true;
                break;
            }
        }

    }

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
