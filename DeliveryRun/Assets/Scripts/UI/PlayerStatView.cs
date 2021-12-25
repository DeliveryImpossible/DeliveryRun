using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI stat 정보
public class PlayerStatView: MonoBehaviour
{
    public Text nameText;
    public Text coinText;
    public Text levelText;

    public bool IsPlayerStatView;
    private string userName;
    private string coin;
    private string level;

    void Start()
    {
        if (IsPlayerStatView)
        {
            nameText.text = PlayerInfo.name;
            coinText.text = PlayerInfo.coin.ToString();
            levelText.text = PlayerInfo.level.ToString();
        }
    }
    public void StatUpdate()
    {
        userName = PlayerInfo.name;
        coin = PlayerInfo.coin.ToString();
        level = PlayerInfo.level.ToString();
        StatUIUpdate();
    }
    public void StatUIUpdate()
    {
        if (IsPlayerStatView)
        {
            nameText.text = userName;
            coinText.text = coin;
            levelText.text = level;
        }
    }
}
