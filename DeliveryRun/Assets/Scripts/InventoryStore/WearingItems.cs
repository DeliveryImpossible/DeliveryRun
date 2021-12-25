using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WearingItems : MonoBehaviour
{
    public EventSystem eventSystem;
    GameObject outfitSet;
    GameObject hairSet;

    private void Start()
    {
        hairSet = GameObject.FindGameObjectWithTag("Player_Body").transform.GetChild(0).GetChild(2).gameObject;
        outfitSet = GameObject.FindGameObjectWithTag("Player_Body").transform.GetChild(0).GetChild(1).GetChild(0).gameObject;

    }

    public void ChangeHair()
    {
        int id = eventSystem.currentSelectedGameObject.GetComponent<ItemInfo>().id;

        if (PlayerInfo.hair != 0)
            hairSet.transform.GetChild(PlayerInfo.hair - 1).gameObject.SetActive(false);

        if (id == PlayerInfo.hair)
            PlayerInfo.hair = 0;
        else
        {
            PlayerInfo.hair = id;
            hairSet.transform.GetChild(id - 1).gameObject.SetActive(true);
        }
    }

    public void ChangeOutfit()
    {
        int id = eventSystem.currentSelectedGameObject.GetComponent<ItemInfo>().id;

        if (PlayerInfo.outfit != 0)
            outfitSet.transform.GetChild(PlayerInfo.outfit - 1).gameObject.SetActive(false);

        if (id == PlayerInfo.outfit)
            PlayerInfo.outfit = 0;
        else
        {
            PlayerInfo.outfit = id;
            outfitSet.transform.GetChild(id - 1).gameObject.SetActive(true);
        }
    }
}
