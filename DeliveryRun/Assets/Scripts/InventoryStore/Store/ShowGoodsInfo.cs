using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LitJson;

/*외국어 예외 필요한 스크립트*/
public class ShowGoodsInfo : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject itemInfoPanel;

    private ItemSaveLoad saveLoad;
    private GameObject slot;
    private int id;
    private int price;

    private void Start()
    { 
        saveLoad = GetComponent<ItemSaveLoad>();
        slot = GetComponent<LoadStoreItems>().inventorySlotBox;
    }

    public void ShowInfoBox()
    {
        itemInfoPanel.SetActive(true);
        TempHideIconToInfoBox(false);

        SettingItemInfoPanel();
    }

    public void Cancle()
    {
        itemInfoPanel.transform.GetChild(4).gameObject.GetComponent<Slider>().value = 1;    //슬라이더 초기화
        itemInfoPanel.SetActive(false);
        TempHideIconToInfoBox(true);
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetID()
    {
        return id;
    }

    public void SettingPriceFormula(int sliderValue, int priceToPay)
    {
        Text priceFormula = itemInfoPanel.transform.GetChild(2).GetChild(1).GetComponent<Text>();
        RectTransform coinPosition = itemInfoPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<RectTransform>();

        int coinPriceWhenFomulaPositionX = -90;
        int coinPricePositionX = -30;

        if (sliderValue != 1)
        {
            coinPosition.anchoredPosition = new Vector3(coinPriceWhenFomulaPositionX, 0, 0);
            priceFormula.text = (GetPrice().ToString() + " * " + sliderValue.ToString() + " = " + priceToPay.ToString());
        }
        else
        {
            coinPosition.anchoredPosition = new Vector3(coinPricePositionX, 0, 0);
            priceFormula.text = GetPrice().ToString();
        }
    }

    public void TempHideIconToInfoBox(bool show)
    {
        for(int i = 0; i < slot.transform.childCount; i += 3)
        {
            slot.transform.GetChild(i).GetChild(0).gameObject.SetActive(show);
        }
    }

    private void SettingItemInfoPanel()
    {
        GameObject selectedItem = eventSystem.currentSelectedGameObject;
        id = selectedItem.GetComponent<ItemInfo>().id - 1;
        JsonData itemInfoJsonData = saveLoad.GetJsonData();
        ItemCount count = saveLoad.GetItemCount();
        int selectIndexNum = (int)GetComponent<SelectIndex>().index;

        GameObject itemCountToBuySlider = itemInfoPanel.transform.GetChild(4).gameObject;
        GameObject nowHavingItemCount = itemInfoPanel.transform.GetChild(5).gameObject;
        Button buyBtn = itemInfoPanel.transform.GetChild(6).GetChild(0).GetComponent<Button>();
        GameObject lackCoinMent = itemInfoPanel.transform.GetChild(7).gameObject;

        //이미지
        itemInfoPanel.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = selectedItem.transform.GetChild(0).GetComponent<Image>().sprite;

        //가격
        price = ((int)itemInfoJsonData[selectIndexNum][0][id]["Price"]);
        itemInfoPanel.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Text>().text = price.ToString();  //단품 가격

        //설명
        Transform ItmeDetailBox = itemInfoPanel.transform.GetChild(3);
        ItmeDetailBox.GetChild(0).gameObject.GetComponent<Text>().text = itemInfoJsonData[selectIndexNum][0][id]["Name"][0]["KOR"].ToString();  //이름
        ItmeDetailBox.GetChild(1).gameObject.GetComponent<Text>().text = itemInfoJsonData[selectIndexNum][0][id]["Detail"][0]["KOR"].ToString();    //설명


        int itemCountCanBeBought = PlayerInfo.coin / price;

        if (selectIndexNum == ((int)InventoryIndex.Item))
        {
            if (itemCountCanBeBought == 0)
            {
                //코인 부족
                itemCountToBuySlider.SetActive(false);  //아이템 개수 설정 비활성화
                lackCoinMent.SetActive(true);   //개수 부족 멘트 
                buyBtn.interactable = false;  //구매 버튼 비활성화
            }
            else
            {
                itemCountToBuySlider.SetActive(true);  //아이템 개수 설정 활성화
                itemCountToBuySlider.GetComponent<Slider>().maxValue = itemCountCanBeBought;  //아이템 구매 개수 최대값 설정
                itemCountToBuySlider.transform.GetChild(3).GetChild(1).gameObject.GetComponent<Text>().text = itemCountCanBeBought.ToString();  //아이템 구매 개수 최대값 표시
                buyBtn.interactable = true;
            }

            nowHavingItemCount.SetActive(true);
            nowHavingItemCount.GetComponent<Text>().text = "현재 " + count.itemCounts[id] + "개 보유중";
        }
        else
        {
            itemCountToBuySlider.SetActive(false);
            nowHavingItemCount.SetActive(false);

            if (itemCountCanBeBought == 0)
            {
                lackCoinMent.SetActive(true);
                buyBtn.interactable = false;
            }
            else
                buyBtn.interactable = true;
        }
    }
}
