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

    public AudioClip audioRight;
    public AudioClip audioWrong;
    public AudioSource audioSource;
    private void Start()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
        player = GameObject.FindGameObjectWithTag("Player");
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
                if (isRightItem())
                {
                    audioSource.Play();
                    InGameSave.SetSuccessNum(1);
                    InGameSave.SetCoin(500);

                    if (deliverAll())
                    {
                        InGameSave.SetTime(GameObject.Find("Timer").GetComponent<CircularTimerController>().ReturnTime());
                        SceneManager.LoadScene("10_Result");
                    }

                    selectedButton.interactable = false;
                    successPanel.SetActive(true);
                    return;
                }
                else
                {
                    audioSource.Play();
                    if(InGameItems.haveBegItem == true){
                        InGameItems.haveBegItem = false;
                        Invoke("UseBeg", 1f);
                    }else{
                        failPanel.SetActive(true);
                        InGameItems.UseSkullItem();
                    }
                    return;
                }
            }
        }

        audioSource.Play();
        if(InGameItems.haveBegItem == true){
            InGameItems playerBegItem = GameObject.Find("Player").GetComponent<InGameItems>();
            playerBegItem.HaveBegItem();
            }else{
            failPanel.SetActive(true);
            InGameItems.UseSkullItem();
        }
        failPanel.SetActive(true);
    }

    bool isRightItem()
    {
        return ((targetNum * 3 + 0) <= selectedItemIndex) && ((targetNum * 3 + 2) >= selectedItemIndex);
    }

    bool deliverAll()
    {
        return InGameSave.GetSuccessNum() == NowGameMap.nowPlayingDifficulty + 2;
    }

    public void CheckSelectedItem()
    {
        selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        selectedButtonName = EventSystem.current.currentSelectedGameObject.name;
    }

}
