using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{

    private GameObject thisSceneManager;
    private int nowSceneIndex;
    private void Start()
    {
        nowSceneIndex = SceneManager.GetActiveScene().buildIndex;
        thisSceneManager = GameObject.FindGameObjectWithTag("SpecialManager");
    }
    public void MainMenu()
    {
        Save();
        if(nowSceneIndex == ScenesNameConst.inventoryScene)
            SavePackedItems(true);
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
