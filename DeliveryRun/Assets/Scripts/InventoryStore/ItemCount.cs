using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

[System.Serializable]
public class ItemCount
{
    public int[] itemCounts;
    public Have[] have;

    public ItemCount(int itemNum, int hairNum, int outfitNum)
    {

        int[] itemCounts = new int[itemNum];
        bool[] hairHave = new bool[hairNum];
        bool[] outfitHave = new bool[outfitNum];

        for (int i = 0; i < itemNum; i++)
            itemCounts[i] = 0;
        for (int i = 0; i < hairNum; i++)
            hairHave[i] = false;
        for (int i = 0; i < outfitNum; i++)
            outfitHave[i] = false;

        this.itemCounts = itemCounts;

        have = new Have[2];
        have[0] = new Have(hairHave);
        have[1] = new Have(outfitHave);

    }

    public void SetItemCount(ItemCount itemCount)
    {
        itemCounts = itemCount.itemCounts;
        have = itemCount.have;
    }

}

[System.Serializable]
public class Have
{
    public bool[] haveList;
    public Have(bool[] _haveList)
    {
        haveList = _haveList;
    }
}
