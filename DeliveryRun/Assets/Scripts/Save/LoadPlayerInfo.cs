using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadPlayerInfo : MonoBehaviour
{
    public static void Load()
    {
        if (File.Exists(FilePath.savePath + "/PlayerInfo.txt"))
        {
            string playerInfoString = File.ReadAllText(FilePath.savePath + "/PlayerInfo.txt");
            PlayerInfoToSave playerInfoToSave = JsonUtility.FromJson<PlayerInfoToSave>(playerInfoString);
            PlayerInfo.SetPlayerInfo(playerInfoToSave.name, playerInfoToSave.coin, playerInfoToSave.level, playerInfoToSave.value, playerInfoToSave.hair, playerInfoToSave.outfit);
        }
        else
            return;
        if (GameObject.FindGameObjectWithTag("Player_Body") != null)
            LoadWearing();
    }

    public static void LoadWearing()
    {
        GameObject hairSet = GameObject.FindGameObjectWithTag("Player_Body").transform.GetChild(0).GetChild(2).gameObject;
        GameObject outfitSet = GameObject.FindGameObjectWithTag("Player_Body").transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        if (PlayerInfo.hair != 0)
            hairSet.transform.GetChild(PlayerInfo.hair-1).gameObject.SetActive(true);
        if (PlayerInfo.outfit != 0)
            outfitSet.transform.GetChild(PlayerInfo.outfit-1).gameObject.SetActive(true);
    }
}
