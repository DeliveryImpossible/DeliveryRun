using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;

namespace DifficultSet
{
    class Difficulty
    {
        public static string[] difficultyNameString = { "EASY", "NORMAL", "HARD" };
    }
}

/*언어 예외 두어야 하는 스크립트*/
public class LoadGameScene : MonoBehaviour
{
    public GameObject mapSelectAskPanel;
    private int[] packedItemIds;
    private Text askPanelText;
    private JsonData itemDataJson;
    private int nowDifficulty;

    private AudioManager audioManager;
    private GetPackedItems getPackedItems;

    private void Start()
    {
        getPackedItems = GameObject.FindGameObjectWithTag("Manager").GetComponent<GetPackedItems>();
        packedItemIds = getPackedItems.GetPackedItemIDs();
        askPanelText = mapSelectAskPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        itemDataJson = GetComponent<ItemSaveLoad>().ItemInfoLoad();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void AskPanelInDifficultCircle(int difficulty)
    {
        nowDifficulty = difficulty;

        mapSelectAskPanel.SetActive(true);

        askPanelText.text = "<아이템>\n";

        if (packedItemIds[0] == 0)
        {
            askPanelText.text += "현재 장착한 아이템이 없습니다.\n";
        }
        else
        {
            askPanelText.text += ExtractItemName(0);
            if (packedItemIds[1] != 0)
                askPanelText.text += ", " + ExtractItemName(1);
            if (packedItemIds[2] != 0)
                askPanelText.text += ", " + ExtractItemName(2);
            askPanelText.text += "\n";
        }


        askPanelText.text += "<맵>\n";
        askPanelText.text += MapName.GetMapName(MapSelectIndex.currentMap) + " - ";
        askPanelText.text += DifficultSet.Difficulty.difficultyNameString[difficulty-1];
        askPanelText.text += "\n\n이대로 시작하시겠습니까?";
    }


    public void LoadGame()
    {
        int mapToLaod = MapSelectIndex.currentMap;
        NowGameMap.nowPlayingDifficulty = nowDifficulty;
        NowGameMap.nowPlayingMap = MapSelectIndex.currentMap;
        if(audioManager != null)
            audioManager.ChangeMusic(mapToLaod);
        SceneManager.LoadScene(mapToLaod + 4);
    }

    public void Cancle()
    {
        mapSelectAskPanel.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    private string ExtractItemName(int itemIndex)
    {
        return itemDataJson[0][0][packedItemIds[itemIndex] - 1]["Name"][0]["KOR"].ToString();
    }
}
