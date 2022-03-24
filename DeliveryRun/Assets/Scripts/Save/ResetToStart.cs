using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToStart : MonoBehaviour
{
    public void ResetItemsToStart()
    {
        GetPackedItems getPackedItems = GetComponent<GetPackedItems>();
        getPackedItems.InitializePackedItem();

        InGameSave.ResetSave();
    }
}
