using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameItems : MonoBehaviour
{

    private float speedUpAmout = 5f;
    private float changeTime = 7f;

    public bool haveHealItem = false; 
    public bool haveBegItem = false; 
    public bool haveIncreaseItem = false; 
    public bool haveCoinItem = false;

    private InGameBag inGameBag;
    private void Start()
    {
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
        InGameSave.AddCoin(100);
    }
                                
    public void UseSkullItem(){
        InGameSave.AddTime(-changeTime);
    }

    public void UseIncreaseTimeItem()
    {
        InGameSave.AddTime(changeTime);
    }

    public void UseBombItem(){
        CheckBombZone check = GameObject.Find("GameManager").GetComponent<CheckBombZone>();
        check.BombZone();
    }

    public void HaveHealItem(){
        InGameBag useHealItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>();
        useHealItemInSlot.RemoveHealInSlots();
    }

    void RestoreSpeed(){
        InGameSave.SetSpeed(speedUpAmout, false);
    }

    public void HaveBegItem(){
        haveBegItem = false;
        inGameBag.RemoveBegInSlots();
    }

    public void InGameBagRefresh()
    {
        inGameBag.InGameBagRefresh();
    }


}
