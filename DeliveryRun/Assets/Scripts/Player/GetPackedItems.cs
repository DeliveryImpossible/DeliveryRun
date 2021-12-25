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

    //##분명히 쓰이는 곳이 있어야 하는데 용도 파악 불가
    public void Initialize()
    {
        packedItemIDs = new int[3];
        JsonData packedItemsData = JsonMapper.ToJson(packedItemIDs);
        File.WriteAllText(FilePath.resourcePath + "/PackedItemID.json", packedItemsData.ToString());
    }

   
}
