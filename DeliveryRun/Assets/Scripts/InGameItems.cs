using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameItems : MonoBehaviour
{
    public static float speedUpAmout = 2f;
    private static float changeTime = 7f;
    public static GameObject healItem;
    public static GameObject begItem;

    public static bool haveHealItem = false; 
    public static bool haveBegItem = false; 
    public static bool haveIncreaseItem = false; 



    void Start()
    {
        healItem = GameObject.Find("node_id226");
        healItem.SetActive(false);
        
        begItem = GameObject.Find("node_id58");
        begItem.SetActive(false);
    }

    void Update()
    {
        healItem.transform.Rotate(new Vector3(0,30, 0));
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Item"){
            switch(collision.gameObject.name){
                case "Booster":
                    UseBoosterItem();
                    Destroy(collision.gameObject);
                    Invoke("ReturnSpeed", 3f);
                    break;
                case "Coin":
                    AddCoinItem();
                    Destroy(collision.gameObject);
                    break;
                case "Skull":
                    UseSkullItem();
                    Destroy(collision.gameObject);
                    break;            
                case "Bomb": 
                    UseBombItem();
                    Destroy(collision.gameObject);
                    break;
                case "IncreaseTime":
                    UseIncreaseTimeItem();
                    Destroy(collision.gameObject);
                    break;      
                default:
                    break;
            }
        }
    }

    public static void UseBoosterItem(){ 
        Joystick.moveSpeed += speedUpAmout;
    }

    public static void AddCoinItem(){
        InGameSave.SetCoin(100);
    }

    public static void UseSkullItem(){
        CircularTimerController.limitTime -= changeTime;
    }

    public static void UseIncreaseTimeItem(){
        CircularTimerController.limitTime += changeTime;
    }

    public static void UseBombItem(){
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
        haveBegItem = false;
        Invoke("UseBegItem", 1f);
    }

    void UseBegItem(){
        InGameBag useBegItemInSlot = GameObject.Find("GameManager").GetComponent<InGameBag>();
        useBegItemInSlot.RemoveBegInSlots();
    }

    private void ReturnSpeed(){
        Joystick.moveSpeed -= speedUpAmout;
    }


}
