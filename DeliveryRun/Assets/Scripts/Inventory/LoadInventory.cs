using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

//플레이어가 가진 아이템 인벤토리에 로드
public class LoadInventory : LoadItems
{
    private GameObject[] goods;
    private SelectIndex selectIndex;
    private ItemCount itemCount;

    private void Start()
    {
        selectIndex = GetComponent<SelectIndex>();   
    }

    //인벤토리 아이템 로드
    public override void Refresh()
    {
        goods = GameObject.FindGameObjectsWithTag(selectIndex.index.ToString());
        itemCount = GetComponent<ItemSaveLoad>().GetItemCount();


        int selectIndexNum = (int)selectIndex.index;

        ResetGoods(selectIndexNum);

        if (selectIndexNum == ((int)InventoryIndex.Item))
            RefreshItem();
        else
            RefreshGoods(selectIndexNum);

        ExpandInventory();
    }

    private void RefreshItem()
    {
        for (int i = 0; i < goods.Length; i++)
        {
            int id = goods[i].GetComponent<ItemInfo>().id - 1;
            int count;
            if ((count = itemCount.itemCounts[id]) > 0)
            {
                if (GetComponent<PackingItems>().GetPackedItems().Contains(goods[i]))//이 아이템이 가방에 있는 아이템이면
                    count--;
                goods[i].transform.GetChild(1).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = count.ToString();

                if (count > 0)
                    goods[i].transform.SetParent(inventorySlotBox.transform);
            }

        }
    }

    private void RefreshGoods(int selectIndexNum)
    {
        for (int i = 0; i < goods.Length; i++)
        {
            int id = goods[i].GetComponent<ItemInfo>().id - 1;

            if (itemCount.have[selectIndexNum - 1].haveList[id])
                goods[i].transform.SetParent(inventorySlotBox.transform);

        }
    }
}


