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
                case "Booster":
                    audioSource.clip = audioBooster;
                    break;
                case "Coin":
                    audioSource.clip = audioCoin;
                    break;
                case "Skull":
                    audioSource.clip = audioSkull;
                    break;            
                case "Bomb": 
                    audioSource.clip = audioBomb;
                    break;
                case "IncreaseTime":
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
            if( GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveHealItem == true){
                GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().healItem.SetActive(true);
                inGameItems.HaveHealItem();

            }else{
                inGameItems.UseSkullItem();
            }

             GameObject.FindGameObjectWithTag("Player").GetComponent<InGameItems>().haveHealItem = false;
        }

    }



}
