using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSystem : MonoBehaviour
{
    public Slider itemCountToBuySlider;

    private ShowGoodsInfo showInfo;
    private ItemSaveLoad saveLoad;
    private LoadStoreItems loadStore;

    private int priceToPay;

    private void Start()
    {
        showInfo = GetComponent<ShowGoodsInfo>();
        saveLoad = GetComponent<ItemSaveLoad>();
        loadStore = GetComponent<LoadStoreItems>();
    }

    public void Buy()
    {
        showInfo.TempHideIconToInfoBox(true);

        ItemCount itemCount = saveLoad.GetItemCount();

        int id = showInfo.GetID();
        Debug.Log(id);
        int selectIndexNum = (int)GetComponent<SelectIndex>().index;
        if(priceToPay == 0)
            priceToPay = showInfo.GetPrice();

        //아이템 결제
        if (selectIndexNum == ((int)InventoryIndex.Item))
            itemCount.itemCounts[id] += ((int)itemCountToBuySlider.value);
        //의상, 헤어 결제
        else
            itemCount.have[selectIndexNum - 1].haveList[id] = true;

        PlayerInfo.AddCoin(-1 * priceToPay);
        saveLoad.SaveUpdate(itemCount);

        //초기화
        itemCountToBuySlider.value = 1;
        showInfo.itemInfoPanel.SetActive(false);
    }

    //아이템 슬라이더 개수 가져오기
    public void ValueChangeCheck()
    {
        priceToPay = showInfo.GetPrice() * ((int)itemCountToBuySlider.value);

        showInfo.SettingPriceFormula((int)itemCountToBuySlider.value, priceToPay);
    }
}
