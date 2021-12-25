using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePlayerInfo : MonoBehaviour
{
    public static void Save()
    {
        string playerInfoString = JsonUtility.ToJson(new PlayerInfoToSave());
        File.WriteAllText(FilePath.savePath  +"/PlayerInfo.txt", playerInfoString);

    }
}

[System.Serializable]
class PlayerInfoToSave
{
    public string name;
    public int coin;
    public int level;
    public int value;
    public int hair;
    public int outfit;

    public PlayerInfoToSave()
    {
        name = PlayerInfo.name;
        coin = PlayerInfo.coin;
        level = PlayerInfo.level;
        value = PlayerInfo.exp;
        hair = PlayerInfo.hair;
        outfit = PlayerInfo.outfit;
    }
}

