using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{

    private GameObject thisSceneManager;
    private int nowSceneIndex;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        nowSceneIndex = SceneManager.GetActiveScene().buildIndex;
        thisSceneManager = GameObject.FindGameObjectWithTag("SpecialManager");
    }
    public void MainMenu()
    {
        Save();
        if(nowSceneIndex == ScenesNameConst.inventoryScene)
            SavePackedItems(true);
        if (AudioManager.scene_flag != 0)
            audioManager.ChangeMusic(AudioManager.main);
        SceneManager.LoadScene(ScenesNameConst.startScene);
    }
    public void Store()
    {
        Save();
        SceneManager.LoadScene(ScenesNameConst.storeScene);
    }
    public void Inventory()
    {
        Save();
        SceneManager.LoadScene(ScenesNameConst.inventoryScene);
    }

    public void GameStart()
    {
        Save();
        if (nowSceneIndex == ScenesNameConst.inventoryScene)
            SavePackedItems(false);
        if(AudioManager.scene_flag!=0)
            audioManager.ChangeMusic(AudioManager.main);
        SceneManager.LoadScene(ScenesNameConst.mapSelectionScene);
    }

    private void Save()
    {
        if (nowSceneIndex == ScenesNameConst.storeScene)
            thisSceneManager.GetComponent<LoadStoreItems>().InitializeCostume();
        SavePlayerInfo.Save();
    }

    private void SavePackedItems(bool itemCountSaveTemp)
    {
        PackingItems packingItems = thisSceneManager.GetComponent<PackingItems>();
        packingItems.SaveBagItem();

        if (!itemCountSaveTemp)
        {
            thisSceneManager.GetComponent<ItemSaveLoad>().CountSave();
        }
    }

}
