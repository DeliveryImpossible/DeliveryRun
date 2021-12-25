using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Store
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public int storeId;
    public string storeName;
    public Menues[] menues;
}

//[System.Serializable]
public class Menues
{
    public Menu[] menues;
}

public class Menu
{
    public string menu;
}
public class DatabaseManager : MonoBehaviour
{
    public Dictionary<int, Store> storeDic = new Dictionary<int, Store>();
    public int storeNum = NowGameMap.nowPlayingDifficulty;
    public int totalStoreNum;
    void Awake()
    {
        //Store[] stores = GameObject.FindGameObjectWithTag("TargetManager").GetComponent<MakeReceipt>().parseStore("receiptList");
        Store[] stores = parseStore("receiptList");
        for (int i = 0; i < stores.Length; i++)
        {
            storeDic.Add(i, stores[i]);
        }
    }

    public Store[] parseStore(string _FileName)
    {
        List<Store> StoreList = new List<Store>();
        TextAsset storeString = Resources.Load<TextAsset>(_FileName);
        JsonData storeData = JsonMapper.ToObject(storeString.ToString());

        totalStoreNum = storeData.Count; // store 개수

        for (int i = 0; i < totalStoreNum; i++)
        {
            Store store = new Store();
            store.storeName = storeData[i]["storeName"].ToString();
            List<string> contextList = new List<string>();
            for (int j = 0; j < storeData[i]["menus"].Count; j++)
            {
                contextList.Add(storeData[i]["menus"][j]["menu"].ToString());
            }
        }
        return StoreList.ToArray();
    }

    public int getTotalStoreNum()
    {
        return totalStoreNum;
    }

}
