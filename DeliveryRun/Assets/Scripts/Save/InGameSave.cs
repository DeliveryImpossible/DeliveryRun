using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InGameSave 
{
    private static bool isUsedCoinItem = false;
    private static int coin = 0;
    private static int successNum = 0;
    private static float time = 0;
    private static float speed = 0;

    public static void SetSpeed(float add, bool booster)
    {
        if(booster){
            speed += add;
        }else{
            speed -= add;
        }
        
    }
    public static void AddCoin(int add)
    {
        coin += add;
    }
    public static void SetSuccessNum(int add)
    {
        successNum += add;
    }
    public static void AddTime(float add)
    {
        time += add;
    }
    public static void SetIsUsedCoinItem(bool isUsed)
    {
        isUsedCoinItem = isUsed;
    }

    public static int GetCoin()
    {
        return coin;
    }
    public static int GetSuccessNum()
    {
        return successNum;
    }
    public static float GetTime()
    {
        return time;
    }
    public static float GetSpeed()
    {
        return speed;
    }
    public static bool GetIsUsedCoinItem()
    {
        return isUsedCoinItem;
    }

    public static void ResetSave()
    {
        coin = 0;
        successNum = 0;
        time = 0;
        speed = 0; 
        isUsedCoinItem = false;
    }
}
