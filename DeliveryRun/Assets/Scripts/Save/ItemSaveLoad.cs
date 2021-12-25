using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;


public class ItemSaveLoad : MonoBehaviour
{

    private JsonData itemInfoList;
    private ItemCount itemCountInfoMain;

    public void Awake()
    {
        itemInfoList = ItemInfoLoad();
        int itemCountNum = itemInfoList[0][0].Count;
        int hairCountNum = itemInfoList[1][0].Count;
        int outfitCountNum = itemInfoList[2][0].Count;

        itemCountInfoMain = new ItemCount(itemCountNum, hairCountNum, outfitCountNum);

    }

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != ScenesNameConst.mapSelectionScene)
        {
            ItemCountInfoLoad();
            GetComponent<LoadItems>().Refresh();
        }
    }

    //아이템 정보 로드
    public JsonData ItemInfoLoad()
    {
        TextAsset tempGoodsJsonString = Resources.Load<TextAsset>("ItemList");
        itemInfoList = JsonMapper.ToObject(tempGoodsJsonString.ToString());
        return itemInfoList;
    }

    public JsonData GetJsonData()
    {
        return itemInfoList;
    }

    //아이템 개수 로드
    public void ItemCountInfoLoad()
    {
        if (File.Exists(FilePath.savePath  +"/ItemCount.json"))
        {
            string tempCountJsonString = File.ReadAllText(FilePath.savePath  +"/ItemCount.json");
            ItemCount tempCountData = JsonUtility.FromJson<ItemCount>(tempCountJsonString);
            itemCountInfoMain.SetItemCount(tempCountData);
        }
        else
            return;
    }

    public void CountSave()
    {
        string tempCountJsonString = JsonUtility.ToJson(itemCountInfoMain);
        File.WriteAllText(FilePath.savePath + "/ItemCount.json", tempCountJsonString);
    }

    public ItemCount GetItemCount()
    {
        return itemCountInfoMain;
    }

    public void UpdateItemCount(ItemCount count)
    {
        itemCountInfoMain.SetItemCount(count);
    }

    public void SaveUpdate(ItemCount count)
    {
        UpdateItemCount(count);
        CountSave();
        ItemCountInfoLoad();
        GetComponent<LoadItems>().Refresh();
    }
}

