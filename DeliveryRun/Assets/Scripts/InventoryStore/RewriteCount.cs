using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewriteCount : MonoBehaviour
{
    private ItemSaveLoad saveLoad;

    private void Start()
    {
        saveLoad = GetComponent<ItemSaveLoad>();
    }
    public void ChangeNumItem(bool store, int id, int num)
    {
        ItemCount tempCount = saveLoad.GetItemCount();
        tempCount.itemCounts[id-1] += num;
        if(store)
            saveLoad.SaveUpdate(tempCount);
        else
            saveLoad.UpdateItemCount(tempCount);
    }

    public void ChangeBoolFashion(int index, int id)
    {
        ItemCount tempCount = saveLoad.GetItemCount();
        tempCount.have[index].haveList[id] = true;
        saveLoad.SaveUpdate(tempCount);
    }


}
