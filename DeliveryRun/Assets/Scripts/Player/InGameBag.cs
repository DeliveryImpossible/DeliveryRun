using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.UI;

public class InGameBag : MonoBehaviour
{
    private List<GameObject> itemSlots = new List<GameObject>();

    private int noItemInSlot = 0;
    // private int boosterID = 1;
    // private int coinID = 2; 
    private int increaseTimeID = 3;
    private int begID = 4;
    private int healID = 5;
    private int bombID = 6;
    // private int skullID = 7; 
    private int totalItemsAmount = 7;

    int[] inInventoryBagItemsIDs;
    public GameObject inGameBagSlots; 

    public AudioClip audioClickItem;
    public AudioSource audioSource;

    private void Start()
    {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("Item");

        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        inInventoryBagItemsIDs = manager.GetComponent<GetPackedItems>().GetPackedItemIDs();
        
        if(inInventoryBagItemsIDs[0] != 0){
            for(int i = 0; i<totalItemsAmount; i++){
                if(allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[0] || allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[1] || allItems[i].GetComponent<ItemInfo>().id == inInventoryBagItemsIDs[2]){
                    itemSlots.Add(allItems[i]);
                }
            }
        }
        Refresh();
    }

    

    public void TabAndUseItem(int index){ 
        if(index >= itemSlots.Count){
            return;
        }
        else if(inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id != noItemInSlot && inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id != increaseTimeID &&inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id != begID && inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id != healID){
            audioSource.clip = audioClickItem;
            audioSource.Play();

            switch(inGameBagSlots.transform.GetChild(index).GetComponent<ItemInfo>().id){
                case 1: 
                    InGameItems.UseBoosterItem();
                    Invoke("ReturnSpeed", 4f);
                    break;
                case 2:
                    InGameItems.AddCoinItem();
                    break;
                case 6:
                    InGameItems.UseBombItem();
                    break;
                case 7:     
                    InGameItems.UseSkullItem();
                    break; 
            }
            itemSlots.RemoveAt(index);
            Refresh();
        }
    }

    private void ReturnSpeed(){ 
        Joystick.moveSpeed -= InGameItems.speedUpAmout;
    }

    private void Refresh(){ // 슬롯에 새고해 보여주기
        int i = 0;
        for(; i<itemSlots.Count; i++){
            Debug.Log(itemSlots.Count);
            Image inGameitemInBag = inGameBagSlots.transform.GetChild(i).GetChild(0).GetComponent<Image>(); 

            if(itemSlots[i].GetComponent<ItemInfo>().id == bombID){
                inGameitemInBag.sprite = itemSlots[i].transform.GetChild(5).GetComponent<Image>().sprite;
            }
            else{
                inGameitemInBag.sprite = itemSlots[i].transform.GetChild(1).GetComponent<Image>().sprite; 
                // beg, heal, increasetime 아이템 있는 경우 
                if(itemSlots[i].GetComponent<ItemInfo>().id == begID){ 
                    InGameItems.haveBegItem = true;
                }
                if(itemSlots[i].GetComponent<ItemInfo>().id == healID){ 
                    InGameItems.haveHealItem = true;
                }
                if(itemSlots[i].GetComponent<ItemInfo>().id == increaseTimeID){ 
                    InGameItems.haveIncreaseItem = true;
                }
            }
                
            inGameitemInBag.color = new Color(1, 1, 1, 1);

            inGameBagSlots.transform.GetChild(i).GetComponent<ItemInfo>().id = itemSlots[i].transform.GetComponent<ItemInfo>().id;

        }

        while(i<3){
            Image inGameitemInBag = inGameBagSlots.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            inGameitemInBag.sprite = null;
            inGameitemInBag.color = new Color(0,0,0,0);
            i++;
        }
    }

    
    // heal, beg, IncreaseTime 아이템 자동 사용
    public void RemoveHealInSlots(){ 
        for(int i = 0; i<itemSlots.Count; i++){
            if(itemSlots[i].GetComponent<ItemInfo>().id == healID){
                itemSlots.Remove(itemSlots[i]);
            }
        }
        Refresh();
    }

    public void RemoveBegInSlots(){
        for(int i = 0; i<itemSlots.Count; i++){
            if(itemSlots[i].GetComponent<ItemInfo>().id == begID){
                itemSlots.Remove(itemSlots[i]);
            }
        }
        Refresh();
    }

    public void inGameRemoveIncreaseTime(){
        for(int i = 0; i<itemSlots.Count; i++){
            if(itemSlots[i].GetComponent<ItemInfo>().id == increaseTimeID){
                itemSlots.Remove(itemSlots[i]);
            }
        }
        Refresh();
    }
   
    
}
