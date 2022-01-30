using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CheckRightTarget : MakeReceipt
{
    public List<GameObject> FoundObjects;
    public GameObject enemy;
    GameObject player;
    public string TagName;
    public float shortDis;
    int targetNum;
    int selectedItemIndex;
    string selectedButtonName;
    Button selectedButton;
    public GameObject successPanel;
    public GameObject failPanel;

    private InGameItems inGameItems;
    private SoundEffectManager soundEffectManager;

    private void Start()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
        player = GameObject.FindGameObjectWithTag("Player");
        inGameItems = player.GetComponent<InGameItems>();
        soundEffectManager = GameObject.FindGameObjectWithTag("EffectAudioManager").GetComponent<SoundEffectManager>();
        successPanel.SetActive(false);
        failPanel.SetActive(false);
    }

    public void CheckTarget()
    {
        shortDis = Vector3.Distance(player.transform.position, FoundObjects[0].transform.position);
        enemy = FoundObjects[0];
        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(player.transform.position, found.transform.position);

            if (Distance < shortDis)
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        Debug.Log(enemy.name);

        for (int i = 0; i < NowGameMap.nowPlayingDifficulty + 2; i++)
        {
            if (gameObject.GetComponent<MakeReceipt>().selectedStoreObj[i].name == enemy.name)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (gameObject.GetComponent<MakeReceipt>().totalStoreObj[j].name == gameObject.GetComponent<MakeReceipt>().selectedStoreObj[i].name)
                    {
                        targetNum = j;
                    }
                }

                GameObject[] ItemObj = gameObject.GetComponent<MakeReceipt>().totalMenuObj;

                for (int k = 0; k < ItemObj.Length; k++)
                {
                    if (ItemObj[k].name == selectedButtonName)
                    {
                        selectedItemIndex = k;
                    }

                }

                if (IsRightItem())
                {
                    Success();
                    return;
                }
                else
                {
                    Fail();
                    return;
                }
            }
        }

        Fail();
    }
    private void Success()
    {
        soundEffectManager.OnEffectSound(SoundEffectManager.rightGood);
        InGameSave.SetSuccessNum(1);
        InGameSave.SetCoin(500);

        //성공
        if (DeliverAll())
        {
            SceneManager.LoadScene("10_Result");
        }

        selectedButton.interactable = false;
        successPanel.SetActive(true);
    }
    private void Fail()
    {
        soundEffectManager.OnEffectSound(SoundEffectManager.wrongGood);

        if (InGameItems.haveBegItem == true)
        {
            inGameItems.HaveBegItem();
            //새로고침 필요 여부 확인
        }
        else
        {
            failPanel.SetActive(true);
            inGameItems.UseSkullItem();
        }
    }

    bool IsRightItem()
    {
        return ((targetNum * 3 + 0) <= selectedItemIndex) && ((targetNum * 3 + 2) >= selectedItemIndex);
    }

    bool DeliverAll()
    {
        return InGameSave.GetSuccessNum() == NowGameMap.nowPlayingDifficulty + 2;
    }

    public void CheckSelectedItem()
    {
        selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        selectedButtonName = EventSystem.current.currentSelectedGameObject.name;
    }

}
