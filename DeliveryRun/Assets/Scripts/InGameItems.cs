using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameItems : MonoBehaviour
{

    private float speedUpAmout = 5f;
    private float changeTime = 7f;

    public GameObject healItem;
    public GameObject begItem;

    public bool haveHealItem = false; 
    public bool haveBegItem = false; 
    public bool haveIncreaseItem = false; 
    public bool haveCoinItem = false;

    private InGameBag inGameBag;
    private void Start()
    {
        healItem = GameObject.Find("node_id226");
        //healItem.SetActive(false);
        
        begItem = GameObject.Find("node_id58");
        //begItem.SetActive(false);


        inGameBag = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InGameBag>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            switch(collision.gameObject.name){
                case "Booster(Clone)":
                    UseBoosterItem();
                    Destroy(collision.gameObject);
                    break;
                case "Coin(Clone)":
                    AddCoinItem();
                    Destroy(collision.gameObject);
                    break;
                case "Skull(Clone)":
                    UseSkullItem();
                    Destroy(collision.gameObject);
                    break;     
                case "Bomb(Clone)": 
                    UseBombItem();
                    Destroy(collision.gameObject);
                    break;
                case "IncreaseTime(Clone)":
                    UseIncreaseTimeItem();
                    Destroy(collision.gameObject);
                    break;    
                default:
                    break;
            }
        }
    }

    public void UseBoosterItem(){
        InGameSave.SetSpeed(speedUpAmout, true);
        Invoke("RestoreSpeed", 5f);
    }

    public void AddCoinItem(){
        InGameSave.SetCoin(100);
    }
                                
    public void UseSkullItem(){
        InGameSave.SetTime(-changeTime);
    }

    public void UseIncreaseTimeItem()
    {
        InGameSave.SetTime(changeTime);
    }

    public void UseBombItem(){
        CheckBombZone check = GameObject.Find("GameManager").GetComponent<CheckBombZone>();
        check.BombZone();
    }

    public void HaveHealItem(){
        InGameBag useHealItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>();
        useHealItemInSlot.RemoveHealInSlots();
        Invoke("UseHealItem", 1f);
    }

    void RestoreSpeed(){
        InGameSave.SetSpeed(speedUpAmout, false);
    }

    void UseHealItem(){
        healItem.SetActive(false);
    }

    public void HaveBegItem(){
        begItem.SetActive(true);
        haveBegItem = false;
        Invoke("UseBegItem", 1f);
    }

    void UseBegItem(){
        begItem.SetActive(false);
        inGameBag.RemoveBegInSlots();
    }

    public void InGameBagRefresh()
    {
        inGameBag.InGameBagRefresh();
    }


}
