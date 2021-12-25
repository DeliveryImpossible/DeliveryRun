using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    GameObject backgroundMusic;
    AudioSource backMusic;
    public static int scene_flag = 0; // scene 0_GetPlayerName
    void Awake()
    {
        backgroundMusic = GameObject.Find("BackgroundMusic");
        backMusic = backgroundMusic.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);  
    }

    void Update(){
        if(SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7){ // 게임 scene들
           backMusic.Stop();
        }
        if(backMusic.isPlaying) return; // 배경음악이 재생되고 있으면 패스
        else{
            if(SceneManager.GetActiveScene().buildIndex == 1){ // scene 1_start(이름 받지 않고 바로 시작)
            backMusic.Play();
            DontDestroyOnLoad(gameObject); 
            scene_flag++;
            }
        }    
            
    }
    
}
