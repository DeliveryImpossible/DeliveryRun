using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemIndexInfo
{
    class ItemIndex
    {
        public static int[] itemsIndexInt = { 0, 1, 2 };
        public static string[] itemsIndexString = { "Item", "Hair", "Outfit" };
    }
}

public enum InventoryIndex
{
    Item,
    Hair,
    Outfit
}

public class SelectIndex : MonoBehaviour
{
    public InventoryIndex index = InventoryIndex.Item;
    public GameObject indexes;

    private LoadItems loadItems;
    private GameObject[] indexObj;
    private Color deselect = new Color(0.8f, 0.8f, 0.8f);

    private void Start()
    {
        loadItems = GetComponent<LoadItems>();
        indexObj = new GameObject[3]{ indexes.transform.GetChild(0).gameObject, indexes.transform.GetChild(1).gameObject, indexes.transform.GetChild(2).gameObject };
        MarkIndex();
    }

    public void SetIndex(int selectedIndex)
    {
        int beforeIndex = (int)index;
        switch (selectedIndex)
        {
            case 1:
                index = InventoryIndex.Item;
                break;
            case 2:
                index = InventoryIndex.Hair;
                break;
            case 3:
                index = InventoryIndex.Outfit;
                break;
        }
        MarkIndex();

        loadItems.ResetGoods(beforeIndex);
        loadItems.Refresh();
    }

    public void MarkIndex()
    {
        indexObj[((int)index)].GetComponent<Image>().color = Color.white;
        indexObj[(((int)index) + 1) % 3].GetComponent<Image>().color = deselect;
        indexObj[(((int)index) + 2) % 3].GetComponent<Image>().color = deselect;
        GetComponent<TurnIcon>().CheckIndexItems();
    }
}
