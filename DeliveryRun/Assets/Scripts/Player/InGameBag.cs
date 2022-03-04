using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.UI;

public class InGameBag : MonoBehaviour
{
    private List<GameObject> packedItemList = new List<GameObject>();

    private const int noItemInSlot = 0;
    private const int boosterID = 1;
    private const int coinID = 2; 
    private const int increaseTimeID = 3;
    private const int begID = 4;
    private const int healID = 5;
    private const int bombID = 6;
    private const int skullID = 7; 
    private const int totalItemsAmount = 7;
    private const int totalPackedItemsAmount = 6;

    int[] inInventoryBagItemsIDs;
    public GameObject inGameBagSlots;

    private SoundEffectManager soundEffectManager;
    private InGameItems inGameItems;

    private void Start()
    {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("ItemInBag");
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        inInventoryBagItemsIDs = manager.GetComponent<GetPackedItems>().GetPackedItemIDs();

        soundEffectManager = GameObject.FindGameObjectWithTag("EffectAudioManager").GetComponent<SoundEffectManager>();
        inGameItems = GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>();

        PackedItemArrToList(allItems);
        InGameBagRefresh();
    }

    public void TabAndUseItem(int index){ 
        int gameSlotID = inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id;

        if (index >= packedItemList.Count){
            return;
        }
        else if(CheckAutoItem(gameSlotID))
        {
            soundEffectManager.OnEffectSound(SoundEffectManager.itemClick);

            switch (gameSlotID)
            {
                case 1:
                    inGameItems.UseBoosterItem();
                    break;
                case 2:
                    inGameItems.AddCoinItem();
                    break;
                case 6:
                    inGameItems.UseBombItem();
                    break;
                case 7:
                    inGameItems.UseSkullItem();
                    break; 
            }

            packedItemList.RemoveAt(index);
            InGameBagRefresh();
        }
    }

    public void InGameBagRefresh(){
        int i = 0;
        bool isAutoItem = false;

        Transform slot;
        Image inGameitemInBag;

        for (; i<packedItemList.Count; i++)
        {
            slot = inGameBagSlots.transform.GetChild(i);
            slot.GetChild(1).gameObject.SetActive(false);
            slot.gameObject.GetComponent<Button>().interactable = true;

            inGameitemInBag = slot.GetChild(0).GetComponent<Image>(); 

            inGameitemInBag.sprite = packedItemList[i].GetComponent<Image>().sprite;
            isAutoItem = CheckAutoItem(i);

            if (isAutoItem)
            {
                slot.GetChild(1).gameObject.SetActive(true);
                slot.gameObject.GetComponent<Button>().interactable = false;

                inGameitemInBag.color = new Color(1, 1, 1, (float)0.5);
            }
            else
            {
                inGameitemInBag.color = new Color(1, 1, 1, 1);
            }


            inGameBagSlots.transform.GetChild(i).GetComponent<ItemInfo>().id = packedItemList[i].transform.GetComponent<ItemInfo>().id;

        }

        while(i<3)
        {
            slot = inGameBagSlots.transform.GetChild(i);
            slot.GetChild(1).gameObject.SetActive(false);
            slot.gameObject.GetComponent<Button>().interactable = false;

            inGameitemInBag = slot.GetChild(0).GetComponent<Image>();
            inGameitemInBag.sprite = null;
            inGameitemInBag.color = new Color(0,0,0,0);
            i++;
        }
    }
    private void PackedItemArrToList(GameObject[] allItems)
    {
        Debug.Log(allItems.Length);
        if (inInventoryBagItemsIDs[0] != 0)
        {
            for (int i = 0; i < totalPackedItemsAmount; i++)
            {
                if (allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[0] || allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[1] || allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[2])
                {
                    packedItemList.Add(allItems[i]);
                }
            }
        }
    }

    bool CheckAutoItem(int slotOrder)
    {
        if (packedItemList[slotOrder].GetComponent<ItemInfo>().id == begID)
        {
            inGameItems.haveBegItem = true;
            return true;
        }
        else if (packedItemList[slotOrder].GetComponent<ItemInfo>().id == healID)
        {
            inGameItems.haveHealItem = true;
            return true;
        }
        else if (packedItemList[slotOrder].GetComponent<ItemInfo>().id == increaseTimeID)
        {
            inGameItems.haveIncreaseItem = true;
            return true;
        }
        else if (packedItemList[slotOrder].GetComponent<ItemInfo>().id == coinID)
        {  
            inGameItems.haveCoinItem = true;
            return true;
        }
        return false;
    }

    public void RemoveHealInSlots(){ 
        for(int i = 0; i<packedItemList.Count; i++){
            if(packedItemList[i].GetComponent<ItemInfo>().id == healID){
                packedItemList.Remove(packedItemList[i]);
            }
        }
        InGameBagRefresh();
    }

    public void RemoveBegInSlots(){
        for(int i = 0; i<packedItemList.Count; i++){
            if(packedItemList[i].GetComponent<ItemInfo>().id == begID){
                packedItemList.Remove(packedItemList[i]);
            }
        }
        InGameBagRefresh();
    }

    public void InGameRemoveIncreaseTime(){
        for(int i = 0; i<packedItemList.Count; i++){
            if(packedItemList[i].GetComponent<ItemInfo>().id == increaseTimeID){
                packedItemList.Remove(packedItemList[i]);
            }
        }
        InGameBagRefresh();
    }
   
    
}
