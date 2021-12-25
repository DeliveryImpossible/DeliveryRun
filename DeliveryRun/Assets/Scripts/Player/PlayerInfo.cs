using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    public static string name = "user";
    public static int coin = 0;
    public static int level = 1;
    public static int exp = 0;
    public static int hair = 0;
    public static int outfit = 0;

    public static void SetPlayerInfo(string name, int coin, int level, int exp, int hair, int outfit)
    {
        PlayerInfo.name = name;
        PlayerInfo.coin = coin;
        PlayerInfo.level = level;
        PlayerInfo.exp = exp;
        PlayerInfo.hair = hair;
        PlayerInfo.outfit = outfit;
    }

    public static void AddCoin(int coinToAdd)
    {
        coin += coinToAdd;
        ViewUpdatedPlayerStat();
    }

    public static bool AddExp(int expToAdd)
    {
        exp += expToAdd;
        return UpdateLevel();
    }

    public static bool UpdateLevel()
    {
        int totalExp = level * 10000;
        bool levelUp = false;
        if (exp > totalExp)
        {
            exp -= totalExp;
            level++;
            levelUp = true;
        }
        ViewUpdatedPlayerStat();
        return levelUp;
    }

    public static void ViewUpdatedPlayerStat()
    {
        PlayerStatView playerStatView = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerStatView>();
        playerStatView.StatUpdate();
    }
}