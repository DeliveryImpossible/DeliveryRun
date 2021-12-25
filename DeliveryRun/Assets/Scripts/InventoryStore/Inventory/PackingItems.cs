using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class PackingItems : MonoBehaviour
{
    const int bagMaxSize = 3;

    public EventSystem eventSystem;
    public GameObject packedItemBagBox;

    private List<GameObject> packedItemList;
    private LoadInventory loadInventory;

    private void Start()
    {
        loadInventory = GetComponent<LoadInventory>();

        LoadBeforePackedItemInfo();

        RefreshBag();
    }

    public void RemoveItem(int itemIndexToRemove)
    {
        if(itemIndexToRemove >= packedItemList.Count)
            return;
        else if (packedItemBagBox.transform.GetChild(itemIndexToRemove).GetComponent<ItemInfo>().id != 0)
        {
            packedItemList.RemoveAt(itemIndexToRemove);
            loadInventory.Refresh();
            RefreshBag();
        }
    }

    public void PackingItem()
    {
        if(packedItemList.Count < bagMaxSize)
        {
            if (!packedItemList.Contains(eventSystem.currentSelectedGameObject))
            {
                packedItemList.Add(eventSystem.currentSelectedGameObject);
                loadInventory.Refresh();
            }
        }
        RefreshBag();
    }
    private void RefreshBag()
    {
        Image itemInBagImg;
        int i = 0;
        for (; i < packedItemList.Count && i < bagMaxSize; i++)
        {
            itemInBagImg = packedItemBagBox.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            Image itemForPackingImg = packedItemList[i].transform.GetChild(0).GetComponent<Image>();
            itemInBagImg.sprite = itemForPackingImg.sprite;
            itemInBagImg.color = new Color(1, 1, 1, 1);

            packedItemBagBox.transform.GetChild(i).GetComponent<ItemInfo>().id = packedItemList[i].transform.GetComponent<ItemInfo>().id;
        }
        while (i < bagMaxSize)
        {
            itemInBagImg = packedItemBagBox.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            itemInBagImg.sprite = null;
            itemInBagImg.color = new Color(0, 0, 0, 0);
            i++;
        }
    }

    public void SaveBagItem()
    {
        int[] itemsIDToSave = new int[bagMaxSize];
        int i = 0;

        for(; i < packedItemList.Count; i++)
        {
            itemsIDToSave[i] = packedItemList[i].GetComponent<ItemInfo>().id;
            GetComponent<RewriteCount>().ChangeNumItem(false, itemsIDToSave[i], -1);
        }
        for(;i < bagMaxSize; i++)
        {
            itemsIDToSave[i] = 0;
        }

        JsonData packedItemsData = JsonMapper.ToJson(itemsIDToSave);
        File.WriteAllText(FilePath.savePath  + "/PackedItemID.json", packedItemsData.ToString());
    }

    public void LoadBeforePackedItemInfo()
    {
        packedItemList = new List<GameObject>();
        int[] savedItemIdArr = GameObject.FindGameObjectWithTag("Manager").GetComponent<GetPackedItems>().GetPackedItemIDs();
        GameObject[] goods = GameObject.FindGameObjectsWithTag("Item");

        if (savedItemIdArr[0] != 0)
        {
            for (int i = 0; i < goods.Length; i++)
            { 
                if (IsItemPacked(savedItemIdArr, goods[i]))
                    packedItemList.Add(goods[i]);
            }
        }

        loadInventory.Refresh();
    }

    private bool IsItemPacked(int[] savedItemIdArr, GameObject goodsForCheck)
    {
        int goodsForCheckId = goodsForCheck.GetComponent<ItemInfo>().id;

        for(int i = 0; i < bagMaxSize; i++)
        {
            if (goodsForCheckId == savedItemIdArr[i])
                return true;
        }
        return false;
    }

    public List<GameObject> GetPackedItems()
    {
        return packedItemList;
    }

}
