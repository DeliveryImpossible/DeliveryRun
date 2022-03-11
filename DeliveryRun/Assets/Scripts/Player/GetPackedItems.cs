using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;

public class GetPackedItems : MonoBehaviour
{
    private int[] packedItemIDs;
    private void Awake()
    {
        LoadAndSetPackedItemIds();
    }

    private void LoadAndSetPackedItemIds()
    {
        if (File.Exists(FilePath.savePath + "/PackedItemID.json"))
        {
            string tempItemIdsString = File.ReadAllText(FilePath.savePath + "/PackedItemID.json");
            packedItemIDs = JsonMapper.ToObject<int[]>(tempItemIdsString);

        }
        else packedItemIDs = new int[] { 0, 0, 0 };
    }

    public int[] GetPackedItemIDs()
    {
        return packedItemIDs;
    }
    public void InitializePackedItem()
    {
        packedItemIDs = new int[PackingItems.bagMaxSize];
        JsonData packedItemsData = JsonMapper.ToJson(packedItemIDs);
        File.WriteAllText(FilePath.resourcePath + "/PackedItemID.json", packedItemsData.ToString());
    }

    public bool CheckResetPackedItem()
    {
        for(int i = 0; i < PackingItems.bagMaxSize; i++)
        {
            if(packedItemIDs[i] != 0)
            {
                return false;
            }
        }
        return true;
    }

   
}
