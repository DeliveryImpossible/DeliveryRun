using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameItems : MonoBehaviour
{

    public static float speedUpAmout = 3f;
    private static float changeTime = 7f;

    public static GameObject healItem;
    public static GameObject begItem;

    public static bool haveHealItem = false; 
    public static bool haveBegItem = false; 
    public static bool haveIncreaseItem = false; 
    public static bool haveCoinItem = false;

    private InGameBag inGameBag;
    private 


    void Start()
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
        InGameSave.SetSpeed(speedUpAmout);
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
