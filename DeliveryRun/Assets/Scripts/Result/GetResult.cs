﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetResult : MonoBehaviour
{
    public GameObject rewardBox;

    private bool win;

    private int coin;
    private int successNum;
    private int leftTime;
    private int star;
    private int exp;
    private bool levelUp;

    //###오디오 소스 밖으로 빼서 하나로 모을 것
    public AudioSource myAudio;
    public AudioClip audioSuccess;
    public AudioClip audioFailed;
    void Start()
    {
        ResetStars();

        coin = InGameSave.GetCoin();
        successNum = InGameSave.GetSuccessNum();
        leftTime = (int)InGameSave.GetTime();

        star = CalculateStar();
        GameObject.FindGameObjectWithTag("Player_Body").GetComponent<ResultAnimation>().StartAnim(win);
        coin = CalculateCoin();
        exp = CalculateEXP();
        levelUp = ReflectResult();

        if (star > 0)
        {
            GameObject stars = rewardBox.transform.GetChild(0).gameObject;
            for (int i = 0; i < star; i++)
                stars.transform.GetChild(i + 3).gameObject.SetActive(true);
        }

        Text gameResult = rewardBox.transform.GetChild(1).GetComponent<Text>();
        if (win){
            //myAudio.clip = audioSuccess;
            myAudio.Play();
            gameResult.text = "SUCCESS";
        }
        else{
            //myAudio.clip = audioFailed;
            myAudio.Play();
            gameResult.text = "FAIL";
        }
            
        Transform rewardList = rewardBox.transform.GetChild(2);
        rewardList.GetChild(0).GetChild(0).GetComponent<Text>().text = coin.ToString();
        rewardList.GetChild(1).GetChild(0).GetComponent<Text>().text = exp.ToString();

        GameObject levelUpSign = rewardList.GetChild(1).GetChild(1).gameObject;
        if (levelUp)
            levelUpSign.SetActive(true);
        else
            levelUpSign.SetActive(false);

        if (win)
            GameResultSave();
        GameReset();
    }

    private void GameResultSave()
    {
        GetComponent<SaveResult>().ConnectResultSave(NowGameMap.nowPlayingMap, NowGameMap.nowPlayingDifficulty, star);

    }

    private void GameReset()
    {
        InGameSave.ResetSave();
        GetComponent<ResetGame>().GameReset();
    }


    private bool ReflectResult()
    {
        
        PlayerInfo.AddCoin(coin);
        bool up = PlayerInfo.AddExp(exp);
        return up;
    }

    private int CalculateEXP()
    {
        if (leftTime > 50) 
            return leftTime * 1000 + successNum * 200;
        else
            return 50;
    }

    private int CalculateStar()
    {
        if(successNum == 0)
        {
            win = false;
            return 0;
        }else
            win = true;
        switch (NowGameMap.nowPlayingDifficulty)
        {
            case 1: 
                if(successNum >= 3)
                    return 3;
                else if(successNum >= 2)
                    return 2;
                else
                    return 1;
            case 2:
                if (successNum >= 4)
                    return 3;
                else if (successNum >= 2)
                    return 2;
                else
                    return 1;
            case 3:
                if (successNum >= 5)
                    return 3;
                else if (successNum >= 3)
                    return 2;
                else
                    return 1;
        }
        return -1;
    }

    private int CalculateCoin()
    {
        if (ResetGame.isCoin)
            coin *= 2;
        return coin;
    }

    private void ResetStars()
    {
        GameObject stars = rewardBox.transform.GetChild(0).gameObject;
        for (int i = 0; i < 3; i++)
            stars.transform.GetChild(i+3).gameObject.SetActive(false);
    }
}
