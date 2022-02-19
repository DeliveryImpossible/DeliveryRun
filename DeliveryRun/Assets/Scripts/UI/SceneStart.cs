using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneStart : MonoBehaviour
{
    void Awake()
    {
        if (File.Exists(FilePath.savePath + "/PlayerInfo.txt"))
        {
            Tutorial.showTutorial = false;

            LoadPlayerInfo.Load();

            if (SceneManager.GetActiveScene().buildIndex == ScenesNameConst.getPlayerNameScene)
            {
                SceneManager.LoadScene(ScenesNameConst.startScene);
            }
        }
        else
        {
            Debug.Log("파일없음");
        }

    }
}
