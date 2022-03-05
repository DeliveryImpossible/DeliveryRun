using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSoundEffect : MonoBehaviour
{
    public AudioClip audioCoin;
    public AudioClip audioBeg;
    public AudioClip audioBomb;
    public AudioClip audioBooster;
    public AudioClip audioHeal;
    public AudioClip audioIncreaseTime;
    public AudioClip audioSkull;
    public AudioClip audioEnemy;

    private AudioSource audioSource;
    private InGameItems inGameItems;



    void Start(){
        audioSource = GetComponent<AudioSource>();
        inGameItems = GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>();
    }


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Item"){
            switch(collision.gameObject.name){
                case "Booster(Clone)":
                    audioSource.clip = audioBooster;
                    break;
                case "Coin(Clone)":
                    audioSource.clip = audioCoin;
                    break;
                case "Skull(Clone)":
                    audioSource.clip = audioSkull;
                    break;            
                case "Bomb(Clone)": 
                    audioSource.clip = audioBomb;
                    break;
                case "IncreaseTime(Clone)":
                    audioSource.clip = audioIncreaseTime;
                    break;      
                default:
                    break;
            }
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.gameObject.tag == "Enemy"){ 
            audioSource.clip = audioEnemy;
            audioSource.Play();
            if(inGameItems.haveHealItem == true){
               inGameItems.healItem.SetActive(true);
                inGameItems.HaveHealItem();

            }else{
                inGameItems.UseSkullItem();
            }

            inGameItems.haveHealItem = false;
        }

    }



}
