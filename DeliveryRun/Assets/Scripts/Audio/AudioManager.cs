using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AudioManager : MonoBehaviour
{
    public const int main = 0;
    public const int level1 = 1;
    public const int level2 = 2;
    public const int level5 = 3;
    public const int success = 4;
    public const int fail = 5;

    private AudioSource musicSource;
    public static int scene_flag = 0;

    void Awake()
    {
        musicSource = transform.GetChild(main).GetComponent<AudioSource>();
        musicSource.Play();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusic(int audioNum)
    {
        scene_flag = audioNum;
        musicSource.Stop();
        musicSource = transform.GetChild(audioNum).GetComponent<AudioSource>();
        musicSource.Play();
    }

}
